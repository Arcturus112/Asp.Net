using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project5.AdminPanel.Contact
{
    public partial class ContactList : System.Web.UI.Page
    {
        #region Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillGridView();
            }
        }
        #endregion Load Event

        #region Fill GridView
        private void FillGridView()
        {
            #region Local Variables
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
            #endregion Local Variables
            try
            {
                #region Set Connection

                objConn.Open();
                SqlCommand objCmd = new SqlCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.StoredProcedure;
                #endregion Set Connection
                objCmd.CommandText = "PR_Contact_SelectAll";
                SqlDataReader objSDR = objCmd.ExecuteReader();
                gvContact.DataSource = objSDR;
                gvContact.DataBind();

                objConn.Close();
            }
            catch (Exception ex)
            {
                lblMassage.Text = ex.Message;
            }
            finally
            {
                objConn.Close();
            }
        }
        #endregion Fill GridView

        #region gvContact
        protected void gvContact_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            string strPath = "";
            SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
            Conn.Open();
            SqlCommand obj = Conn.CreateCommand();
            obj.CommandType = CommandType.StoredProcedure;
            obj.CommandText = "PR_Contact_ContactPhoto";
            obj.Parameters.AddWithValue("@ContactID", e.CommandArgument.ToString().Trim());
            SqlDataReader objSDR = obj.ExecuteReader();
            while(objSDR.Read()){
                strPath = objSDR["ContactPhotoPath"].ToString().Trim();
            }
            FileInfo file = new FileInfo(Server.MapPath(strPath));
            if (file.Exists)
            {
                file.Delete();
            }
            Conn.Close();

            #region Delete Record
            if (e.CommandName == "DeleteRecord")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    DeleteContact(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
                }
            }
            #endregion Delete Record
        }
        #endregion gvContact

        #region Delete Contact
        private void DeleteContact(SqlInt32 ContactID)
        {
       
            #region Local Variables
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
            #endregion Local Variables
            try
            {
                #region Set Connection
                objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                #endregion Set Connection
                objCmd.CommandText = "PR_Contact_DeleteContact&ContactWiseContactCategory";
                objCmd.Parameters.AddWithValue("@ContactID", ContactID.ToString());
                objCmd.ExecuteNonQuery();

                objConn.Close();
                FillGridView();
            }
            catch(Exception ex)
            {
                lblMassage.Text = ex.Message;
            }
            finally
            {
                objConn.Close();
            }
        }
        #endregion Delete Contact

    }
}