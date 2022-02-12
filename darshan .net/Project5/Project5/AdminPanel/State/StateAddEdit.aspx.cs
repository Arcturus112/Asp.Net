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

namespace Project5.AdminPanel.State
{
    public partial class StateAddEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillDropDownList();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlInt32 strCountryID = SqlInt32.Null;
            SqlString strStateName = SqlString.Null;
            SqlString strStateID = SqlString.Null;

            string strErrorMassage = "";

            if(ddlCountryID.SelectedIndex == 0)
            {
                strErrorMassage += "- Select Country - <br/>";
            }
            if(txtStateName.Text.Trim() == "")
            {
                strErrorMassage += "- Enter State Name - <br/>";
            }
            if (txtStateID.Text.Trim() == "")
            {
                strErrorMassage += "- Enter State ID - <br/>";
            }
            if (strErrorMassage.Trim() != "")
            {
                lblMassage.Text = strErrorMassage;
                return;
            }

            if(ddlCountryID.SelectedIndex > 0)
            {
                strCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
            }
            if (txtStateName.Text.Trim() != "")
            {
                strStateName = txtStateName.Text.Trim();
            }
            if (txtStateID.Text.Trim() != "")
            {
                strStateID = txtStateID.Text.Trim();
            }

            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
            sqlConn.Open();

            SqlCommand objCmd  = sqlConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_Insert";

            objCmd.Parameters.AddWithValue("@CountryID",strCountryID);
            objCmd.Parameters.AddWithValue("@StateCode", strStateID);
            objCmd.Parameters.AddWithValue("@StateName", strStateName);

            objCmd.ExecuteNonQuery();

            sqlConn.Close();

            txtStateName.Text = "";
            ddlCountryID.SelectedIndex = 0;
            txtStateID.Text = "";
            ddlCountryID.Focus();
            lblMassage.Text = "Data Inserted Successfully";
        }

        private void FillDropDownList()
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
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
    }
}