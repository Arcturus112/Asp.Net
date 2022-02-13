using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Contact_ContactAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
            Country_FillDropDownList();
            ContactCategory_FillDropDownList();

            #region Check UpdateMode | AddMode
            if (Request.QueryString["ContactId"] != null)
            {
                //lblMessage.Text = "EDIT | ContactCategoryId = " + Request.QueryString["CityId"];
                FillControls(Convert.ToInt32(Request.QueryString["ContactId"].ToString().Trim()));
            }
            else
            {
                //lblMessage.Text = "ADD MOde";
            }
            #endregion Check UpdateMode | AddMode
        }
    }
    #endregion Load Event

    #region FillControls
    private void FillControls(SqlInt32 strContactId)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiuserAddressBookConnectionString"].ConnectionString);

        try
        {
            #region Set ConnectionString And CommandObject
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Contact_SelectByPkUserID";
            objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            objCmd.Parameters.AddWithValue("ContactId", strContactId);
            #endregion Set ConnectionString And CommandObject

            #region Get the Data And Set To Controls
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["CountryId"].Equals(DBNull.Value))
                    {
                        ddlCountryList.SelectedValue = objSDR["CountryId"].ToString();
                        State_FillDropDownList();
                    }
                    if (!objSDR["StateId"].Equals(DBNull.Value))
                    {
                        ddlStateList.SelectedValue = objSDR["StateId"].ToString();
                        City_FillDropDownList();
                    }
                    if (!objSDR["CityId"].Equals(DBNull.Value))
                    {
                        ddlCityList.SelectedValue = objSDR["CityId"].ToString();
                    }
                    if (!objSDR["ContactCategoryId"].Equals(DBNull.Value))
                    {
                        ddlContactCategoryList.SelectedValue = objSDR["ContactCategoryId"].ToString();
                    }
                    if (!objSDR["ContactName"].Equals(DBNull.Value))
                    {
                        txtContactName.Text = objSDR["ContactName"].ToString();
                    }
                    if (!objSDR["ContactNumber"].Equals(DBNull.Value))
                    {
                        txtContactNumber.Text = objSDR["ContactNumber"].ToString();
                    }
                    if (!objSDR["WhatsAppNumber"].Equals(DBNull.Value))
                    {
                        txtWhatsappNumber.Text = objSDR["WhatsAppNumber"].ToString();
                    }
                    if (!objSDR["BirthDate"].Equals(DBNull.Value))
                    {
                        txtBirthdate.Text = objSDR["BirthDate"].ToString();
                    }
                    if (!objSDR["Email"].Equals(DBNull.Value))
                    {
                        txtEmail.Text = objSDR["Email"].ToString();
                    }
                    if (!objSDR["Age"].Equals(DBNull.Value))
                    {
                        txtAge.Text = objSDR["Age"].ToString();
                    }
                    if (!objSDR["Address"].Equals(DBNull.Value))
                    {
                        txtAddress.Text = objSDR["Address"].ToString();
                    }
                    if (!objSDR["BloodGroup"].Equals(DBNull.Value))
                    {
                        txtBloodGroup.Text = objSDR["BloodGroup"].ToString();
                    }
                    if (!objSDR["FacebookID"].Equals(DBNull.Value))
                    {
                        txtFaceBookId.Text = objSDR["FacebookID"].ToString();
                    }
                    if (!objSDR["LinkedINID"].Equals(DBNull.Value))
                    {
                        txtLinkedinId.Text = objSDR["LinkedINID"].ToString();
                    }

                    break;
                }
            }
            else
            {
                lblMessage.Text = "Data Not Found";
            }

            #endregion Get the Data And Set To Controls



        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion FillControls

    #region Country_FillDropDownList
    private void Country_FillDropDownList()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiuserAddressBookConnectionString"].ConnectionString);
        try
        {
            #region Set ConnectionString and CommandObject
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_ForDropDownListByUserID";
            objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            #endregion Set ConnectionString and CommandObject

            #region Get the Data And Set to the Controls
            SqlDataReader objSDR = objCmd.ExecuteReader();
            ddlCountryList.DataSource = objSDR;
            ddlCountryList.DataValueField = "CountryId";
            ddlCountryList.DataTextField = "CountryName";
            ddlCountryList.DataBind();
            ddlCountryList.Items.Insert(0, new ListItem("Select Country", "-1"));
            #endregion Get the Data And Set to the Controls

        }
        catch(Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
       
    }
    #endregion Country_FillDropDownList

    #region State_FillDropDownList
    private void State_FillDropDownList()
    {
        #region Local Variable
        SqlInt32 strCountryId = SqlInt32.Null;
        strCountryId = Convert.ToInt32(ddlCountryList.SelectedValue);
        #endregion Local Variable

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiuserAddressBookConnectionString"].ConnectionString);
        try
        {
            #region Set ConnectionString and CommandObject
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_SelectByCountryIdUserId";
            objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            objCmd.Parameters.AddWithValue("CountryId", strCountryId);
            #endregion Set ConnectionString and CommandObject

            #region Get the Data And Set to the Controls
            SqlDataReader objSDR = objCmd.ExecuteReader();
            ddlStateList.DataSource = objSDR;
            ddlStateList.DataValueField = "StateId";
            ddlStateList.DataTextField = "StateName";
            ddlStateList.DataBind();
            ddlStateList.Items.Insert(0, new ListItem("Select State", "-1"));
            #endregion Get the Data And Set to the Controls
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion State_FillDropDownList

    #region City_FillDropDownList
    private void City_FillDropDownList()
    {

        #region Local Variables
        SqlInt32 strStateId = SqlInt32.Null;
        strStateId = Convert.ToInt32(ddlStateList.SelectedValue);
        #endregion Local Variables

        
         SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiuserAddressBookConnectionString"].ConnectionString);
        try
        {
            #region Set ConnectionString and CommandObject
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_City_SelectByStateIdUserID";
            objCmd.Parameters.AddWithValue("StateId", strStateId);
            objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            #endregion Set ConnectionString and CommandObject

            #region Get the Data And Set to the Controls
            SqlDataReader objSDR = objCmd.ExecuteReader();
            ddlCityList.DataSource = objSDR;
            ddlCityList.DataValueField = "CityId";
            ddlCityList.DataTextField = "CityName";
            ddlCityList.DataBind();
            ddlCityList.Items.Insert(0, new ListItem("Select City", "-1"));
            #endregion Get the Data And Set to the Controls
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }  

    }
    #endregion City_FillDropDownList

    #region ContactCategory_FillDropDownList
    private void ContactCategory_FillDropDownList()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiuserAddressBookConnectionString"].ConnectionString);
        try
        {
            #region Set ConnectionString and CommandObject
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactCategory_ForDropDownListByUserID";
            objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            #endregion Set ConnectionString and CommandObject

            #region Get the Data And Set to the Controls
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                ddlContactCategoryList.DataSource = objSDR;
                ddlContactCategoryList.DataValueField = "ContactCategoryId";
                ddlContactCategoryList.DataTextField = "ContactCategoryName";
                ddlContactCategoryList.DataBind();
                ddlContactCategoryList.Items.Insert(0, new ListItem("Select ContactCategory", "-1"));
            }
            #endregion Get the Data And Set to the Controls
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion ContactCategory_FillDropDownList

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variables

        SqlInt32 strCountryId = SqlInt32.Null;
        SqlInt32 strStateId = SqlInt32.Null;
        SqlInt32  strCityId = SqlInt32.Null;
        SqlInt32  strContactCategoryId = SqlInt32.Null;
        SqlString strContactName = SqlString.Null;
        SqlString strContactNumber = SqlString.Null;
        SqlString strWhatsappNumber = SqlString.Null;
        SqlDateTime strBirthDate = SqlDateTime.Null;
        SqlString strEmail = SqlString.Null;
        SqlInt32  strAge = SqlInt32.Null;
        SqlString strAddress = SqlString.Null;
        SqlString strBloodGroup = SqlString.Null;
        SqlString strFaceBookId = SqlString.Null;
        SqlString strLinkedinId = SqlString.Null;

        #endregion Local Variables


        #region Server Side VAlidation
        //Server Side VAlidation
        String strErrorMessage="";

        if (ddlCountryList.SelectedIndex == 0)
            strErrorMessage += "-Please Select Country<br>";

        if (ddlStateList.SelectedIndex == 0)
            strErrorMessage += "-Please Select State<br>";

        if (ddlCityList.SelectedIndex == 0)
            strErrorMessage += "-Please Select City<br>";

        if (ddlContactCategoryList.SelectedIndex == 0)
            strErrorMessage += "-Please Select ContactCategory<br>";

        if (txtContactName.Text.Trim()=="")
            strErrorMessage += "-Please Enter Name<br>";

        if (txtContactNumber.Text.Trim()=="")
            strErrorMessage += "-Please Enter ContactNumber<br>";

        //if (txtWhatsappNumber.Text.Trim() == "")
        //    strErrorMessage += "Please Enter WhatsappNumber"; ALLOW NULL FIELD

        if (txtBirthdate.Text.Trim() == "")
            strErrorMessage += "-Please Enter Birthdate<br>";

        if (txtEmail.Text.Trim() == "")
            strErrorMessage += "-Please Enter Email<br>";

        //if (txtAge.Text.Trim() == "")
        //    strErrorMessage += "Please Enter Age"; ALLOW NULL FIELD

        if (txtAddress.Text.Trim() == "")
            strErrorMessage += "-Please Enter Address<br>";

        if(strErrorMessage!="")
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = strErrorMessage;
            return;
        }

        #endregion Server Side VAlidation

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiuserAddressBookConnectionString"].ConnectionString);


        try
        {
        #region Gather Information

        //Gather Information of All SqlVariables

        if (ddlCountryList.SelectedIndex > 0)
            strCountryId = Convert.ToInt32(ddlCountryList.SelectedValue);

        if (ddlStateList .SelectedIndex > 0)
            strStateId = Convert.ToInt32(ddlStateList .SelectedValue);

        if (ddlCityList.SelectedIndex > 0)
            strCityId = Convert.ToInt32(ddlCityList.SelectedValue);

        if (ddlContactCategoryList.SelectedIndex > 0)
            strContactCategoryId = Convert.ToInt32(ddlContactCategoryList.SelectedValue);

        if (txtContactName.Text.Trim() != "")
            strContactName = txtContactName.Text.Trim();

        if (txtContactNumber.Text.Trim() != "")
            strContactNumber = txtContactNumber.Text.Trim();

        if (txtWhatsappNumber.Text.Trim() != "")
            strWhatsappNumber = txtWhatsappNumber.Text.Trim();

        if (txtBirthdate.Text.Trim() != "")
            strBirthDate = Convert.ToDateTime(txtBirthdate.Text.Trim());

        if (txtEmail.Text.Trim() != "")
            strEmail = txtEmail.Text.Trim();

        if (txtAge.Text.Trim() != "")
            strAge =Convert.ToInt32( txtAge.Text.Trim());

        if (txtAddress.Text.Trim() != "")
            strAddress = txtAddress.Text.Trim();

        if (txtBloodGroup.Text.Trim() != "")
            strBloodGroup = txtBloodGroup.Text.Trim();

        if (txtFaceBookId.Text.Trim() != "")
            strFaceBookId = txtFaceBookId.Text.Trim();

        if (txtLinkedinId.Text.Trim() != "")
            strLinkedinId = txtLinkedinId.Text.Trim();

        #endregion Gather Information

        

        
            #region Set ConnectionString and CommandObject
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("CountryId", strCountryId);
            objCmd.Parameters.AddWithValue("StateId", strStateId);
            objCmd.Parameters.AddWithValue("CityId", strCityId);
            objCmd.Parameters.AddWithValue("ContactCategoryId", strContactCategoryId);
            objCmd.Parameters.AddWithValue("ContactName", strContactName);
            objCmd.Parameters.AddWithValue("ContactNumber", strContactNumber);
            objCmd.Parameters.AddWithValue("WhatsappNumber", strWhatsappNumber);
            objCmd.Parameters.AddWithValue("BirthDate", strBirthDate);
            objCmd.Parameters.AddWithValue("Email", strEmail);
            objCmd.Parameters.AddWithValue("Age", strAge);
            objCmd.Parameters.AddWithValue("Address", strAddress);
            objCmd.Parameters.AddWithValue("BloodGroup", strBloodGroup);
            objCmd.Parameters.AddWithValue("FacebookId", strFaceBookId);
            objCmd.Parameters.AddWithValue("LinkedinId", strLinkedinId);
            objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            #endregion Set ConnectionString and CommandObject

            if(Request.QueryString["ContactId"]!=null)
            {
                #region Update Record
                objCmd.CommandText = "PR_Contact_UpdateByPkUserID";
                objCmd.Parameters.AddWithValue("ContactId", Request.QueryString["ContactId"].ToString().Trim());
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/Contact/ContactList.aspx");
                #endregion Update Record
            }
            else
            {
                #region Insert Record
                objCmd.CommandText = "PR_Contact_InsertByUserID";
                objCmd.ExecuteNonQuery();
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Contact Details Added Successfully";
                ddlCountryList.ClearSelection();
                ddlStateList.Items.Clear();
                ddlCityList.Items.Clear();
                ddlContactCategoryList.ClearSelection();
                txtContactName.Text = "";
                txtContactNumber.Text = "";
                txtWhatsappNumber.Text = "";
                txtAge.Text = "";
                txtAddress.Text = "";
                txtBloodGroup.Text = "";
                txtFaceBookId.Text = "";
                txtLinkedinId.Text = "";
                txtBirthdate.Text = "";
                txtEmail.Text = "";
                #endregion Insert Record
            }
            
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
       
    }
    #endregion Button : Save

    #region ddlCountryList_SelectedIndexChanged
    protected void ddlCountryList_SelectedIndexChanged(object sender, EventArgs e)
    {
        State_FillDropDownList();
        lblMessage.Text = "";
    }
    #endregion ddlCountryList_SelectedIndexChanged

    #region ddlStateList_SelectedIndexChanged
    protected void ddlStateList_SelectedIndexChanged(object sender, EventArgs e)
    {
        City_FillDropDownList();
    }
    #endregion ddlStateList_SelectedIndexChanged

}