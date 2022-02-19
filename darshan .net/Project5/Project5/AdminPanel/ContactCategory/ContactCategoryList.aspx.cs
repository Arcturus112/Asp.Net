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

namespace Project5.AdminPanel.ContactCategory
{
    public partial class ContactCategoryList : System.Web.UI.Page
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
                objCmd.CommandText = "PR_ContactCategory_SelectAll";
                SqlDataReader objSDR = objCmd.ExecuteReader();

                gvConCat.DataSource = objSDR;
                gvConCat.DataBind();

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

        #region gvConCat
        protected void gvConCat_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region Delete Record
            if (e.CommandName == "DeleteRecord")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    DeleteContactCategory(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
                }
            }
            #endregion Delete Record
        }
        #endregion gvConCat

        #region Delete ContactCategory
        private void DeleteContactCategory(SqlInt32 ContactCategoryID)
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
                objCmd.CommandText = "PR_ContactCategory_DeleteByPK";
                objCmd.Parameters.AddWithValue("@ContactCategoryID", ContactCategoryID.ToString());
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
        #endregion Delete ContactCategory
    }
}