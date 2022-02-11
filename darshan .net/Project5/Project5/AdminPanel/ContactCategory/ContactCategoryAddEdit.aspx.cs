using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project5.AdminPanel.ContactCategory
{
    public partial class ContactCategoryAddEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlString strContactCategoryName= SqlString.Null;

            SqlConnection objConn = new SqlConnection();
            objConn.ConnectionString = "data source=DESKTOP-6H43U15;initial catalog=AddressBook;Integrated Security=True";
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();

            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactCategory_Insert";

            if (txtContactCategoryName.Text.Trim() != "")
            {
                strContactCategoryName = txtContactCategoryName.Text.Trim();
                objCmd.Parameters.AddWithValue("@ContactCategoryName", strContactCategoryName);
            }

            objCmd.ExecuteNonQuery();

            objConn.Close();
            lblMassage.Text = "Data Inserted Successfully";
            txtContactCategoryName.Text = "";
            txtContactCategoryName.Focus();
        }
    }
}