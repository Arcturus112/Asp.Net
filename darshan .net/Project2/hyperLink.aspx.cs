using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project2
{
    public partial class hyperLink : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnClick_Click(object sender, EventArgs e)
        {
            if (rbDiet.Checked == true)
            {
                diet.Visible = true;
                dietDs.Visible = false;
                textCourse.Visible = true;
                lblCourse.Visible = true;
                btnCourseCheck.Visible = true;
                lblError.Text = "";
            }

            else if (rbDietDs.Checked == true)
            {
                dietDs.Visible = true;
                diet.Visible = false;
                textCourse.Visible = true;
                lblCourse.Visible = true;
                btnCourseCheck.Visible = true;
                lblError.Text = "";
            }
            else
            {
                lblError.Text = "Kindly Choose One College";
            }
        }

        protected void btnCourseCheck_Click(object sender, EventArgs e)
        {
            if (rbDiet.Checked == true)
            {
                if (rbComputerDiet.Checked == true)
                {
                    lblCourse.Text = rbComputerDiet.Text;
                }
                else if (rbMechanicalDiet.Checked == true)
                {
                    lblCourse.Text = rbMechanicalDiet.Text;
                }
                else if (rbElectricalDiet.Checked == true)
                {
                    lblCourse.Text = rbElectricalDiet.Text;
                }
                else if (rbCivilDiet.Checked == true)
                {
                    lblCourse.Text = rbCivilDiet.Text;
                }
                else
                {
                    lblCourse.Text = "Kindly Select The Course";
                }
            }

            else
            {
                if (rbComputerDietDs.Checked == true)
                {
                    lblCourse.Text = rbComputerDietDs.Text;
                }
                else if (rbMechanicalDietDs.Checked == true)
                {
                    lblCourse.Text = rbMechanicalDietDs.Text;
                }
                else if (rbElectricalDietDs.Checked == true)
                {
                    lblCourse.Text = rbElectricalDietDs.Text;
                }
                else if (rbCivilDietDs.Checked == true)
                {
                    lblCourse.Text = rbCivilDietDs.Text;
                }
                else
                {
                    lblCourse.Text = "Kindly Select The Course";
                }
            }
        }
        protected void btnClick2_Click1(object sender, EventArgs e)
        {
            if (chkDiet.Checked == true && chkDietds.Checked == true)
            {
                chkCheckAll.Visible = true;
                chkClearAll.Visible = true;
                chkDietCe.Visible = true;
                chkDietMe.Visible = true;
                chkDietEe.Visible = true;
                chkDietCi.Visible = true;
                chkDietdsCe.Visible = true;
                chkDietdsMe.Visible = true;
                chkDietdsEe.Visible = true;
                chkDietdsCi.Visible = true;
            }
            else if (chkDiet.Checked == true || chkDietds.Checked == true)
            {
                if (chkDiet.Checked)
                {
                    lblCollegeSelection.Text = "You have selected DIET.";
                    chkCheckAll.Visible = true;
                    chkClearAll.Visible = true;
                    chkDietCe.Visible = true;
                    chkDietMe.Visible = true;
                    chkDietEe.Visible = true;
                    chkDietCi.Visible = true;
                    chkDietdsCe.Visible = false;
                    chkDietdsMe.Visible = false;
                    chkDietdsEe.Visible = false;
                    chkDietdsCi.Visible = false;
                }
                else if (chkDietds.Checked)
                {
                    lblCollegeSelection.Text = "You have selected DIETDS.";
                    chkCheckAll.Visible = true;
                    chkClearAll.Visible = true;
                    chkDietdsCe.Visible = true;
                    chkDietdsMe.Visible = true;
                    chkDietdsEe.Visible = true;
                    chkDietdsCi.Visible = true;
                    chkDietCe.Visible = false;
                    chkDietMe.Visible = false;
                    chkDietEe.Visible = false;
                    chkDietCi.Visible = false;
                }
                else
                {
                    chkCheckAll.Visible = true;
                    chkClearAll.Visible = true;
                    chkDietCe.Visible = true;
                    chkDietMe.Visible = true;
                    chkDietEe.Visible = true;
                    chkDietCi.Visible = true;
                    chkDietdsCe.Visible = true;
                    chkDietdsMe.Visible = true;
                    chkDietdsEe.Visible = true;
                    chkDietdsCi.Visible = true;
                }
            }
            else
            {
                lblCollegeSelection.Text = "Kindly Select the College.";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            String strBranch = "";
            if (chkDietCe.Checked)
            {
                strBranch += chkDietCe.Text + "<br />";
            }
            if (chkDietMe.Checked)
            {
                strBranch += chkDietMe.Text + "<br />";
            }
            if (chkDietEe.Checked)
            {
                strBranch += chkDietEe.Text + "<br />";
            }
            if (chkDietCi.Checked)
            {
                strBranch += chkDietCi.Text + "<br />";
            }
            if (chkDietdsCe.Checked)
            {
                strBranch += chkDietdsCe.Text + "<br />";
            }
            if (chkDietdsMe.Checked)
            {
                strBranch += chkDietdsMe.Text + "<br />";
            }
            if (chkDietdsEe.Checked)
            {
                strBranch += chkDietdsEe.Text + "<br />";
            }
            if (chkDietdsCi.Checked)
            {
                strBranch += chkDietdsCi.Text + "<br />";
            }
            else
            {
                lblBranchSelection.Text = "Kindly select the branch.";
            }
            lblBranchSelection.Text = "You have selected : <br />" + strBranch;
        }

        protected void chkCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            if(chkDiet.Checked == true && chkDietds.Checked == true)
            {
                chkDietCe.Checked = true;
                chkDietMe.Checked = true;
                chkDietEe.Checked = true;
                chkDietCi.Checked = true;
                chkDietdsCe.Checked = true;
                chkDietdsMe.Checked = true;
                chkDietdsEe.Checked = true;
                chkDietdsCi.Checked = true;
            }
            else if (chkDiet.Checked == true && chkDietds.Checked == false)
            {
                chkDietCe.Checked = true;
                chkDietMe.Checked = true;
                chkDietEe.Checked = true;
                chkDietCi.Checked = true;
                chkDietdsCe.Checked = false;
                chkDietdsMe.Checked = false;
                chkDietdsEe.Checked = false;
                chkDietdsCi.Checked = false;
            }
            else if (chkDiet.Checked == false && chkDietds.Checked == true)
            {
                chkDietCe.Checked = false;
                chkDietMe.Checked = false;
                chkDietEe.Checked = false;
                chkDietCi.Checked = false;
                chkDietdsCe.Checked = true;
                chkDietdsMe.Checked = true;
                chkDietdsEe.Checked = true;
                chkDietdsCi.Checked = true;
            }
            else
            {
                lblBranchSelection.Text = "Kindly select the branch.";
            }
        }

        protected void chkClearAll_CheckedChanged(object sender, EventArgs e)
        {
            chkDietCe.Checked = false;
            chkDietMe.Checked = false;
            chkDietEe.Checked = false;
            chkDietCi.Checked = false;
            chkDietdsCe.Checked = false;
            chkDietdsMe.Checked = false;
            chkDietdsEe.Checked = false;
            chkDietdsCi.Checked = false;
            lblBranchSelection.Text = "";
        }
    }
}