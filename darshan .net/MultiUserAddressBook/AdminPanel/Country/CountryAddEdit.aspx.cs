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

public partial class AdminPanel_Country_CountryAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {

        
        if(!Page.IsPostBack)
        {
            if (Request.QueryString["CountryId"] != null)
            {
                //lblMessage.Text = "Edit Mode | StateId = " + Request.QueryString["CountryId"];
                FillControls(Convert.ToInt32(Request.QueryString["CountryId"].ToString().Trim()));
            }
            else
            {
                //lblMessage.Text = "Add Mode";

            }
        }
            
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variables
        SqlString strCountryName = SqlString.Null;
        SqlString strCountryCode = SqlString.Null;
        #endregion Local Variables

        #region ServerSide Validation
        //validation

        String strErrorMessage = "";
        if (txtCountryName.Text.Trim() == "")
            strErrorMessage += "-Enter CountryName <br/>";

        if (txtCountryCode.Text.Trim() == "")
            strErrorMessage += "-Enter CountryCode";

        if(strErrorMessage!="")
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion ServerSide Validation

        #region GatherInformation
        strCountryName = txtCountryName.Text.Trim();
        strCountryCode = txtCountryCode.Text.Trim();
        #endregion GatherInformation

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiuserAddressBookConnectionString"].ConnectionString );

        try
        {
            #region Set ConnectionString and Command Object
            if (objConn.State!=ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("CountryName", strCountryName);
            objCmd.Parameters.AddWithValue("CountryCode", strCountryCode);
            objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            #endregion Set ConnectionString and Command Object
            if (Request.QueryString["CountryId"] != null)
            {
                #region Update Record
                objCmd.Parameters.AddWithValue("CountryId", Convert.ToInt32(Request.QueryString["CountryId"].ToString().Trim()));
                objCmd.CommandText = "PR_Country_UpdateByPkUserID";
                objCmd.ExecuteNonQuery();
                if (lblMessage.Text == "")
                    Response.Redirect("~/AdminPanel/Country/CountryList.aspx");
                else
                    return;
                #endregion Update Record
            }
            else
            {
                #region Insert Record
                objCmd.CommandText = "PR_Country_InsertByUserID";
                objCmd.ExecuteNonQuery();
                txtCountryCode.Text = "";
                txtCountryName.Text = "";
                txtCountryName.Focus();
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Success";
                #endregion Insert Record
            }
            
           
        }
        catch(Exception ex)
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if(objConn.State==ConnectionState.Open)
            objConn.Close();
        }
        
        
    }
    #endregion Button : Save

    #region Button : Cancle
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Country/CountryList.aspx");
    }
    #endregion Button : Cancle

    #region FillControls
    private void FillControls(SqlInt32 strCountryId)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiuserAddressBookConnectionString"].ConnectionString);
        try
        {
            #region Set ConnectionState And CommandObject
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectByPkUserID";
            objCmd.Parameters.AddWithValue("CountryId", strCountryId);
            objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            #endregion Set ConnectionState And CommandObject

            #region Read the data and Set to Controls
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if(objSDR.HasRows)
            {
                while(objSDR.Read())
                {
                    if(objSDR["CountryName"].Equals(DBNull.Value)!= true)
                    {
                        txtCountryName.Text = objSDR["CountryName"].ToString().Trim();
                    }

                    if(!objSDR["CountryCode"].Equals(DBNull.Value))
                    {
                        txtCountryCode.Text = objSDR["CountryCode"].ToString().Trim();
                    }
                    break;
                }
            }
            #endregion Read the data and Set to Controls
        }
        catch(Exception ex)
        {
           lblMessage.Text=ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion FillControls
}