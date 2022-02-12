<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="ContactList.aspx.cs" Inherits="Project5.AdminPanel.Contact.ContactList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h2>Contact List</h2>
        </div>
    </div>
    <div class="row">
        Display The List Of Contact
        <div class="col-md-12" style="width: 100%; height: 100%; overflow: scroll">
            <asp:GridView ID="gvContact" runat="server"></asp:GridView>
        </div>
    </div>
</asp:Content>
