<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="ContactAddEdit.aspx.cs" Inherits="Project5.AdminPanel.Contact.ContactAddEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h2>Contact Add Edit Page</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label ID="lblMassage" runat="server" EnableViewState="false"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="row m-3">
                <div class="col-md-4">
                    Country :
                </div>
                <div class="col-md-8">
                    <asp:DropDownList ID="ddlCountryID" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>

            <div class="row m-3">
                <div class="col-md-4">
                    State :
                </div>
                <div class="col-md-8">
                    <asp:DropDownList ID="ddlStateID" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>

            <div class="row m-3">
                <div class="col-md-4">
                    City :
                </div>
                <div class="col-md-8">
                    <asp:DropDownList ID="ddlCityID" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>

            <div class="row m-3">
                <div class="col-md-4">
                    Contact Category :
                </div>
                <div class="col-md-8">
                    <asp:DropDownList ID="ddlContactCategoryID" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>

            <div class="row m-3">
                <div class="col-md-4">
                    Contact Name :
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtContactName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row m-3">
                <div class="col-md-4">
                    Contact No :
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtContactNo" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row m-3">
                <div class="col-md-4">
                    WhatsApp No :
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtWhatsAppNo" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row m-3">
                <div class="col-md-4">
                    BirthDate :
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtBirthDate" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row m-3">
                <div class="col-md-4">
                    Email :
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row m-3">
                <div class="col-md-4">
                    Age :
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtAge" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row m-3">
                <div class="col-md-4">
                    Address :
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row m-3">
                <div class="col-md-4">
                    BloodGroup :
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtBloodGroup" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row m-3">
                <div class="col-md-4">
                    Facebook ID :
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtFacebookID" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row m-3">
                <div class="col-md-4">
                    LinkedinID :
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtLinkedinID" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row m-3">
                <div class="col-md-12 m-5 d-flex justify-content-center">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-dark" OnClick="btnSave_Click"/>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn-danger m-2" OnClick="btnCancel_Click1"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
