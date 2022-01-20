using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myFirstProject
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtFirstNo.Text = "";
            txtSecondNo.Text = "";
            txtOperator.Text = "";
            txtAnswer.Text = "";
            lblMassage1.Text = "";
            lblMassage2.Text = "";
            lblMassage3.Text = "";
            lblAnswer.Text = "";
        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {
            if (txtFirstNo.Text.Trim() == "")
            {
                lblMassage1.Text = "Enter First Number";
            }
            else
            {
                lblMassage1.Text = "";
                if (txtOperator.Text.Trim() == "")
                {
                    lblMassage2.Text = "Enter Operation";
                }
                else
                {
                    lblMassage2.Text = "";
                    if (txtSecondNo.Text.Trim() == "")
                    {
                        lblMassage3.Text = "Enter Second Number";
                    }
                    else
                    {
                        lblMassage3.Text = "";
                        if (txtOperator.Text.Trim() == "+")
                        {
                            txtAnswer.Text = Convert.ToString(Int32.Parse(txtFirstNo.Text) + Int32.Parse(txtSecondNo.Text));

                        }
                        else if (txtOperator.Text.Trim() == "-")
                        {
                            txtAnswer.Text = Convert.ToString(Int32.Parse(txtFirstNo.Text) - Int32.Parse(txtSecondNo.Text));
                        }
                        else if (txtOperator.Text.Trim() == "/")
                        {
                            if(txtSecondNo.Text == "0")
                            {
                                txtAnswer.Text = "INFINITY";
                            }
                            else
                            {
                                txtAnswer.Text = Convert.ToString(double.Parse(txtFirstNo.Text) / double.Parse(txtSecondNo.Text));
                            }
                        }
                        else if (txtOperator.Text.Trim() == "*")
                        {
                            txtAnswer.Text = Convert.ToString(Int32.Parse(txtFirstNo.Text) * Int32.Parse(txtSecondNo.Text));
                        }
                        else if (txtOperator.Text.Trim() == "%")
                        {
                            txtAnswer.Text = Convert.ToString(Int32.Parse(txtFirstNo.Text) % Int32.Parse(txtSecondNo.Text));
                        }
                        else
                        {
                            lblAnswer.Text = "please enter valide operator";
                        }
                    }
                }
            }
        }
    }
}