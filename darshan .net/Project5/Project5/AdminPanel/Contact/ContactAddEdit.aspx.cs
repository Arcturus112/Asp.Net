using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;


namespace Project5.AdminPanel.Contact
{
    public partial class ContactAddEdit : System.Web.UI.Page
    {
        #region Load Event
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                FillCountryDropDownList();
                FillContactCategoryDropDownList();
                
                

                if (Request.QueryString["ContactID"] != null)
                {
                    lblMassage.Text = "Edit Mode | ContactID = " + Request.QueryString["ContactID"].ToString();
                    FillControls(Convert.ToInt32(Request.QueryString["ContactID"]));
                    FillStateDropDownList();
                    FillCityDropDownList();
                }
                else
                {
                    lblMassage.Text = "Add Mode";
                }


            }
        }
        #endregion Load Event

        #region SelectedIndexChanged : Country
        protected void ddlCountryID_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillStateDropDownList();
        }
        #endregion SelectedIndexChanged : Country

        #region SelectedIndexChanged : State
        protected void ddlStateID_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillCityDropDownList();
        }
        #endregion SelectedIndexChanged : State

        #region Fill Country DropDownList
        private void FillCountryDropDownList()
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
            try
            {
                if (sqlConn.State != ConnectionState.Open)
                    sqlConn.Open();

                SqlCommand objCmd = sqlConn.CreateCommand();

                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_Country_SelectForDropDownList";

                SqlDataReader objSDR = objCmd.ExecuteReader();

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
        #endregion Fill Country DropDownList

        #region Fill State DropDownList
        private void FillStateDropDownList()
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
            try
            {
                sqlConn.Open();

                SqlCommand objCmd = sqlConn.CreateCommand();

                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_State_SelectForDropDownListByCountryId";
                objCmd.Parameters.AddWithValue("@CountryID", ddlCountryID.SelectedValue);

                SqlDataReader objSDR = objCmd.ExecuteReader();

                if (objSDR.HasRows == true)
                {
                    ddlStateID.DataSource = objSDR;
                    ddlStateID.DataValueField = "StateID";
                    ddlStateID.DataTextField = "StateName";
                    ddlStateID.DataBind();
                }

                ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));

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
        #endregion Fill State DropDownList

        #region Fill City DropDownList
        private void FillCityDropDownList()
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
            try
            {
                sqlConn.Open();

                SqlCommand objCmd = sqlConn.CreateCommand();

                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_City_SelectForDropDownListByStateId";
                objCmd.Parameters.AddWithValue ("@StateID", ddlStateID.SelectedValue);
                SqlDataReader objSDR = objCmd.ExecuteReader();

                if (objSDR.HasRows == true)
                {
                    ddlCityID.DataSource = objSDR;
                    ddlCityID.DataValueField = "CityID";
                    ddlCityID.DataTextField = "CityName";
                    ddlCityID.DataBind();
                }

                ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));

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
        #endregion Fill City DropDownList

        #region Fill ContactCategory DropDownList
        private void FillContactCategoryDropDownList()
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
            try
            {
                sqlConn.Open();

                SqlCommand objCmd = sqlConn.CreateCommand();

                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_ContactCategory_SelectForDropDownList";

                SqlDataReader objSDR = objCmd.ExecuteReader();

                if (objSDR.HasRows == true)
                {
                    ddlContactCategoryID.DataSource = objSDR;
                    ddlContactCategoryID.DataValueField = "ContactCategoryID";
                    ddlContactCategoryID.DataTextField = "ContactCategoryName";
                    ddlContactCategoryID.DataBind();
                }

                ddlContactCategoryID.Items.Insert(0, new ListItem("Select Contact Category", "-1"));

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
        #endregion Fill ContactCategory DropDownList

        #region FillControls
        private void FillControls(SqlInt32 ContactID)
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
            try
            {
                #region Set Connection & Command Object
                sqlConn.Open();

                SqlCommand objCmd = sqlConn.CreateCommand();

                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_Contact_SelectByPK";
                objCmd.Parameters.AddWithValue("@ContactID", ContactID.ToString().Trim());

                SqlDataReader objSDR = objCmd.ExecuteReader();
                #endregion Set Connection & Command Object
                #region Read the Value And Set The Controls
                if (objSDR.HasRows == true)
                {
                    while (objSDR.Read())
                    {
                        if (!objSDR["CountryID"].Equals(DBNull.Value))
                        {
                            ddlCountryID.SelectedValue = objSDR["CountryID"].ToString().Trim();
                        }
                        if (!objSDR["StateID"].Equals(DBNull.Value))
                        {
                            ddlStateID.SelectedValue = objSDR["StateID"].ToString().Trim();
                        }
                        if (!objSDR["CityID"].Equals(DBNull.Value))
                        {
                            ddlCityID.SelectedValue = objSDR["CityID"].ToString().Trim();
                        }
                        if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
                        {
                            ddlContactCategoryID.SelectedValue = objSDR["ContactCategoryID"].ToString().Trim();
                        }
                        if (!objSDR["ContactName"].Equals(DBNull.Value))
                        {
                            txtContactName.Text = objSDR["ContactName"].ToString().Trim();
                        }
                        if (!objSDR["ContactNo"].Equals(DBNull.Value))
                        {
                            txtContactNo.Text = objSDR["ContactNo"].ToString().Trim();
                        }
                        if (!objSDR["WhatsAppNo"].Equals(DBNull.Value))
                        {
                            txtWhatsAppNo.Text = objSDR["WhatsAppNo"].ToString().Trim();
                        }
                        if (!objSDR["BirthDate"].Equals(DBNull.Value))
                        {
                            txtBirthDate.Text = objSDR["BirthDate"].ToString().Trim();
                        }
                        if (!objSDR["Email"].Equals(DBNull.Value))
                        {
                            txtEmail.Text = objSDR["Email"].ToString().Trim();
                        }
                        if (!objSDR["Age"].Equals(DBNull.Value))
                        {
                            txtAge.Text = objSDR["Age"].ToString().Trim();
                        }
                        if (!objSDR["Address"].Equals(DBNull.Value))
                        {
                            txtAddress.Text = objSDR["Address"].ToString().Trim();
                        }
                        if (!objSDR["BloodGroup"].Equals(DBNull.Value))
                        {
                            txtBloodGroup.Text = objSDR["BloodGroup"].ToString().Trim();
                        }
                        if (!objSDR["FacebookID"].Equals(DBNull.Value))
                        {
                            txtFacebookID.Text = objSDR["FacebookID"].ToString().Trim();
                        }
                        if (!objSDR["LinkedINID"].Equals(DBNull.Value))
                        {
                            txtLinkedinID.Text = objSDR["LinkedINID"].ToString().Trim();
                        }
                        
                        break;
                    }
                }
                else
                {
                    lblMassage.Text = "No Data Available For The ContactID = " + ContactID.ToString().Trim();
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

        #region Button : Save
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlInt32 strCountryID = SqlInt32.Null;
            SqlInt32 strStateID = SqlInt32.Null;
            SqlInt32 strCityID = SqlInt32.Null;
            SqlInt32 strContactCategoryID = SqlInt32.Null;
            SqlString strContactName = SqlString.Null;
            SqlString strContactNo = SqlString.Null;
            SqlString strWhatsAppNo = SqlString.Null;
            SqlString strBirthDate = SqlString.Null;
            SqlString strEmail = SqlString.Null;
            SqlString strAge = SqlString.Null;
            SqlString strAddress = SqlString.Null;
            SqlString strBloodGroup = SqlString.Null;
            SqlString strFacebookID = SqlString.Null;
            SqlString strLinkedINID = SqlString.Null;

            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);


            try
            {
                string strErrorMassage = "";

                if (ddlCountryID.SelectedIndex == 0)
                {
                    strErrorMassage += "- Select Country - <br/>";
                }
                if (ddlStateID.SelectedIndex == 0)
                {
                    strErrorMassage += "- Select State - <br/>";
                }
                if (ddlCityID.SelectedIndex == 0)
                {
                    strErrorMassage += "- Select City - <br/>";
                }
                if (ddlContactCategoryID.SelectedIndex == 0)
                {
                    strErrorMassage += "- Select Contact Category - <br/>";
                }
                if (txtContactName.Text.Trim() == "")
                {
                    strErrorMassage += "- Enter Contact Name - <br/>";
                }
                if (txtContactNo.Text.Trim() == "")
                {
                    strErrorMassage += "- Enter Contact No - <br/>";
                }
                if (txtWhatsAppNo.Text.Trim() == "")
                {
                    strErrorMassage += "- Enter WhatsApp No - <br/>";
                }
                if (txtBirthDate.Text.Trim() == "")
                {
                    strErrorMassage += "- Enter BirthDate - <br/>";
                }
                if (txtEmail.Text.Trim() == "")
                {
                    strErrorMassage += "- Enter Email - <br/>";
                }
                if (txtAge.Text.Trim() == "")
                {
                    strErrorMassage += "- Enter Age - <br/>";
                }
                if (txtAddress.Text.Trim() == "")
                {
                    strErrorMassage += "- Enter Address - <br/>";
                }
                if (txtBloodGroup.Text.Trim() == "")
                {
                    strErrorMassage += "- Enter BloodGroup - <br/>";
                }
                if (txtFacebookID.Text.Trim() == "")
                {
                    strErrorMassage += "- Enter Facebook ID - <br/>";
                }
                if (txtLinkedinID.Text.Trim() == "")
                {
                    strErrorMassage += "- Enter LinkedIN ID - <br/>";
                }
                if (strErrorMassage.Trim() != "")
                {
                    lblMassage.Text = strErrorMassage;
                    return;
                }

                if (ddlCountryID.SelectedIndex > 0)
                {
                    strCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
                }
                if (ddlStateID.SelectedIndex > 0)
                {
                    strStateID = Convert.ToInt32(ddlStateID.SelectedValue);
                }
                if (ddlCityID.SelectedIndex > 0)
                {
                    strCityID = Convert.ToInt32(ddlCityID.SelectedValue);
                }
                if (ddlContactCategoryID.SelectedIndex > 0)
                {
                    strContactCategoryID = Convert.ToInt32(ddlContactCategoryID.SelectedValue);
                }
                if (txtContactName.Text.Trim() != "")
                {
                    strContactName = txtContactName.Text.Trim();
                }
                if (txtContactNo.Text.Trim() != "")
                {
                    strContactNo = txtContactNo.Text.Trim();
                }
                if (txtWhatsAppNo.Text.Trim() != "")
                {
                    strWhatsAppNo = txtWhatsAppNo.Text.Trim();
                }
                if (txtBirthDate.Text.Trim() != "")
                {
                    strBirthDate = txtBirthDate.Text.Trim();
                }
                if (txtEmail.Text.Trim() != "")
                {
                    strEmail = txtEmail.Text.Trim();
                }
                if (txtAge.Text.Trim() != "")
                {
                    strAge = txtAge.Text.Trim();
                }
                if (txtAddress.Text.Trim() != "")
                {
                    strAddress = txtAddress.Text.Trim();
                }
                if (txtBloodGroup.Text.Trim() != "")
                {
                    strBloodGroup = txtBloodGroup.Text.Trim();
                }
                if (txtFacebookID.Text.Trim() != "")
                {
                    strFacebookID = txtFacebookID.Text.Trim();
                }
                if (txtLinkedinID.Text.Trim() != "")
                {
                    strLinkedINID = txtLinkedinID.Text.Trim();
                }

                sqlConn.Open();

                SqlCommand objCmd = sqlConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                

                objCmd.Parameters.AddWithValue("@CountryID", strCountryID);
                objCmd.Parameters.AddWithValue("@StateID", strStateID);
                objCmd.Parameters.AddWithValue("@CityID", strCityID);
                objCmd.Parameters.AddWithValue("@ContactCategoryID", strContactCategoryID);
                objCmd.Parameters.AddWithValue("@ContactName", strContactName);
                objCmd.Parameters.AddWithValue("@ContactNo", strContactNo);
                objCmd.Parameters.AddWithValue("@WhatsAppNo", strWhatsAppNo);
                objCmd.Parameters.AddWithValue("@BirthDate", strBirthDate);
                objCmd.Parameters.AddWithValue("@Email", strEmail);
                objCmd.Parameters.AddWithValue("@Age", strAge);
                objCmd.Parameters.AddWithValue("@Address", strAddress);
                objCmd.Parameters.AddWithValue("@BloodGroup", strBloodGroup);
                objCmd.Parameters.AddWithValue("@FacebookID", strFacebookID);
                objCmd.Parameters.AddWithValue("@LinkedINID", strLinkedINID);

                if (Request.QueryString["ContactID"] != null)
                {
                    #region Edit Record
                    objCmd.Parameters.AddWithValue("@ContactID", Request.QueryString["ContactID"].ToString().Trim());
                    objCmd.CommandText = "PR_Contact_UpdatePK";
                    objCmd.ExecuteNonQuery();
                    Response.Redirect("~/AdminPanel/Contact/ContactList.aspx", true);
                    #endregion Edit Record
                }
                else
                {
                    #region Add Record
                    objCmd.CommandText = "PR_Contact_Insert";
                    objCmd.ExecuteNonQuery();
                    ddlCountryID.SelectedIndex = 0;
                    ddlStateID.SelectedIndex = 0;
                    ddlCityID.SelectedIndex = 0;
                    ddlContactCategoryID.SelectedIndex = 0;
                    txtContactName.Text = "";
                    txtContactNo.Text = "";
                    txtWhatsAppNo.Text = "";
                    txtBirthDate.Text = "";
                    txtEmail.Text = "";
                    txtAge.Text = "";
                    txtAddress.Text = "";
                    txtBloodGroup.Text = "";
                    txtFacebookID.Text = "";
                    txtLinkedinID.Text = "";
                    ddlCountryID.Focus();
                    lblMassage.Text = "Data Inserted Successfully";
                    Response.Redirect("~/AdminPanel/Contact/ContactList.aspx", true);
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

        #region Button : Cancel
        protected void btnCancel_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPanel/Contact/ContactList.aspx", true);
        }

        #endregion Button : Cancel

    }
}