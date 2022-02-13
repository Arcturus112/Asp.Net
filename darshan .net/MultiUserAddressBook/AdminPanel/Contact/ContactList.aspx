<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="ContactList.aspx.cs" Inherits="AdminPanel_Contact_Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">
    <div class="col-md-4 p-3 m-3 bg-secondary">
        <h2 class="text-center text-white"><strong>ContactList SelectAll</strong></h2>
    </div>
    <asp:Label runat="server" ID="lblMessage"></asp:Label>

    <asp:GridView runat="server" ID="gvContact" OnRowCommand="gvContact_RowCommand" >
         <Columns>
                 <asp:BoundField HeaderText="ID" DataField="ContactID" />
                 <asp:BoundField HeaderText="Country" DataField="CountryName" />
                 <asp:BoundField HeaderText="State" DataField="StateName" />
                 <asp:BoundField HeaderText="City" DataField="CityName" />
                 <asp:BoundField HeaderText="ContactCategory" DataField="ContactCategoryName"  /> 
                 <asp:BoundField HeaderText="Name" DataField="ContactName" />
                 <asp:BoundField HeaderText="Number" DataField="ContactNumber" />
                 <asp:BoundField HeaderText="Whtsapp" DataField="WhatsAppNumber" />
                 <asp:BoundField HeaderText="BDate" DataField="BirthDate" />
                 <asp:BoundField HeaderText="E-mail" DataField="Email" />
                 <asp:BoundField HeaderText="Age" DataField="Age" />
                 <asp:BoundField HeaderText="Address" DataField="Address" />
                 <asp:BoundField HeaderText="Creation Date" DataField="CreationDate" />

            <asp:TemplateField HeaderText="DELETE">
                <ItemTemplate>
                    <asp:Button runat="server" ID="btnDelete" CssClass ="btn btn-danger btn-sm" Text="Delete" CommandName="DeleteContact" CommandArgument='<%# Eval("ContactId") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="EDIT">
                <ItemTemplate>
                    <asp:HyperLink runat="server" ID="btnEdit" CssClass ="btn btn-primary btn-sm" Text="Edit" NavigateUrl='<%# "~/AdminPanel/Contact/ContactAddEdit.aspx?ContactId="+ Eval("ContactId") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

