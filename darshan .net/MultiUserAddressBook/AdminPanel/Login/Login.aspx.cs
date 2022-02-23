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

namespace MultiUserAddressBook
{
    public partial class Logiin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSign_Click(object sender, EventArgs e)
        {
            #region Local Variable
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiAddressBookConnectionString"].ConnectionString);
            SqlString strUserName = SqlString.Null;
            SqlString strPassword = SqlString.Null;
            #endregion Local Variable

            #region Server Side Validation
            string strErrorMessage = "";

            if(txtUsername.Text.Trim() == "")
            {
                strErrorMessage = "- Enter UserName - <br/>";
            }
            if (txtPassword.Text.Trim() == "")
            {
                strErrorMessage = "- Enter Password - <br/>";
            }
            if (strErrorMessage != "")
            {
                lblMassage.Text = "Kindly Solve Following Error(s) <br/>" + strErrorMessage;
                return;
            }
            #endregion Server Side Validation

            #region Assign the Value

            if(txtUsername.Text.Trim() != "")
            {
                strUserName = txtUsername.Text.Trim();
            }
            if (txtPassword.Text.Trim() != "")
            {
                strPassword = txtPassword.Text.Trim();
            }

            #endregion Assign the Value

            try
            {
                if (objConn.State != ConnectionState.Open)
                {
                    objConn.Open();
                }

                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_User_SelectByUserIDPassword";

                objCmd.Parameters.AddWithValue("@UserName", strUserName);
                objCmd.Parameters.AddWithValue("@Password", strPassword);

                SqlDataReader objSDR = objCmd.ExecuteReader();

                if (objSDR.HasRows)
                {
                    lblMassage.Text = "Valid User";

                    while (objSDR.Read())
                    {
                        if (!objSDR["UserID"].Equals(DBNull.Value))
                        {
                            Session["UserID"] = objSDR["UserID"].ToString().Trim();
                        }
                        if (!objSDR["DisplayName"].Equals(DBNull.Value))
                        {
                            Session["DisplayName"] = objSDR["DisplayName"].ToString().Trim();
                        }
                        break;
                    }
                    Response.Redirect("~/AdminPanel/Default.aspx", true);
                }
                else
                {
                    lblMassage.Text = "Either UserName or Password is Not Valid, Try Again";
                }

                if (objConn.State != ConnectionState.Closed)
                {
                    objConn.Close();
                }
            }
            catch (Exception ex)
            {
                lblMassage.Text = ex.Message;
            }
            finally
            {

            }
            

        }
    }
}