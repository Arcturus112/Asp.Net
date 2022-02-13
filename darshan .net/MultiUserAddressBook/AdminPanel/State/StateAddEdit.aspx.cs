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

public partial class AdminPanel_State_StateAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownList();

            #region Check UpdateMode | AddMode
            if (Request.QueryString["StateId"] != null)
            {
                //lblMessage.Text = "EDIT Mode | StateId = " + Request.QueryString["StateId"];
                FillControls(Convert.ToInt32(Request.QueryString["StateId"].ToString().Trim()));
            }
            else
            {
                //lblMessage.Text = "ADD Mode";
            }
            #endregion Check UpdateMode | AddMode
        }
    }
    #endregion Load Event

    #region FillControls
    private void FillControls(SqlInt32 strStateId)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiuserAddressBookConnectionString"].ConnectionString);
        try
        {
            #region Set ConnectionString and CommandObject
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_SelectBypkUserID";
            objCmd.Parameters.AddWithValue("StateId", strStateId);
            objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            #endregion Set ConnectionString and CommandObject

            #region Get the Data and Set to Controls
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if(objSDR.HasRows)
            {
                while(objSDR.Read())
                {
                    if(!objSDR["CountryId"].Equals(DBNull.Value))
                    {
                        ddlCountryId.SelectedValue = objSDR["CountryId"].ToString().Trim();
                    }
                    if(!objSDR["StateName"].Equals(DBNull.Value))
                    {
                        txtStateName.Text = objSDR["StateName"].ToString().Trim();
                    }
                    if(!objSDR["StateCode"].Equals(DBNull.Value))
                    {
                        txtStateCode.Text = objSDR["StateCode"].ToString().Trim();
                    }
                    break;

                }
            }
            else
            {
                lblMessage.Text = "No Data Found";
            }
            #endregion Get the Data and Set to Controls

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

    #region FillDropDownList
    private void FillDropDownList()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiuserAddressBookConnectionString"].ConnectionString );
        try
        {
            #region Set ConnectionString and CommandObject
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_ForDropDownListByUserID";
            objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            #endregion Set ConnectionString and CommandObject

            #region Get the Data and Set to Controls
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows == true)
            {
                ddlCountryId.DataSource = objSDR;
                ddlCountryId.DataValueField = "CountryId";
                ddlCountryId.DataTextField = "CountryName";
                ddlCountryId.DataBind();
                ddlCountryId.Items.Insert(0, new ListItem("Select Country", "-1"));
            }
            #endregion Get the Data and Set to Controls
        }
        catch (Exception ex)
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

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variables
        SqlInt64 strCountryId = SqlInt64.Null;
        SqlString strStateName = SqlString.Null;
        SqlString strStateCode = SqlString.Null;
        String strErrorMessage = "";
        #endregion Local Variables

        #region Server Side Validation
        //Server Side Validation
        if(ddlCountryId.SelectedIndex==0)
            strErrorMessage += "-Please Select Country<br>";
        
        if(txtStateName.Text.Trim()=="")
            strErrorMessage += "-Please Enter StateName<br>";

        if (txtStateCode.Text.Trim() == "")
            strErrorMessage += "-Please Enter StateCode<br>";



        if(strErrorMessage!="")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        #region Gather Information
        //Gather Information
        if(ddlCountryId.SelectedIndex > 0)
        {
            strCountryId =Convert.ToInt64(ddlCountryId.SelectedValue);
        }
        if(txtStateName.Text.Trim()!="")
        {
            strStateName = txtStateName.Text.Trim();
        }
        if (txtStateCode.Text.Trim() != "")
        {
            strStateCode = txtStateCode.Text.Trim();
        }
        #endregion Gather Information



        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiuserAddressBookConnectionString"].ConnectionString);
        try
        {
            #region Set ConnectionString And CommandObject
            if (objConn.State!=ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("CountryId", strCountryId);
            objCmd.Parameters.AddWithValue("StateName", strStateName);
            objCmd.Parameters.AddWithValue("StateCode", strStateCode);
            objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            #endregion Set ConnectionString And CommandObject

            if (Request.QueryString["StateId"]!=null)
            {
                #region Update
                objCmd.Parameters.AddWithValue("StateId", Convert.ToInt32(Request.QueryString["StateId"].ToString().Trim()));
                objCmd.CommandText = "PR_State_UpdateByPkUserID";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/State/StateList.aspx",false);
                #endregion Update
            }
            else
            {
                #region Insert
                objCmd.CommandText = "PR_State_InsertByUserID";
                objCmd.ExecuteNonQuery();
                lblMessage.Text = "Success";
                txtStateName.Text = "";
                txtStateCode.Text = "";
                ddlCountryId.SelectedIndex = 0;
                ddlCountryId.Focus();
                #endregion Insert
            }
            
        }
        catch (Exception ex)
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