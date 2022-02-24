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

namespace MultiUserAddressBook.AdminPanel.Login
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void btnSignUP_Click(object sender, EventArgs e)
        //{
        //    #region Local Variable
        //    SqlString strUsername = SqlString.Null;
        //    SqlString strPassword = SqlString.Null;
        //    SqlString strDisplayName = SqlString.Null;
        //    SqlString strContactno = SqlString.Null;
        //    SqlString strEmail = SqlString.Null;
        //    string strErrorMessage = "";
        //    #endregion Local Variable


        //    #region Server Side Validation
        //    if (txtUsername.Text == "")
        //        strErrorMessage += "-enter UserName <br>";

        //    if (txtPassword.Text == "")
        //        strErrorMessage += "-enter Password <br>";

        //    if (txtDisplayName.Text == "")
        //        strErrorMessage += "-enter Displayname <br>";

        //    if (txtEmail.Text == "")
        //        strErrorMessage += "-enter Email Address <br>";

        //    if (txtContactno.Text == "")
        //        strErrorMessage += "-enter Email Address <br>";

        //    if (strErrorMessage != "")
        //    {
        //        lblMassage.Text = strErrorMessage;
        //        return;
        //    }
        //    #endregion Server Side Validation

        //    #region Gather Information

        //    if (txtUsername.Text != "")
        //        strUsername = txtUsername.Text.ToString().Trim();

        //    if (txtPassword.Text != "")
        //        strPassword = txtPassword.Text.ToString().Trim();

        //    if (txtContactno.Text != "")
        //        strContactno = txtContactno.Text.ToString().Trim();

        //    if (txtDisplayName.Text != "")
        //        strDisplayName = txtDisplayName.Text.ToString().Trim();

        //    if (txtEmail.Text != "")
        //        strEmail = txtEmail.Text.ToString().Trim();



        //    #endregion Gather Information

        //    SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiAddressBookConnectionString"].ConnectionString);



        //    try
        //    {
        //        #region Set Connection String and Command Object
        //        if (objConn.State != ConnectionState.Open)
        //            objConn.Open();

        //        SqlCommand objCmd = objConn.CreateCommand();
        //        objCmd.CommandType = CommandType.StoredProcedure;
        //        objCmd.CommandText = "PR_User_Insert";
        //        objCmd.Parameters.AddWithValue("@UserName", strUsername);
        //        objCmd.Parameters.AddWithValue("@Password", strPassword);
        //        objCmd.Parameters.AddWithValue("@DisplayName", strDisplayName);
        //        objCmd.Parameters.AddWithValue("@MobileNo", strContactno);
        //        objCmd.Parameters.AddWithValue("@Email", strEmail);
        //        #endregion Set Connection String and Command Object
        //        objCmd.ExecuteNonQuery();

        //        lblMassage.Text = "Successfully Created Account ! Please Login";

        //        txtEmail.Text = "";
        //        txtUsername.Text = "";
        //        txtPassword.Text = "";
        //        txtDisplayName.Text = "";
        //        txtContactno.Text = "";


        //        if (objConn.State != ConnectionState.Closed)
        //            objConn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        lblMassage.Text = ex.Message;
        //    }
        //    finally
        //    {
        //        if (objConn.State != ConnectionState.Closed)
        //            objConn.Close();
        //    }
        //}



        protected void btnSignUP_Click(object sender, EventArgs e)
        {
            #region Local Variable
            SqlString strUsername = SqlString.Null;
            SqlString strPassword = SqlString.Null;
            SqlString strDisplayName = SqlString.Null;
            SqlString strContactno = SqlString.Null;
            SqlString strEmail = SqlString.Null;
            string strErrorMessage = "";
            #endregion Local Variable


            #region Server Side Validation
            if (txtUsername.Text == "")
                strErrorMessage += "-enter UserName <br>";

            if (txtPassword.Text == "")
                strErrorMessage += "-enter Password <br>";

            if (txtDisplayName.Text == "")
                strErrorMessage += "-enter Displayname <br>";

            if (txtEmail.Text == "")
                strErrorMessage += "-enter Email Address <br>";

            if (txtContactno.Text == "")
                strErrorMessage += "-enter Email Address <br>";

            if (strErrorMessage != "")
            {
                lblMassage.Text = strErrorMessage;
                return;
            }
            #endregion Server Side Validation

            #region Gather Information

            if (txtUsername.Text != "")
                strUsername = txtUsername.Text.ToString().Trim();

            if (txtPassword.Text != "")
                strPassword = txtPassword.Text.ToString().Trim();

            if (txtContactno.Text != "")
                strContactno = txtContactno.Text.ToString().Trim();

            if (txtDisplayName.Text != "")
                strDisplayName = txtDisplayName.Text.ToString().Trim();

            if (txtEmail.Text != "")
                strEmail = txtEmail.Text.ToString().Trim();



            #endregion Gather Information

            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiAddressBookConnectionString"].ConnectionString);



            try
            {
                #region Set Connection String And Command Object And Check User Existence
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                bool exists = false;
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_User_Check";
                    objCmd.Parameters.AddWithValue("@UserName", strUsername);
                    exists = (int)objCmd.ExecuteScalar() > 0;
                }
                if (exists)
                    lblMassage.Text = "This username has been using by another user.";
                else
                {
                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_User_Insert";
                        objCmd.Parameters.AddWithValue("@UserName", strUsername);
                        objCmd.Parameters.AddWithValue("@Password", strPassword);
                        objCmd.Parameters.AddWithValue("@DisplayName", strDisplayName);
                        objCmd.Parameters.AddWithValue("@MobileNo", strContactno);
                        objCmd.Parameters.AddWithValue("@Email", strEmail);

                        objCmd.ExecuteNonQuery();
                        lblMassage.Text = "Successfully Created Account ! Please Login";

                        txtEmail.Text = "";
                        txtUsername.Text = "";
                        txtPassword.Text = "";
                        txtDisplayName.Text = "";
                        txtContactno.Text = "";
                    }
                }

                #endregion Set Connection String And Command Object And Check User Existence


                if (objConn.State != ConnectionState.Closed)
                    objConn.Close();
            }
            catch (Exception ex)
            {
                lblMassage.Text = ex.Message;
            }
            finally
            {
                if (objConn.State != ConnectionState.Closed)
                    objConn.Close();
            }
        }

    }
}