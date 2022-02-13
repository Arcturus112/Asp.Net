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

namespace Project5.AdminPanel.City
{
    public partial class CityAddEdit : System.Web.UI.Page
    {
        #region Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillDropDownList();
                if (Request.QueryString["CityID"] != null)
                {
                    lblMassage.Text = "Edit Mode";
                    FillControls(Convert.ToInt32(Request.QueryString["CityID"]));
                }
                else
                {
                    lblMassage.Text = "Add Mode";
                }
            }
        }
        #endregion Load Event

        #region Fill DropDownList
        private void FillDropDownList()
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
            try
            {
                sqlConn.Open();

                SqlCommand objCmd = sqlConn.CreateCommand();

                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_State_SelectForDropDownList";

                SqlDataReader objSDR = objCmd.ExecuteReader();

                if (objSDR.HasRows == true)
                {
                    ddlState.DataSource = objSDR;
                    ddlState.DataValueField = "StateID";
                    ddlState.DataTextField = "StateName";
                    ddlState.DataBind();
                }

                ddlState.Items.Insert(0, new ListItem("Select State", "-1"));

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

        #region Button : Save
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlInt32 strStateID = SqlInt32.Null;
            SqlString strCityName = SqlString.Null;
            SqlString strSTDCode = SqlString.Null;
            SqlString strPinCode = SqlString.Null;

            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

            try
            {
                string strErrorMassage = "";

            if (ddlState.SelectedIndex == 0)
            {
                strErrorMassage += "- Select State - <br/>";
            }
            if (txtCityName.Text.Trim() == "")
            {
                strErrorMassage += "- Enter City Name - <br/>";
            }
            if (txtSTDCode.Text.Trim() == "")
            {
                strErrorMassage += "- Enter STD Code - <br/>";
            }
            if (txtPinCode.Text.Trim() == "")
            {
                strErrorMassage += "- Enter Pin Code - <br/>";
            }
            if (strErrorMassage.Trim() != "")
            {
                lblMassage.Text = strErrorMassage;
                return;
            }

            if (ddlState.SelectedIndex > 0)
            {
                strStateID = Convert.ToInt32(ddlState.SelectedValue);
            }
            if (txtCityName.Text.Trim() != "")
            {
                strCityName = txtCityName.Text.Trim();
            }
            if (txtSTDCode.Text.Trim() != "")
            {
                strSTDCode = txtSTDCode.Text.Trim();
            }
            if (txtPinCode.Text.Trim() != "")
            {
                strPinCode = txtPinCode.Text.Trim();
            }

                sqlConn.Open();

                SqlCommand objCmd = sqlConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                

                objCmd.Parameters.AddWithValue("@StateID", strStateID);
                objCmd.Parameters.AddWithValue("@CityName", strCityName);
                objCmd.Parameters.AddWithValue("@STDCode", strSTDCode);
                objCmd.Parameters.AddWithValue("@PinCode", strPinCode);

                if (Request.QueryString["CityID"] != null)
                {
                    #region Edit Record
                    objCmd.Parameters.AddWithValue("@CityID", Request.QueryString["CityID"].ToString().Trim());
                    objCmd.CommandText = "PR_City_UpdatePK";
                    objCmd.ExecuteNonQuery();
                    Response.Redirect("~/AdminPanel/City/CityList.aspx", true);
                    #endregion Edit Record
                }
                else
                {
                    #region Add Record
                    objCmd.CommandText = "PR_City_Insert";
                    objCmd.ExecuteNonQuery();
                    txtCityName.Text = "";
                    ddlState.SelectedIndex = 0;
                    txtSTDCode.Text = "";
                    txtPinCode.Text = "";
                    ddlState.Focus();
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
        #endregion Button : Save

        #region FillControls
        private void FillControls(SqlInt32 CityID)
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
            try
            {
                #region Set Connection & Command Object
                sqlConn.Open();

                SqlCommand objCmd = sqlConn.CreateCommand();

                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_City_SelectByPK";
                objCmd.Parameters.AddWithValue("@CityID", CityID.ToString().Trim());

                SqlDataReader objSDR = objCmd.ExecuteReader();
                #endregion Set Connection & Command Object
                #region Read the Value And Set The Controls
                if (objSDR.HasRows == true)
                {
                    while (objSDR.Read())
                    {
                        if (!objSDR["CityName"].Equals(DBNull.Value))
                        {
                            txtCityName.Text = objSDR["CityName"].ToString().Trim();
                        }

                        if (!objSDR["StateID"].Equals(DBNull.Value))
                        {
                            ddlState.SelectedValue = objSDR["StateID"].ToString().Trim();
                        }
                        if (!objSDR["STDCode"].Equals(DBNull.Value))
                        {
                            txtSTDCode.Text = objSDR["STDCode"].ToString().Trim();
                        }
                        if (!objSDR["PinCode"].Equals(DBNull.Value))
                        {
                            txtPinCode.Text = objSDR["PinCode"].ToString().Trim();
                        }
                        break;
                    }
                }
                else
                {
                    lblMassage.Text = "No Data Available For The CityID = " + CityID.ToString().Trim();
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

        #region Button : Cancel
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPanel/City/CityList.aspx", true);
        }
        #endregion Button : Cancel
    }
}