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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillCountryDropDownList();
                FillContactCategoryDropDownList();
            }
        }

        protected void ddlCountryID_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillStateDropDownList();
        }

        protected void ddlStateID_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillCityDropDownList();
        }

        private void FillCountryDropDownList()
        {
            SqlConnection sqlConn = new SqlConnection();
            sqlConn.ConnectionString = "data source=DESKTOP-6H43U15;initial catalog=AddressBook;Integrated Security=True";
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

        private void FillStateDropDownList()
        {
            SqlConnection sqlConn = new SqlConnection();
            sqlConn.ConnectionString = "data source=DESKTOP-6H43U15;initial catalog=AddressBook;Integrated Security=True";
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

        private void FillCityDropDownList()
        {
            SqlConnection sqlConn = new SqlConnection();
            sqlConn.ConnectionString = "data source=DESKTOP-6H43U15;initial catalog=AddressBook;Integrated Security=True";
            sqlConn.Open();

            SqlCommand objCmd = sqlConn.CreateCommand();

            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_City_SelectForDropDownListByStateId";
            objCmd.Parameters.AddWithValue("@StateID", ddlStateID.SelectedValue);

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

        private void FillContactCategoryDropDownList()
        {
            SqlConnection sqlConn = new SqlConnection();
            sqlConn.ConnectionString = "data source=DESKTOP-6H43U15;initial catalog=AddressBook;Integrated Security=True";
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

            if (ddlStateID.SelectedIndex > 0)
            {
                strStateID = Convert.ToInt32(ddlStateID.SelectedValue);
            }
            if (ddlCountryID.SelectedIndex > 0)
            {
                strCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
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

            SqlConnection sqlConn = new SqlConnection();
            sqlConn.ConnectionString = "data source=DESKTOP-6H43U15;initial catalog=AddressBook;Integrated Security=True";
            sqlConn.Open();

            SqlCommand objCmd = sqlConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Contact_Insert";

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

            objCmd.ExecuteNonQuery();

            sqlConn.Close();

            
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
        }
    }
}