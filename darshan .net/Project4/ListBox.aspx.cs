using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project4
{
    public partial class ListBox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnListButton_Click(object sender, EventArgs e)
        {
            foreach (ListItem li in lstbCountry.Items)
            {
                if (li.Selected == true)
                {
                    lblLList.Text += "<strong>" + li.Text.Trim() + "-" +
                        li.Value.Trim() + "</strong>" + "<br/>";
                }
                else
                {
                    lblLList.Text += li.Text.Trim() + "-" +
                        li.Value.Trim() + "<br/>";
                }
            }
        }
    }
}