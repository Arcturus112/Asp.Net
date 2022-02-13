﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.Master" AutoEventWireup="true" CodeBehind="CityList.aspx.cs" Inherits="Project5.AdminPanel.City.CityList" %>
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
            <div class="col-md-12">
                <asp:Label ID="lblMassage" runat="server" EnableViewState="false"></asp:Label>
            </div>
            <div class="m-3">
                <asp:HyperLink runat="server" ID="hlAddCity" NavigateUrl="~/AdminPanel/City/CityAddEdit.aspx" CssClass="btn btn-dark">Add New City</asp:HyperLink>
            </div>
            <div>
                <asp:GridView ID="gvCity" runat="server" CssClass="table table-hover" OnRowCommand="gvCity_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument= '<%# Eval("CityID") %>' ><i class="fa-solid fa-trash"></i></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlEdit" runat="server" Target="_blank" CssClass="btn btn-dark" NavigateUrl='<%# "~/AdminPanel/City/CityAddEdit.aspx?CityID=" + Eval("CityID") %>'><i class="fa-solid fa-pen-to-square"></i></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
