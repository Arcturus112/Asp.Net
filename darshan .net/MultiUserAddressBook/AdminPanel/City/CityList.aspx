<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="CityList.aspx.cs" Inherits="AdminPanel_City_CityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">
    <div class="col-md-4 p-3 m-3 bg-success">
        <h2 class="text-center text-white"><strong>CityList SelectAll</strong></h2>
    </div>
    <asp:Label runat="server" ID="lblMessage" EnableViewState="false"></asp:Label>
    <asp:GridView runat="server" ID="gvCountrylist" AutoGenerateColumns="false" OnRowCommand ="gvCountrylist_RowCommand" >
            <Columns>
                <asp:BoundField DataField="Cityid" HeaderText ="ID" />
                <asp:BoundField DataField="CountryName" HeaderText ="Country" />
                <asp:BoundField DataField="StateName" HeaderText ="State" />
                <asp:BoundField DataField="CityName" HeaderText ="City" />
                <asp:BoundField DataField="STDCode" HeaderText ="STD" />
                <asp:BoundField DataField="PinCode" HeaderText ="PINCODE" />

                <asp:TemplateField HeaderText="DELETE">
                    <ItemTemplate>
                        <asp:Button runat="server" ID="btnDelete" CssClass ="btn btn-danger btn-sm" Text="Delete" CommandName="DeleteCity" CommandArgument='<%# Eval("CityId") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="EDIT">
                    <ItemTemplate>
                        <asp:HyperLink  runat="server" ID="btnEdit" CssClass ="btn btn-primary btn-sm" Text="Edit" CommandName="UpdateCity" NavigateUrl='<%# "~/AdminPanel/City/CityAddEdit.aspx?Cityid=" + Eval("CityId") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        
    </asp:GridView>
    
</asp:Content>

