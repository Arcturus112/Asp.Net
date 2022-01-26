using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project4
{
    public partial class ListControls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                DataSet DS = new DataSet();
                string path = Server.MapPath("~/resources/Country-codes.xml");
                DS.ReadXml(path);
                ddlCountry.DataTextField = "Country";
                ddlCountry.DataValueField = "Code";
                ddlCountry.DataSource = DS;
                ddlCountry.DataBind();
            }
        }

        protected void btnDisplayListCountry_Click(object sender, EventArgs e)
        {
            lblListMassage.Text = ddlCountry.SelectedValue;
        }
    }
}