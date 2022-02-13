<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="ContactCategoryAddEdit.aspx.cs" Inherits="AdminPanel_ContactCategory_ContactCategoryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">
   <div class="col-md-4 p-3 m-3 bg-warning">
        <h2 class="text-center text-white"><strong>ContactCategory AddEdit Page</strong></h2>
    </div>
    <table class="table table-secondary">
        <tr>
            <td class="text-center"><h5>ContactCategory Name</h5></td>
            <td>:</td>
            <td><asp:TextBox runat="server" ID="txtContactCategoryName" CssClass="form-control"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="3" class="text-center"><asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-danger" OnClick="btnSave_Click"  /></td>
        </tr>
        <tr>
            <td colspan="3" class="text-center"><asp:Label runat="server" ID="lblMessage"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

