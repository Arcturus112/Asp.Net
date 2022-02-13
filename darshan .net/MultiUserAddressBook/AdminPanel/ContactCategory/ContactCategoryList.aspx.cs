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

public partial class AdminPanel_ContactCategory_ContactCategory : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            FillContactCategoryGridView();
        }
    }
    #endregion Load Event

    #region FillContactCategoryGridView
    protected void FillContactCategoryGridView()
    {
        
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiuserAddressBookConnectionString"].ConnectionString);

        try
        {
            #region Set ConnectionString And CommandObject
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactCategory_SelectAllByUserID";
            objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            #endregion Set ConnectionString And CommandObject

            #region Get the Data And Set to Controls

            SqlDataReader objSDR = objCmd.ExecuteReader();
            gvContactCategoryList.DataSource = objSDR;
            gvContactCategoryList.DataBind();
            #endregion Get the Data And Set to Controls
        }
        catch (Exception abc)
        {
            lblMessage.Text = abc.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }

    }
    #endregion FillCityGridView

    #region DeleteContactCategoryGridView
    private void DeleteContactCategoryGridView(SqlInt32 strContactCategoryId)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiuserAddressBookConnectionString"].ConnectionString);
        try
        {
            #region Set ConnectionString and Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactCategory_DeleteByPkUserID";
            objCmd.Parameters.AddWithValue("ContactCategoryId", strContactCategoryId);
            objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            #endregion Set ConnectionString and Command Object
            objCmd.ExecuteNonQuery();
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
        FillContactCategoryGridView();
    }
    #endregion DeleteContactCategoryGridView

    #region gvContactCategoryList : RowCommand
    protected void gvContactCategoryList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteContactCategory")
        {
            if (e.CommandArgument != null)
            {
                DeleteContactCategoryGridView(Convert.ToInt32(e.CommandArgument));
            }
        }
    }
    #endregion gvContactCategoryList : RowCommand

}