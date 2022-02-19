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
    public partial class CountryAddEdit : System.Web.UI.Page
    {
        #region Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["CountryID"] != null)
                {
                    lblMassage.Text = "Edit Mode";
                    FillControls(Convert.ToInt32(Request.QueryString["CountryID"]));
                }
                else
                {
                    lblMassage.Text = "Add Mode";
                }
            }
        }
        #endregion Load Event

        #region Button : Save
        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region Local Variables
            SqlString strCountryName = SqlString.Null;
            SqlString strCountryCode = SqlString.Null;
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
            #endregion Local Variables
            try
            {
                #region Server Side Validation
                string strErrorMassage = "";

                if (txtCountryCode.Text.Trim() == "")
                {
                    strErrorMassage += "- Enter Country Code - <br/>";
                }
                if (txtCountryName.Text.Trim() == "")
                {
                    strErrorMassage += "- Enter Country Name - <br/>";
                }
                if (strErrorMassage.Trim() != "")
                {
                    lblMassage.Text = strErrorMassage;
                    return;
                }
                #endregion Server Side Validation
                objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;

                #region Gather Information & Command Object
                if (txtCountryName.Text.Trim() != "")
                {
                    strCountryName = txtCountryName.Text.Trim();
                    objCmd.Parameters.AddWithValue("@CountryName", strCountryName);
                }

                if (txtCountryCode.Text.Trim() != "")
                {
                    strCountryCode = txtCountryCode.Text.Trim();
                    objCmd.Parameters.AddWithValue("@CountryCode", strCountryCode);
                }
                #endregion Gather Information & Command Object

                if (Request.QueryString["CountryID"] != null)
                {
                    #region Edit Record
                    objCmd.Parameters.AddWithValue("@CountryID", Request.QueryString["CountryID"].ToString().Trim());
                    objCmd.CommandText = "PR_Country_UpdatePK";
                    objCmd.ExecuteNonQuery();
                    Response.Redirect("~/AdminPanel/Country/CountryList.aspx", true);
                    #endregion Edit Record
                }
                else
                {
                    #region Add Record
                    objCmd.CommandText = "PR_Country_Insert";
                    objCmd.ExecuteNonQuery();
                    lblMassage.Text = "Data Inserted Successfully";
                    txtCountryName.Text = "";
                    txtCountryCode.Text = "";
                    txtCountryName.Focus();
                    #endregion Add Record
                }
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
        #endregion Button : Save

        #region Button : Cancel
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPanel/Country/CountryList.aspx", true);
        }
        #endregion Button : Cancel

        #region FillControls
        private void FillControls(SqlInt32 CountryID)
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

            try
            {
                #region Set Connection & Command Object
                sqlConn.Open();

                SqlCommand objCmd = sqlConn.CreateCommand();

                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_Country_SelectByPK";
                objCmd.Parameters.AddWithValue("@CountryID", CountryID.ToString().Trim());

                SqlDataReader objSDR = objCmd.ExecuteReader();
                #endregion Set Connection & Command Object
                #region Read the Value And Set The Controls
                if (objSDR.HasRows == true)
                {
                    while (objSDR.Read())
                    {
                        if (!objSDR["CountryName"].Equals(DBNull.Value))
                        {
                            txtCountryName.Text = objSDR["CountryName"].ToString().Trim();
                        }
                        if (!objSDR["CountryCode"].Equals(DBNull.Value))
                        {
                            txtCountryCode.Text = objSDR["CountryCode"].ToString().Trim();
                        }
                        break;
                    }
                }
                else
                {
                    lblMassage.Text = "No Data Available For The CountryID = " + CountryID.ToString().Trim();
                }
                #endregion Read the Value And Set The Controls
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                lblMassage.Text = ex.Message;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        #endregion FillControls
    }
}