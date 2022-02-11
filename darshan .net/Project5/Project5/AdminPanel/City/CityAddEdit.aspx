<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="CityAddEdit.aspx.cs" Inherits="Project5.AdminPanel.City.CityAddEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h2>City Add Edit Page</h2>
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
                    State :
                </div>
                <div class="col-md-8">
                    <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>

            <div class="row m-3">
                <div class="col-md-4">
                    City Name :
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtCityName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row m-3">
                <div class="col-md-4">
                    STD Code :
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtSTDCode" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row m-3">
                <div class="col-md-4">
                    Pin Code :
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtPinCode" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row m-3">
                <div class="col-md-4">

                </div>
                <div class="col-md-8">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-dark" OnClick="btnSave_Click"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
