<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="StateList.aspx.cs" Inherits="Project5.AdminPanel.State.StateList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h2>State List</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            Display The List Of State
            <asp:GridView ID="gvState" runat="server"></asp:GridView>
        </div>
    </div>
</asp:Content>
