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

public partial class AdminPanel_Country_CountryList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            FillCountryGridview();
        }

    }
    #endregion Load Event

    #region FillCountryGridView
    protected void FillCountryGridview()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiuserAddressBookConnectionString"].ConnectionString);
        try
        {
            #region Set Connection and Command Object
            if(objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectAllByUserID";
            objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            #endregion Set Connection and Command Object

            #region Read the value and Set to Controls
            SqlDataReader objSDR = objCmd.ExecuteReader();
            gvCountryList.DataSource = objSDR;
            gvCountryList.DataBind();
            #endregion Read the value and Set to Controls

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if(objConn.State == ConnectionState.Open)
                objConn.Close();
        }

    }
    #endregion FillCountryGridView

    #region DeleteCountryGridView
    protected void deleteCountryGridView(SqlInt32 strCountrtyId)
    {

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiuserAddressBookConnectionString"].ConnectionString);
        try
        {
            #region Set ConnectionString and CommandObject
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_DeleteByPkUserID";
            objCmd.Parameters.AddWithValue("CountryId", strCountrtyId);
            objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            #endregion Set ConnectionString and CommandObject


            objCmd.ExecuteNonQuery();

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
        FillCountryGridview();
    }
    #endregion DeleteCountryGridView

    #region gvCountryList : RowCommand
    protected void gvCountryList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != "")
            {
                //lblMessage.Text = "Delete Button clicked | Country Id = " + e.CommandArgument;
                deleteCountryGridView(Convert.ToInt32(e.CommandArgument));

            }
        }


    }
    #endregion gvCountryList : RowCommand

}
