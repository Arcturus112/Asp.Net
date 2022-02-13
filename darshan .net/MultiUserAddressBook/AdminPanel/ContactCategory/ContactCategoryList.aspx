<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="ContactCategoryList.aspx.cs" Inherits="AdminPanel_ContactCategory_ContactCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">
    <div class="col-md-4 p-3 m-3 bg-warning">
        <h2 class="text-center text-white"><strong>ContactCategoryList SelectAll</strong></h2>
    </div>
    <asp:Label runat="server" ID="lblMessage"></asp:Label>
    <asp:GridView ID="gvContactCategoryList" runat="server" OnRowCommand="gvContactCategoryList_RowCommand" >
         <Columns>

            <asp:BoundField DataField="ContactCategoryId" HeaderText ="ID" />
            <asp:BoundField DataField="ContactCategoryName" HeaderText ="Name" />
            

            <asp:TemplateField HeaderText="DELETE">
                <ItemTemplate>
                    <asp:Button runat="server" ID="btnDelete" CssClass ="btn btn-danger btn-sm" Text="Delete" CommandName="DeleteContactCategory" CommandArgument='<%# Eval("ContactCategoryId") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="EDIT">
                <ItemTemplate>
                    <asp:Button runat="server" ID="btnEdit" CssClass ="btn btn-primary btn-sm" Text="Edit" CommandName="EditContactCategory" PostBackUrl='<%# "~/AdminPanel/ContactCategory/ContactCategoryAddEdit.aspx?ContactCategoryid=" + Eval("ContactCategoryId") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

