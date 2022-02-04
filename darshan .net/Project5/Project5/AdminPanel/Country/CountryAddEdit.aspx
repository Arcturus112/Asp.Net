<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="CountryAddEdit.aspx.cs" Inherits="Project5.AdminPanel.Country.CountryAddEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h2>Country Add Edit Page</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label ID="lblMassage" runat="server" EnableViewState="false"></asp:Label>
        </div>
    </div>
    <div class="row m-2">
        <div class="col-md-4">
            Country Name :
        </div>
        <div class="col-md-8">
            <asp:TextBox ID="txtCountryName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row m-2">
        <div class="col-md-4">
            Country Code :
        </div>
        <div class="col-md-8">
            <asp:TextBox ID="txtCountryCode" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12 d-flex justify-content-center m-5">
            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-dark" OnClick="btnSave_Click" />
        </div>
    </div>
</asp:Content>
