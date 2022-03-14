<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.Master" AutoEventWireup="true" CodeBehind="StateList.aspx.cs" Inherits="MultiUserAddressBook.AdminPanel.State.StateList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h2>State List</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label runat="server" ID="lblMassage" EnableViewState="false"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="m-3">
            <asp:HyperLink runat="server" ID="hlAddCState" NavigateUrl="~/AdminPanel/State/StateAddEdit.aspx" CssClass="btn btn-dark">Add New State</asp:HyperLink>
        </div>
        <div class="col-md-12">
            <asp:GridView ID="gvState" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" OnRowCommand="gvState_RowCommand">
                <Columns>

                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Are you Sure You Want to Delete.');" CommandName="DeleteRecord" CommandArgument='<%# Eval("StateID") %>'><i class="fa-solid fa-trash"></i></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink ID="hlEdit" runat="server" Target="_blank" CssClass="btn btn-dark" NavigateUrl='<%# "~/AdminPanel/State/StateAddEdit.aspx?StateID=" + Eval("StateID") %>'><i class="fa-solid fa-pen-to-square"></i></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CountryName" HeaderText="Country" />
                    <asp:BoundField DataField="StateName" HeaderText="State" />
                    <asp:BoundField DataField="StateCode" HeaderText="Code" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
