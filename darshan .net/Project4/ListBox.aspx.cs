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
            foreach (ListItem li in lstBox1.Items)
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

        protected void btn1_Click(object sender, EventArgs e)
        {
            if(lstBox1.SelectedItem == null)
            {
                lblLList.Text = "Kindly Select A Item";
            }
            else
            {
                lstBox2.Items.Add(lstBox1.SelectedItem);
                int i = 0;
                i = lstBox1.SelectedIndex;
                lstBox1.Items.RemoveAt(i);
            }
        }

        protected void btn3_Click(object sender, EventArgs e)
        {
            if (lstBox2.SelectedItem == null)
            {
                lblLList.Text = "Kindly Select A Item";
            }
            else
            {
                lstBox1.Items.Add(lstBox2.SelectedItem);
                int i = 0;
                i = lstBox2.SelectedIndex;
                lstBox2.Items.RemoveAt(i);
            }
        }

        protected void btn2_Click(object sender, EventArgs e)
        {
            while (lstBox1.Items.Count != 0)
            {
                for(int i = 0;i< lstBox1.Items.Count; i++)
                {
                    lstBox2.Items.Add(lstBox1.Items[i]);
                    lstBox1.Items.Remove(lstBox1.Items[i]);
                }
            }
        }

        protected void btn4_Click(object sender, EventArgs e)
        {
            while (lstBox2.Items.Count != 0)
            {
                for (int i = 0; i < lstBox2.Items.Count; i++)
                {
                    lstBox1.Items.Add(lstBox2.Items[i]);
                    lstBox2.Items.Remove(lstBox2.Items[i]);
                }
            }
        }
        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            if (lstBox1.Items.Contains(new ListItem(txtCountryName.Text.Trim(), txtCountryCode.Text.Trim())) == true)
            {
                lblLList.Text = "Country already Added.";
            }
            else
            {
                lstBox1.Items.Add(new ListItem(txtCountryName.Text.Trim(), txtCountryCode.Text.Trim()));
            }
        }

        protected void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (lstBox1.Items.Contains(new ListItem(txtCountryName.Text.Trim(), txtCountryCode.Text.Trim())) == true)
            {
                lstBox1.Items.Remove(new ListItem(txtCountryName.Text.Trim(), txtCountryCode.Text.Trim()));
            }
            else
            {
                lblLList.Text = "Item Not Available.";
            }
        }

        protected void btnUpdateItem_Click(object sender, EventArgs e)
        {
            if(lstBox1.Items.Contains(new ListItem(txtOldCountryName.Text.Trim(), txtOldCountryCode.Text.Trim())) == true)
            {
                lstBox1.Items.Remove(new ListItem(txtOldCountryName.Text.Trim(), txtOldCountryCode.Text.Trim()));
                lstBox1.Items.Add(new ListItem(txtCountryName.Text.Trim(), txtCountryCode.Text.Trim()));
            }
            else
            {
                lblLList.Text = "Item Is not Available";
            }
        }
    }
}