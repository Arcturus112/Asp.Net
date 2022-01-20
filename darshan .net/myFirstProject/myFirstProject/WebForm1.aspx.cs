using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            TextBox1.Text = "";
            Textbox2.Text = "";
            textbox3.Text = "";
            lblAnswer.Text = "";
            lbl1.Text = "";
            lbl2.Text = "";
            lbl3.Text = "";

        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            if (TextBox1.Text.Trim() == "")
            {
                lbl1.Text = "Enter number";
            }
            else if (Textbox2.Text.Trim()==""){
                lbl2.Text = "Enter Operation";
            }
            else if (textbox3.Text.Trim() == "")
            {
                lbl3.Text = "Enter Number";
            }

            else
            {

                if (Textbox2.Text.Trim() == "+")
                {
                    lblAnswer.Text = Convert.ToString(Convert.ToDouble(TextBox1.Text.Trim()) + Convert.ToDouble(textbox3.Text.Trim()));
                }
                else if (Textbox2.Text.Trim() == "-")
                {
                    lblAnswer.Text = Convert.ToString(Convert.ToDouble(TextBox1.Text.Trim()) - Convert.ToDouble(textbox3.Text.Trim()));
                }
                else if (Textbox2.Text.Trim() == "*")
                {
                    lblAnswer.Text = Convert.ToString(Convert.ToDouble(TextBox1.Text.Trim()) * Convert.ToDouble(textbox3.Text.Trim()));
                }
                else if (Textbox2.Text.Trim() == "/")
                {
                    lblAnswer.Text = Convert.ToString(Convert.ToDouble(TextBox1.Text.Trim()) / Convert.ToDouble(textbox3.Text.Trim()));
                }
                else
                {
                    lblAnswer.Text = "please enter valide opeator";
                }
            }
        
        }
    }
}