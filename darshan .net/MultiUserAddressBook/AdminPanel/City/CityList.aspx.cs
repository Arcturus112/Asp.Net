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

namespace MultiUserAddressBook.AdminPanel.City
{
    public partial class CityList : System.Web.UI.Page
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
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiAddressBookConnectionString"].ConnectionString);
            #endregion Local Variables
            try
            {
                #region Set Connection
                objConn.Open();
                SqlCommand objCmd = new SqlCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.StoredProcedure;
                #endregion Set Connection
                objCmd.CommandText = "PR_City_SelectByUserID";
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
                SqlDataReader objSDR = objCmd.ExecuteReader();

                gvCity.DataSource = objSDR;
                gvCity.DataBind();

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

        #region gvCity
        protected void gvCity_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region Delete Record
            if (e.CommandName == "DeleteRecord")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    DeleteCity(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
                }
            }
            #endregion Delete Record
        }
        #endregion gvCity

        #region Delete City
        private void DeleteCity(SqlInt32 CityID)
        {
            #region Local Variables
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiAddressBookConnectionString"].ConnectionString);
            #endregion Local Variables
            try
            {
                #region Set Connection
                objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                #endregion Set Connection
                objCmd.CommandText = "PR_City_DeleteByUserIDCityID";
                objCmd.Parameters.AddWithValue("@CityID", CityID.ToString());
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
                objCmd.ExecuteNonQuery();

                objConn.Close();
                FillGridView();
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
        #endregion Delete City
    }
}