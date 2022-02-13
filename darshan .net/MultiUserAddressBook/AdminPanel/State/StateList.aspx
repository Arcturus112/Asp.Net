<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="StateList.aspx.cs" Inherits="AdminPanel_State_StateList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">

    <div class="col-md-4 p-3 m-3 bg-primary">
        <h2 class="text-center text-white"><strong>StateList SelectAll</strong></h2>
    </div>
    <asp:Label runat="server" ID="lblMessage" EnableViewState="false"></asp:Label>
    <asp:GridView ID="gvStateList" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" OnRowCommand="gvStateList_RowCommand">
        <Columns>
            <asp:BoundField DataField="StateId" HeaderText="ID" />
            <asp:BoundField DataField="CountryName" HeaderText="Country" />
            <asp:BoundField DataField="StateName" HeaderText="State" />
            <asp:BoundField DataField="StateCode" HeaderText="Code" />
            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteState" CommandArgument='<%#Eval("StateId").ToString().Trim() %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Edit">
                <ItemTemplate>
                    <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" CssClass="btn btn-primary btn-sm" CommandName="EditState" NavigateUrl='<%# "~/AdminPanel/State/StateAddEdit.aspx?StateId=" + Eval("StateId") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

