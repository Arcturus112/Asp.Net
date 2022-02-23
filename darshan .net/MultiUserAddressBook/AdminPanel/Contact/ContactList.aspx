<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.Master" AutoEventWireup="true" CodeBehind="ContactList.aspx.cs" Inherits="MultiUserAddressBook.AdminPanel.Contact.ContactList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h2>Contact List</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label ID="lblMassage" runat="server" EnableViewState="false"></asp:Label>
        </div>
        <div class="m-3">
            <asp:HyperLink runat="server" ID="hlAddContact" NavigateUrl="~/AdminPanel/Contact/ContactAddEdit.aspx" CssClass="btn btn-dark">Add New Contact</asp:HyperLink>
        </div>
        <div class="col-md-12" style="width: 100%; height: 100%; overflow: scroll">
            <asp:GridView ID="gvContact" runat="server" CssClass="table table-hover" OnRowCommand="gvContact_RowCommand" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactID") %>'><i class="fa-solid fa-trash"></i></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink ID="hlEdit" runat="server" Target="_blank" CssClass="btn btn-dark" NavigateUrl='<%# "~/AdminPanel/Contact/ContactAddEdit.aspx?ContactID=" + Eval("ContactID") %>'><i class="fa-solid fa-pen-to-square"></i></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ContactID" HeaderText="ContactID" />
                    <asp:BoundField DataField="CountryName" HeaderText="CountryName"  />
                    <asp:BoundField DataField="StateName" HeaderText="StateName"  />
                    <asp:BoundField DataField="CityName" HeaderText="CityName"  />
                    <asp:BoundField DataField="ContactCategoryName" HeaderText="ContactCategoryName"  />
                    <asp:BoundField DataField="ContactName" HeaderText="ContactName"  />
                    <asp:BoundField DataField="ContactNo" HeaderText="ContactNo"  />
                    <asp:BoundField DataField="WhatsAppNo" HeaderText="WhatsAppNo"  />
                    <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" DataFormatString="{0:MM-dd-yyyy}"/>
                    <asp:BoundField DataField="Email" HeaderText="Email"  />
                    <asp:BoundField DataField="Age" HeaderText="Age"  />
                    <asp:BoundField DataField="Address" HeaderText="Address"  />
                    <asp:BoundField DataField="BloodGroup" HeaderText="BloodGroup"  />
                    <asp:BoundField DataField="FacebookID" HeaderText="FacebookID"  />
                    <asp:BoundField DataField="LinkedINID" HeaderText="LinkedinID"  />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
