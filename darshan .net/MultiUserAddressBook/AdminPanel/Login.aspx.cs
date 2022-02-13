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

public partial class AdminPanel_Login : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #endregion Page Load Event

    #region Button : Login
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        #region Local Variable
        SqlString strUsername = SqlString.Null;
        SqlString strPassword = SqlString.Null;
        string strErrorMessage = "";
        #endregion Local Variable

        #region Server Side Validation

        if (txtUserNameLogin.Text == "")
            strErrorMessage += "-enter UserName <br>";

        if (txtPasswordLogin.Text == "")
            strErrorMessage += "-enter Password <br>";

        if(strErrorMessage!="")
        {
            lblMessageLogin.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation
      
        #region Gather Information

        if (txtUserNameLogin.Text != "")
            strUsername = txtUserNameLogin.Text.ToString().Trim();

        if (txtPasswordLogin.Text != "")
            strPassword = txtPasswordLogin.Text.ToString().Trim();

        #endregion Gather Information

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiuserAddressBookConnectionString"].ConnectionString);

        try
        {
            #region Set ConnectionString and Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_User_SelectByUserNamePassword";
            objCmd.Parameters.AddWithValue("USERNAME", strUsername);
            objCmd.Parameters.AddWithValue("Password", strPassword);

            #endregion Set ConnectionString and Command Object

            #region Read the Value And Set to the Controls
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if(objSDR.HasRows)
            {
                while(objSDR.Read())
                {
                    if(objSDR["UserID"].Equals(DBNull.Value)!= true)
                    {
                        Session["UserID"] = objSDR["UserID"].ToString().Trim();
                    }

                    if (objSDR["DisplayName"].Equals(DBNull.Value) != true)
                    {
                        Session["DisplayName"] = objSDR["DisplayName"].ToString().Trim();
                    }
                    break;
                }
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                lblMessageLogin.Text = "Invalid UserName Or Password";
            }
            #endregion Read the Value And Set to the Controls

            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
        }
        catch(Exception ex)
        {
            lblMessageLogin.Text = ex.Message;
        }
        finally{
            if(objConn.State!=ConnectionState.Closed)
                objConn.Close();
        }

    }
    #endregion Button : Login

    #region Button : SignUp
    protected void btnSignup_Click(object sender, EventArgs e)
    {
        #region Local Variable
        SqlString strUsername = SqlString.Null;
        SqlString strPassword = SqlString.Null;
        SqlString strDisplayName = SqlString.Null;
        SqlString strContactno = SqlString.Null;
        string strErrorMessage = "";
        #endregion Local Variable


        #region Server Side Validation
        if (txtUsernameSignup.Text == "")
            strErrorMessage += "-enter UserName <br>";

        if (txtPasswordSignup.Text == "")
            strErrorMessage += "-enter Password <br>";

        if (txtDisplayNameSignup.Text == "")
            strErrorMessage += "-enter Displayname <br>";

        if (txtContactnoSignup.Text == "")
            strErrorMessage += "-enter Displayname <br>";

        if (strErrorMessage != "")
        {
            lblMessageSignup.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        #region Gather Information

        if (txtUsernameSignup.Text != "")
            strUsername = txtUsernameSignup.Text.ToString().Trim();

        if (txtPasswordSignup.Text != "")
            strPassword = txtPasswordSignup.Text.ToString().Trim();

        if (txtDisplayNameSignup.Text != "")
            strDisplayName = txtDisplayNameSignup.Text.ToString().Trim();

        if (txtContactnoSignup.Text != "")
            strContactno= txtContactnoSignup.Text.ToString().Trim();

        #endregion Gather Information

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiuserAddressBookConnectionString"].ConnectionString);

        

        try
        {
            #region Set Connection String and Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_User_Insert";
            objCmd.Parameters.AddWithValue("USERNAME", strUsername);
            objCmd.Parameters.AddWithValue("Password", strPassword);
            objCmd.Parameters.AddWithValue("DisplayName", strDisplayName );
            objCmd.Parameters.AddWithValue("Contactnumber", strContactno);
            #endregion Set Connection String and Command Object
            objCmd.ExecuteNonQuery();
            
            lblMessageSignup.Text = "Successfully Created Account ! Please Login";

            txtUserNameLogin.Text = txtUsernameSignup.Text;
            txtContactnoSignup.Text = "";
            txtUsernameSignup.Text = "";
            txtPasswordSignup.Text = "";
            txtDisplayNameSignup.Text = "";
            txtPasswordLogin.Focus();
            
            
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
        }
        catch (Exception ex)
        {
            lblMessageSignup.Text = ex.Message;
        }
        finally
        {
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
        }
    }
    #endregion Button : SignUp
}