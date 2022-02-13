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

public partial class AdminPanel_City_CityList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            FillCityGridView();

        }
    }
    #endregion Load Event

    #region FillCityGridView
    protected void FillCityGridView()
    {
        //STEP 1
        //Prepare connection Object
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString );
        //Data Source = DESKTOP-N3N2V66\SQLEXPRESS;
        //Initial Catalog = DtaBase NAme ;
        //Integrated Security=true in case of windos Authentication and if not then fase and provide username = sa ; password = 1234;

        try
        {
                #region Set ConnectionString And CommandObject
                if (objConn.State!=ConnectionState.Open)
                    objConn.Open();
                SqlCommand objCmd = new SqlCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_City_SelectAllByUserID";
                objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
                #endregion Set ConnectionString And CommandObject

                #region Get the Data And Set to Controls
                SqlDataReader objSDR = objCmd.ExecuteReader();
                gvCountrylist.DataSource = objSDR;
                gvCountrylist.DataBind();
                #endregion Get the Data And Set to Controls
        }
        catch(Exception abc)
        {
            lblMessage.Text = abc.Message;
        }
        finally
        {
            if(objConn.State==ConnectionState.Open)
            objConn.Close();
        }
        
    }
    #endregion FillCityGridView

    #region DeleteCityGridView
    protected void DeleteCityGridView(SqlInt32 strCityId)
    {

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiuserAddressBookConnectionString"].ConnectionString);
        try
        {
            #region Set ConnectionString and Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_City_DeletByPkUserID";
            objCmd.Parameters.AddWithValue("CityId", strCityId);
            objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);

            #endregion Set ConnectionString and Command Object
            objCmd.ExecuteNonQuery();
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
        FillCityGridView();
    }
    #endregion DeleteCityGridView

    #region gvCountrylist : RowCommand
    protected void gvCountrylist_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName=="DeleteCity")
        {
            if(e.CommandArgument!=null)
            {
                DeleteCityGridView(Convert.ToInt32(e.CommandArgument));
            }
        }
    }
    #endregion gvCountrylist : RowCommand

}