﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.Master" AutoEventWireup="true" CodeBehind="CountryList.aspx.cs" Inherits="MultiUserAddressBook.AdminPanel.Country.CountryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h2>Country List</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="col-md-12">
                <asp:Label ID="lblMassage" runat="server" EnableViewState="false"></asp:Label>
            </div>
            <div class="m-3">
                <asp:HyperLink runat="server" ID="hlAddCountry" NavigateUrl="~/AdminPanel/Country/CountryAddEdit.aspx" CssClass="btn btn-dark">Add New Country</asp:HyperLink>
            </div>
            <div>
                <asp:GridView ID="gvCountry" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" OnRowCommand="gvCountry_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="btnDelete" CssClass="btn btn-danger" CommandName="DeleteRecord" OnClientClick="return confirm('Are you Sure You Want to Delete.');" CommandArgument='<%# Eval("CountryID") %>'><i class="fa-solid fa-trash"></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlEdit" runat="server" Target="_blank" CssClass="btn btn-dark" NavigateUrl='<%# "~/AdminPanel/Country/CountryAddEdit.aspx?CountryID=" + Eval("CountryID") %>'><i class="fa-solid fa-pen-to-square"></i></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CountryName" HeaderText="Country Name" />
                        <asp:BoundField DataField="CountryCode" HeaderText="Country Code" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
