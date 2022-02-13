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

public partial class AdminPanel_State_StateList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            FillStateGridView();
        }
    }
    #endregion Load Event

    #region DeleteStateGridView
    protected void DeleteStateGridView(SqlInt32 strStateId)
    {

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiuserAddressBookConnectionString"].ConnectionString);
        try
        {
            #region Set ConnectionString and Connection Object
            if (objConn.State!=ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_DeleteByPkUserID";
            objCmd.Parameters.AddWithValue("StateId", strStateId);
            objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            objCmd.ExecuteNonQuery();
            #endregion Set ConnectionString and Connection Object

        }
        catch(Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            objConn.Close();
        }
        FillStateGridView();
    }
    #endregion DeleteStateGridView

    #region FillStateGridView
    protected void FillStateGridView()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiuserAddressBookConnectionString"].ConnectionString);

        try
        {
            #region Set ConnectionString and CommandObject
            if (objConn.State!=ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_SelectAllByUserID";
            objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            #endregion Set ConnectionString and CommandObject

            #region Get the Data And Set to Controls
            SqlDataReader objSDR = objCmd.ExecuteReader();
            gvStateList.DataSource = objSDR;
            gvStateList.DataBind();
            #endregion Get the Data And Set to Controls

        }
        catch(Exception ex)
        {
            lblMessage.Text=ex.Message;
        }
        finally
        {
            if(objConn.State==ConnectionState.Open)
                objConn.Close();
        }
        
        
    }
    #endregion FillStateGridView

    #region gvStateList : RowCommand
    protected void gvStateList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName == "DeleteState")
        {
            if(e.CommandArgument!="")
            {
               // lblMessage.Text = "Delete Button Clicked | State Id " + e.CommandArgument;
                DeleteStateGridView(Convert.ToInt32(e.CommandArgument));
            }
        }

    }
    #endregion gvStateList : RowCommand
}