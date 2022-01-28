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
                //ListItem li = new ListItem("Select", "-1");
                //ddlCountry.Items.Insert(0, li);
                //ddlCountry.Items.Add(new ListItem("India","91"));
                //ddlCountry.Items.Add(new ListItem("China", "92"));
                //ddlCountry.Items.Add(new ListItem("Srilanka", "93"));
                //ddlCountry.Items.Add(new ListItem("Nepal", "94"));

                //DataSet DS = new DataSet();
                //string path = Server.MapPath("~/resources/Country-codes.xml");
                //DS.ReadXml(path);
                //ddlCountry.DataTextField = "Country";
                //ddlCountry.DataValueField = "Code";
                //ddlCountry.DataSource = DS;
                //ddlCountry.DataBind();
            }
        }

        protected void btnDisplayListCountry_Click(object sender, EventArgs e)
        {
            int index = 0;
            //lblListMassage.Text = ddlCountry.SelectedIndex.ToString().Trim() + "-" +
            //    ddlCountry.SelectedItem.Text.Trim() + "-" +
            //    ddlCountry.SelectedValue.Trim();

            foreach (ListItem li in ddlCountry.Items)
            {
                if(li.Selected == true)
                {
                    lblListMassage.Text += "<strong>"+index + "-" +
                        li.Text.Trim() + "-" +
                        li.Value.Trim() + "</strong>" + "<br/>";
                    index++;
                }
                else
                {
                    lblListMassage.Text += index + "-" +
                        li.Text.Trim() + "-" +
                        li.Value.Trim() + "<br/>";
                    index++;
                }
            }
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            if (ddlCountry.Items.Contains(new ListItem(txtCountryName.Text.Trim(),txtCountryCode.Text.Trim())) == true)
            {
                lblListMassage.Text = "Country already Added.";
            }
            else
            {
                ddlCountry.Items.Add(new ListItem(txtCountryName.Text.Trim(), txtCountryCode.Text.Trim()));
            }
        }

        protected void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (ddlCountry.Items.Contains(new ListItem(txtCountryName.Text.Trim(), txtCountryCode.Text.Trim())) == true)
            {
                ddlCountry.Items.Remove(new ListItem(txtCountryName.Text.Trim(), txtCountryCode.Text.Trim()));
            }
            else
            {
                lblListMassage.Text = "Item Not Available.";
            }
        }
    }
}