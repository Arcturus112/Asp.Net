﻿using System;
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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlString strCountryName = SqlString.Null;
            SqlString strCountryCode = SqlString.Null;

            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();

            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_Insert";

            if(txtCountryName.Text.Trim() != "")
            {
                strCountryName = txtCountryName.Text.Trim();
                objCmd.Parameters.AddWithValue("@CountryName", strCountryName);
            }

            if(txtCountryCode.Text.Trim() != "")
            {
                strCountryCode = txtCountryCode.Text.Trim();
                objCmd.Parameters.AddWithValue("@CountryCode", strCountryCode);
            }

            objCmd.ExecuteNonQuery();

            objConn.Close();
            lblMassage.Text = "Data Inserted Successfully";
            txtCountryName.Text = "";
            txtCountryCode.Text = "";
            txtCountryName.Focus();
        }
    }
}