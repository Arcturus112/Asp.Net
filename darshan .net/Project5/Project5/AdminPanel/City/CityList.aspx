<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="CityList.aspx.cs" Inherits="Project5.AdminPanel.City.CityList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h2>City List</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            Display The List Of City
            <asp:GridView ID="gvCity" runat="server"></asp:GridView>
        </div>
    </div>
</asp:Content>
