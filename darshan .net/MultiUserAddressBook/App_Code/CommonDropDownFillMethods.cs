using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MultiUserAddressBook.App_Code
{
    public static class CommonDropDownFillMethods
    {
        #region FillDropDownListCountryByUserID
        public static void FillDropDownListCountryByUserID(DropDownList ddl, object UserID)
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiAddressBookConnectionString"].ConnectionString);

            try
            {
                #region Set Connection & Command Object
                if (sqlConn.State != ConnectionState.Open)
                    sqlConn.Open();

                SqlCommand objCmd = sqlConn.CreateCommand();

                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_Country_SelectForDropDownList";
                objCmd.Parameters.AddWithValue("@USerID", UserID);

                SqlDataReader objSDR = objCmd.ExecuteReader();
                #endregion Set Connection & Command Object
                if (objSDR.HasRows == true)
                {
                    ddl.DataSource = objSDR;
                    ddl.DataValueField = "CountryID";
                    ddl.DataTextField = "CountryName";
                    ddl.DataBind();
                }

                ddl.Items.Insert(0, new ListItem("Select Country", "-1"));

                sqlConn.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                sqlConn.Close();
            }
        }
        #endregion FillDropDownListCountryByUserID

        #region FillDropDownListStateyByUserID
        public static void FillDropDownListStateyByUserID(DropDownList ddl, DropDownList ddlc, object UserID)
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiAddressBookConnectionString"].ConnectionString);

            try
            {
                #region Set Connection & Command Object
                sqlConn.Open();

                SqlCommand objCmd = sqlConn.CreateCommand();

                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_State_SelectForDropDownListByCountryId";
                objCmd.Parameters.AddWithValue("@CountryID", ddlc.SelectedValue);
                objCmd.Parameters.AddWithValue("@UserID", UserID);

                SqlDataReader objSDR = objCmd.ExecuteReader();
                #endregion Set Connection & Command Object

                if (objSDR.HasRows == true)
                {
                    ddl.DataSource = objSDR;
                    ddl.Enabled = true;
                    ddl.DataValueField = "StateID";
                    ddl.DataTextField = "StateName";
                    ddl.DataBind();
                }

                ddl.Items.Insert(0, new ListItem("Select State", "-1"));

                sqlConn.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                sqlConn.Close();
            }
        }
        #endregion FillDropDownListStateyByUserID

        #region FillDropDownListCityByUserID
        public static void FillDropDownListCityByUserID(DropDownList ddl, DropDownList ddls, object UserID)
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiAddressBookConnectionString"].ConnectionString);

            try
            {
                #region Set Connection & Command Object
                sqlConn.Open();

                SqlCommand objCmd = sqlConn.CreateCommand();

                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_City_SelectForDropDownListByStateId";
                objCmd.Parameters.AddWithValue("@StateID", ddls.SelectedValue);
                objCmd.Parameters.AddWithValue("@UserID", UserID);
                SqlDataReader objSDR = objCmd.ExecuteReader();
                ddl.Items.Clear();
                #endregion Set Connection & Command Object
                if (objSDR.HasRows == true)
                {
                    ddl.DataSource = objSDR;
                    ddl.Enabled = true;
                    ddl.DataValueField = "CityID";
                    ddl.DataTextField = "CityName";
                    ddl.DataBind();
                }

                ddl.Items.Insert(0, new ListItem("Select City", "-1"));

                sqlConn.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                sqlConn.Close();
            }
        }
        #endregion FillDropDownListCityByUserID

        #region FillDropDownListContactCategoryByUserID
        public static void FillDropDownListContactCategoryByUserID(DropDownList ddl, object UserID)
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiAddressBookConnectionString"].ConnectionString);
            try
            {
                #region Set Connection & Command Object
                sqlConn.Open();

                SqlCommand objCmd = sqlConn.CreateCommand();

                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_ContactCategory_SelectForDropDownList";
                objCmd.Parameters.AddWithValue("@UserID", UserID);

                SqlDataReader objSDR = objCmd.ExecuteReader();
                #endregion Set Connection & Command Object
                if (objSDR.HasRows == true)
                {
                    ddl.DataSource = objSDR;
                    ddl.DataValueField = "ContactCategoryID";
                    ddl.DataTextField = "ContactCategoryName";
                    ddl.DataBind();
                }

                ddl.Items.Insert(0, new ListItem("Select Contact Category", "-1"));

                sqlConn.Close();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                sqlConn.Close();
            }
        }
        #endregion FillDropDownListContactCategoryByUserID
    }
}