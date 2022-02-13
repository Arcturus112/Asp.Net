<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="CountryList.aspx.cs" Inherits="AdminPanel_Country_CountryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">

    <div class="col-md-4 p-3 m-3 bg-danger">
        <h2 class="text-center text-white"><strong>CountryList SelectAll</strong></h2>
    </div>

    <asp:Label ID="lblMessage" runat="server" EnableViewState="false"></asp:Label>

    <asp:GridView runat="server" ID="gvCountryList" CssClass="table table-hover " AutoGenerateColumns="false" OnRowCommand="gvCountryList_RowCommand">
        <Columns>
            <asp:BoundField DataField="CountryId" HeaderText="ID" />
            <asp:BoundField DataField="CountryName" HeaderText="Country" />
            <asp:BoundField DataField="CountryCode" HeaderText="Code" />

            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument='<%#Eval("CountryId")%>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Edit">
                <ItemTemplate>
                    <asp:HyperLink ID="hlEdit" runat="server" Text="Edit" CssClass="btn btn-primary btn-sm" CommandName="EditRecord" NavigateUrl='<%# "~/AdminPanel/Country/CountryAddEdit.aspx?CountryId=" + Eval("CountryId") %>' />
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>

</asp:Content>

