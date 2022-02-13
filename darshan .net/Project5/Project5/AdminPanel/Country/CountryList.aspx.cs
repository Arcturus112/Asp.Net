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

namespace Project5.AdminPanel.Country
{
    public partial class CountryList : System.Web.UI.Page
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
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
            try
            {
                objConn.Open();
                SqlCommand objCmd = new SqlCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_Country_SelectAll";
                SqlDataReader objSDR = objCmd.ExecuteReader();

                gvCountry.DataSource = objSDR;
                gvCountry.DataBind();

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

        #region gvCountry
        protected void gvCountry_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRecord")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    DeleteCountry(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
                }
            }
        }
        #endregion gvCountry

        #region Delete Country
        private void DeleteCountry(SqlInt32 CountryID)
        {
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

            try
            {
                objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_Country_DeleteByPK";
                objCmd.Parameters.AddWithValue("@CountryID", CountryID.ToString());
                objCmd.ExecuteNonQuery();

                objConn.Close();
                FillGridView();
            }
            catch(Exception ex)
            {
                lblMassage.Text =ex.Message;
            }
            finally
            {
                objConn.Close();
            }
        }
        #endregion Delete Country
    }
}