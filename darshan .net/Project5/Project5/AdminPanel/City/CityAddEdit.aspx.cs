using System;
using System.Collections.Generic;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillDropDownList();
            }
        }

        private void FillDropDownList()
        {
            SqlConnection sqlConn = new SqlConnection();
            sqlConn.ConnectionString = "data source=DESKTOP-6H43U15;initial catalog=AddressBook;Integrated Security=True";
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlInt32 strStateID = SqlInt32.Null;
            SqlString strCityName = SqlString.Null;
            SqlString strSTDCode = SqlString.Null;
            SqlString strPinCode = SqlString.Null;

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

            SqlConnection sqlConn = new SqlConnection();
            sqlConn.ConnectionString = "data source=DESKTOP-6H43U15;initial catalog=AddressBook;Integrated Security=True";
            sqlConn.Open();

            SqlCommand objCmd = sqlConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_City_Insert";

            objCmd.Parameters.AddWithValue("@StateID", strStateID);
            objCmd.Parameters.AddWithValue("@CityName", strCityName);
            objCmd.Parameters.AddWithValue("@STDCode", strSTDCode);
            objCmd.Parameters.AddWithValue("@PinCode", strPinCode);

            objCmd.ExecuteNonQuery();

            sqlConn.Close();

            txtCityName.Text = "";
            ddlState.SelectedIndex = 0;
            txtSTDCode.Text = "";
            txtPinCode.Text = "";
            ddlState.Focus();
            lblMassage.Text = "Data Inserted Successfully";
        }
    }
}