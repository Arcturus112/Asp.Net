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

namespace MultiUserAddressBook.AdminPanel.State
{
    public partial class StateAddEdit : System.Web.UI.Page
    {
        #region Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillDropDownList();
                if (Request.QueryString["StateID"] != null)
                {
                    lblMassage.Text = "Edit Mode";
                    FillControls(Convert.ToInt32(Request.QueryString["StateID"]));
                }
                else
                {
                    lblMassage.Text = "Add Mode";
                }
            }
        }
        #endregion Load Event
        #region Button:Save

        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region Local Variables
            SqlInt32 strCountryID = SqlInt32.Null;
            SqlString strStateName = SqlString.Null;
            SqlString strStateCode = SqlString.Null;
            #endregion Local Variables
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiAddressBookConnectionString"].ConnectionString);

            try
            {
                #region Server Side Validation
                string strErrorMassage = "";

                if (ddlCountryID.SelectedIndex == 0)
                {
                    strErrorMassage += "- Select Country - <br/>";
                }
                if (txtStateName.Text.Trim() == "")
                {
                    strErrorMassage += "- Enter State Name - <br/>";
                }
                if (strErrorMassage.Trim() != "")
                {
                    lblMassage.Text = strErrorMassage;
                    return;
                }
                #endregion Server Side Validation
                #region Gather Information
                if (ddlCountryID.SelectedIndex > 0)
                {
                    strCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
                }
                if (txtStateName.Text.Trim() != "")
                {
                    strStateName = txtStateName.Text.Trim();
                }
                if (txtStateCode.Text.Trim() != "")
                {
                    strStateCode = txtStateCode.Text.Trim();
                }
                #endregion Gather Information
                #region Set Connection & Command Object
                sqlConn.Open();

                SqlCommand objCmd = sqlConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;

                objCmd.Parameters.AddWithValue("@CountryID", strCountryID);
                objCmd.Parameters.AddWithValue("@StateCode", strStateCode);
                objCmd.Parameters.AddWithValue("@StateName", strStateName);
                objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
                #endregion Set Connection & Command Object
                if (Request.QueryString["StateID"] != null)
                {
                    #region Edit Record
                    objCmd.Parameters.AddWithValue("@StateID", Request.QueryString["StateID"].ToString().Trim());
                    objCmd.CommandText = "PR_State_UpdatePK";
                    objCmd.ExecuteNonQuery();
                    Response.Redirect("~/AdminPanel/State/StateList.aspx", true);
                    #endregion Edit Record
                }
                else
                {
                    #region Add Record
                    objCmd.CommandText = "PR_State_Insert";
                    objCmd.ExecuteNonQuery();
                    txtStateName.Text = "";
                    ddlCountryID.SelectedIndex = 0;
                    txtStateCode.Text = "";
                    ddlCountryID.Focus();
                    lblMassage.ForeColor = System.Drawing.Color.Green;
                    lblMassage.Text = "Data Inserted Successfully";
                    #endregion Add Record
                }



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
        #endregion Button:Save

        #region Button:Cancel

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPanel/State/StateList.aspx", true);
        }
        #endregion Button:Cancel

        #region Fill DropDownList

        private void FillDropDownList()
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiAddressBookConnectionString"].ConnectionString);
            try
            {
                #region Set Connection & Command Object
                sqlConn.Open();

                SqlCommand objCmd = sqlConn.CreateCommand();

                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_Country_SelectForDropDownList";
                objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
                SqlDataReader objSDR = objCmd.ExecuteReader();
                #endregion Set Connection & Command Object
                if (objSDR.HasRows == true)
                {
                    ddlCountryID.DataSource = objSDR;
                    ddlCountryID.DataValueField = "CountryID";
                    ddlCountryID.DataTextField = "CountryName";
                    ddlCountryID.DataBind();
                }

                ddlCountryID.Items.Insert(0, new ListItem("Select Country", "-1"));

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
        #endregion Fill DropDownList

        #region Fill Controls

        private void FillControls(SqlInt32 StateID)
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiAddressBookConnectionString"].ConnectionString);
            try
            {
                #region Set Connection & Command Object
                sqlConn.Open();

                SqlCommand objCmd = sqlConn.CreateCommand();

                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_State_SelectByUserIDStateID";
                objCmd.Parameters.AddWithValue("@StateID", StateID.ToString().Trim());
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

                SqlDataReader objSDR = objCmd.ExecuteReader();
                #endregion Set Connection & Command Object
                #region Read the Value And Set The Controls
                if (objSDR.HasRows == true)
                {
                    while (objSDR.Read())
                    {
                        if (!objSDR["StateName"].Equals(DBNull.Value))
                        {
                            txtStateName.Text = objSDR["StateName"].ToString().Trim();
                        }

                        if (!objSDR["CountryID"].Equals(DBNull.Value))
                        {
                            ddlCountryID.SelectedValue = objSDR["CountryID"].ToString().Trim();
                        }
                        if (!objSDR["StateCode"].Equals(DBNull.Value))
                        {
                            txtStateCode.Text = objSDR["StateCode"].ToString().Trim();
                        }
                        break;
                    }
                }
                else
                {
                    lblMassage.Text = "No Data Available For The StateID = " + StateID.ToString().Trim();
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
        #endregion Fill Controls
    }
}