<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.Master" AutoEventWireup="true" CodeBehind="CityAddEdit.aspx.cs" Inherits="MultiUserAddressBook.AdminPanel.City.CityAddEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h2>City Add Edit Page</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label ID="lblMassage" runat="server" EnableViewState="False"></asp:Label>
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
                    <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="txtCityName" Display="Dynamic" ErrorMessage="Enter City Name" ForeColor="Red"></asp:RequiredFieldValidator>
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
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-dark m-2" OnClick="btnSave_Click"/>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
