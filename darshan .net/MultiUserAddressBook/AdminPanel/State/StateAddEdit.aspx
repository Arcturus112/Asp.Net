<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.Master" AutoEventWireup="true" CodeBehind="StateAddEdit.aspx.cs" Inherits="MultiUserAddressBook.AdminPanel.State.StateAddEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h2>State Add Edit Page</h2>
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
                    State Name :
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtStateName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row m-3">
                <div class="col-md-4">
                    State Code :
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtStateCode" runat="server" CssClass="form-control" placeholder="EX: GJ For Gujarat"></asp:TextBox>
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
