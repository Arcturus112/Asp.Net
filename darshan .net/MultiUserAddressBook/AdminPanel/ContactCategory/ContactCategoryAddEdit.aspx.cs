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

public partial class AdminPanel_ContactCategory_ContactCategoryAddEdit : System.Web.UI.Page
{

    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
            #region Check UpdateMode | AddMode
            if (Request.QueryString["ContactCategoryId"] != null)
            {
                //lblMessage.Text = "EDIT | ContactCategoryId = " + Request.QueryString["CityId"];
                FillControls(Convert.ToInt32(Request.QueryString["ContactCategoryId"].ToString().Trim()));
            }
            else
            {
                //lblMessage.Text = "ADD MOde";
            }
            #endregion Check UpdateMode | AddMode
        }
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variables
        SqlString strContactCategoryName = SqlString.Null;
        String strErrorMessage = "";
        #endregion Local Variables

        #region Server Side Validation
        //Server Side Validation 

        if (txtContactCategoryName.Text.Trim() == "")
            strErrorMessage += "-Please Enter ContactCategory";
 
        if(strErrorMessage!="")
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        #region Gather Information
        //Information Gathering

        if (txtContactCategoryName.Text.Trim() != "")
            strContactCategoryName = txtContactCategoryName.Text.Trim();
        #endregion Gather Information

        try
        {
            #region Set ConnectionString And Command Object
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiuserAddressBookConnectionString"].ConnectionString);
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("ContactCategoryName", strContactCategoryName);
            objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            #endregion Set ConnectionString And Command Object

            if (Request.QueryString["ContactCategoryId"] != null)
            {
                #region Update Record
                objCmd.Parameters.AddWithValue("ContactCategoryId", Request.QueryString["ContactCategoryId"].ToString().Trim());
                objCmd.CommandText = "PR_ContactCategory_UpdateByPkUserID";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/ContactCategory/ContactCategoryList.aspx");
                #endregion Update Record

            }
            else
            {
                #region Insert Record
                objCmd.CommandText = "PR_ContactCategory_InsertByUserID";
                objCmd.ExecuteNonQuery();
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Contact Category Added Successfully";
                txtContactCategoryName.Text = "";
                txtContactCategoryName.Focus();
                #endregion Insert Record

            }
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
        catch(Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            //if (objConn.State == ConnectionState.Open)
            //    objConn.Close();
        }
            
    }
    #endregion Button : Save

    #region FillControls
    private void FillControls(SqlInt32 strContactCategoryId)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiuserAddressBookConnectionString"].ConnectionString);

        try
        {
            #region Set ConnectionString And CommandObject
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactCategory_SelectByPkUserid";
            objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            objCmd.Parameters.AddWithValue("ContactCategoryId", strContactCategoryId);
            #endregion Set ConnectionString And CommandObject

            #region Get the Data And Set To Controls
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["ContactCategoryName"].Equals(DBNull.Value))
                    {
                        txtContactCategoryName.Text = objSDR["ContactCategoryName"].ToString();
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
    #endregion FillControls
    
}