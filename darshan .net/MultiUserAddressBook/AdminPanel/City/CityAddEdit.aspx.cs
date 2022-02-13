using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_City_CityAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            FillDropDownList();
            #region Check UpdateMode | AddMode
            if (Request.QueryString["CityId"] != null)
            {
                //lblMessage.Text = "EDIT | CityId = " + Request.QueryString["CityId"];
                FillControls(Convert.ToInt32(Request.QueryString["CityId"].ToString().Trim()));
            }
            else
            {
                //lblMessage.Text = "ADD MOde";
            }
            #endregion Check UpdateMode | AddMode
        }

        
    }
    #endregion Load Event

    #region FillDropDownList
    private void FillDropDownList()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiuserAddressBookConnectionString"].ConnectionString);

       
        try
        {
            #region Set ConnectionString And CommandObject
            if (objConn.State!= ConnectionState.Open)
            objConn.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_ForDropDownListByUserId";
            objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            #endregion Set ConnectionString And CommandObject

            #region Get Data And Set to Controls
            SqlDataReader sqlSDR = objCmd.ExecuteReader();
            if (sqlSDR.HasRows == true)
            {
                ddlStateId.DataSource = sqlSDR;
                ddlStateId.DataValueField = "StateId";
                ddlStateId.DataTextField = "StateName";
                ddlStateId.DataBind();
                ddlStateId.Items.Insert(0, new ListItem("Select State", "-1"));
            }
            else
            {
                lblMessage.Text = "Data Not Found";
            }
            #endregion Get Data And Set to Controls
        }
        catch(Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
        
    }
    #endregion FillDropDownList

    #region FillControls
    private void FillControls(SqlInt32 strCityId)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiuserAddressBookConnectionString"].ConnectionString);

        try
        {
            #region Set ConnectionString And CommandObject
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_City_SelectByPkUserID";
            objCmd.Parameters.AddWithValue("CityId", strCityId);
            objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);

            #endregion Set ConnectionString And CommandObject

            #region Get the Data And Set To Controls
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if(objSDR.HasRows)
            {
                while(objSDR.Read())
                {
                    if(!objSDR["StateId"].Equals(DBNull.Value))
                    {
                        ddlStateId.SelectedValue = objSDR["StateId"].ToString();
                    }
                    if(!objSDR["CityName"].Equals(DBNull.Value))
                    {
                        txtCityName.Text = objSDR["CityName"].ToString();
                    }
                    if (!objSDR["STDCode"].Equals(DBNull.Value))
                    {
                        txtStdCode.Text = objSDR["STDCode"].ToString();
                    }
                    if (!objSDR["PinCode"].Equals(DBNull.Value))
                    {
                        txtPinCode.Text = objSDR["PinCode"].ToString();
                    }
                    break;
                }
            }
            else
            {
                lblMessage.Text = "Data Not Found";
            }

            #endregion Get the Data And Set To Controls



        }
        catch(Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion FillControls

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variable
        SqlInt32 strStateId = SqlInt32.Null;
        SqlString strCityName = SqlString.Null;
        SqlString strSTDCode = SqlString.Null;
        SqlString strPinCode = SqlString.Null;
        #endregion Local Variable

        #region Server Side Validation
        //Server Side Validation 
        String strErrorMessage = "";

        if (ddlStateId.SelectedIndex == 0)
            strErrorMessage += "-Please Select Country <br>";

        if (txtCityName.Text.Trim() == "")
            strErrorMessage += "-Please Enter CityName <br>";

        if(strErrorMessage!="")
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        #region Gather Information
        //Gather Information
        if(ddlStateId.SelectedIndex > 0)
            strStateId = Convert.ToInt32(ddlStateId.SelectedValue);

        if (txtCityName.Text.Trim() != "")
            strCityName = txtCityName.Text.Trim();

        if (txtStdCode.Text.Trim() != "")
            strSTDCode = txtStdCode.Text.Trim();

        if (txtPinCode.Text.Trim() != "")
            strPinCode = txtPinCode.Text.Trim();

        #endregion Gather Information

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        try
        {
            #region Set ConnectionString And CommandObject
            if (objConn.State!=ConnectionState.Open)
            objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("StateId", strStateId);
            objCmd.Parameters.AddWithValue("CityName", strCityName);
            objCmd.Parameters.AddWithValue("STDCode", strSTDCode);
            objCmd.Parameters.AddWithValue("PinCode", strPinCode);
            objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);

            #endregion Set ConnectionString And CommandObject


            if (Request.QueryString["CityId"]!=null)
            {
                #region Update Record
                objCmd.CommandText = "PR_City_UpdateByPkUserID";
                objCmd.Parameters.AddWithValue("CityId",Convert.ToInt32(Request.QueryString["CityId"].ToString().Trim()));
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/City/CityList.aspx");
                #endregion Update Record
            }
            else
            {
                #region Insert Record
                objCmd.CommandText = "PR_City_InsertByUserID";
                objCmd.ExecuteNonQuery();
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "City Added Successfully";
                txtPinCode.Text = "";
                txtStdCode.Text = "";
                txtCityName.Text = "";
                ddlStateId.SelectedIndex = 0;
                ddlStateId.Focus();
                #endregion Insert Record
            }
            
        }
        catch(Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if(objConn.State==ConnectionState.Open)
            objConn.Close();
        }





    }
    #endregion Button : Save
}