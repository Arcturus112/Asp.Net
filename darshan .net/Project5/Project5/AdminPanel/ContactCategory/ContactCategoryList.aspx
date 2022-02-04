<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="ContactCategoryList.aspx.cs" Inherits="Project5.AdminPanel.ContactCategory.ContactCategoryList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h2>Contact Category List</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            Display The List Of Contact Category
            <asp:GridView ID="gvConCat" runat="server"></asp:GridView>
        </div>
    </div>
</asp:Content>
