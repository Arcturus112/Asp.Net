<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="ContactCategoryAddEdit.aspx.cs" Inherits="Project5.AdminPanel.ContactCategory.ContactCategoryAddEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h2>Contact Category Add Edit Page</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label ID="lblMassage" runat="server" EnableViewState="false"></asp:Label>
        </div>
    </div>

    <div class="row m-2">
        <div class="col-md-4">
            Contact Category Name :
        </div>
        <div class="col-md-8">
            <asp:TextBox ID="txtContactCategoryName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
  
    <div class="row">
        <div class="col-md-12 d-flex justify-content-center m-5">
            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-dark m-2" OnClick="btnSave_Click"/>
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn-danger m-2" OnClick="btnCancel_Click"/>
        </div>
    </div>
</asp:Content>
