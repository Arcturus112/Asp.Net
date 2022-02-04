using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project5.AdminPanel.City
{
    public partial class CityList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection objConn = new SqlConnection();
            objConn.ConnectionString = "data source=DESKTOP-6H43U15;initial catalog=AddressBook;Integrated Security=True";
            objConn.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_City_SelectAll";
            SqlDataReader objSDR = objCmd.ExecuteReader();

            gvCity.DataSource = objSDR;
            gvCity.DataBind();

            objConn.Close();
        }
    }
}