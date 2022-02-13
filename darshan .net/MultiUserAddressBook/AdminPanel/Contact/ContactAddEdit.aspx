<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="ContactAddEdit.aspx.cs" Inherits="AdminPanel_Contact_ContactAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">
    <div class="col-md-4 p-3 m-3 bg-secondary">
        <h2 class="text-center text-white"><strong>Contact AddEdit Page</strong></h2>
    </div>
    
    <table class="table table-secondary">

        
        <tr>
            <td colspan="4" class="text-center"><asp:Label runat="server" ID="lblMessage"></asp:Label></td>

        </tr>
        <tr>
            <td class="text-center"><h5>Select Country</h5></td>
            <td><h5>:</h5></td>
            <td><asp:DropDownList runat="server" ID="ddlCountryList" AutoPostBack="true"  CssClass="form-select" OnSelectedIndexChanged="ddlCountryList_SelectedIndexChanged"></asp:DropDownList></td>
            <td>
                <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCountryList" Display="Dynamic" ErrorMessage="Select Country" ForeColor="#FF3300" InitialValue="-1" ValidationGroup="ContactForm"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="text-center"><h5>Select State</h5></td>
            <td><h5>:</h5></td>
            <td><asp:DropDownList runat="server" ID="ddlStateList" AutoPostBack="true"  CssClass="form-select" OnSelectedIndexChanged="ddlStateList_SelectedIndexChanged"></asp:DropDownList></td>
            <td>
                <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="ddlStateList" ErrorMessage="Select State" ForeColor="Red" InitialValue="-1" ValidationGroup="ContactForm"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="text-center"><h5>Select City</h5></td>
            <td><h5>:</h5></td>
            <td><asp:DropDownList runat="server" ID="ddlCityList"  CssClass="form-select"></asp:DropDownList></td>
            <td>
                <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="ddlCityList" ErrorMessage="Select City" ForeColor="Red" InitialValue="-1" ValidationGroup="ContactForm"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="text-center"><h5>Select ContactCategoryId</h5></td>
            <td><h5>:</h5></td>
            <td><asp:DropDownList runat="server" ID="ddlContactCategoryList" CssClass="form-select"></asp:DropDownList></td>
            <td>
                <asp:RequiredFieldValidator ID="rfvContactCategory" runat="server" ControlToValidate="ddlContactCategoryList" ErrorMessage="Select ContactCategory" ForeColor="Red" InitialValue="-1" ValidationGroup="ContactForm"></asp:RequiredFieldValidator>
            </td>

        </tr>
        <tr>
            <td class="text-center"><h5>Enter ContactName</h5></td>
            <td><h5>:</h5></td>
            <td><asp:TextBox runat="server" ID="txtContactName"  CssClass="form-control"></asp:TextBox></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-center"><h5>Enter Contact Number</h5></td>
            <td><h5>:</h5></td>
            <td><asp:TextBox runat="server" ID="txtContactNumber" CssClass="form-control" ></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="rfvContactNo" runat="server" ControlToValidate="txtContactNumber" ErrorMessage="Enter ContactNo" ForeColor="Red" ValidationGroup="ContactForm"></asp:RequiredFieldValidator>
&nbsp;<asp:RegularExpressionValidator ID="revContactNo" runat="server" ControlToValidate="txtContactNumber" ErrorMessage="incorrect ContactNo" ForeColor="#FF3300" ValidationExpression="^[789][0-9]{9}$" ValidationGroup="ContactNo"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="text-center"><h5>Enter Whatsapp Number</h5></td>
            <td><h5>:</h5></td>
            <td><asp:TextBox runat="server" ID="txtWhatsappNumber" CssClass="form-control" ></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td class="text-center"><h5>Enter BirthDate</h5></td>
            <td><h5>:</h5></td>
            <td><asp:TextBox runat="server" ID="txtBirthdate" CssClass="form-control"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td class="text-center"><h5>Enter Email</h5></td>
            <td><h5>:</h5></td>
            <td><asp:TextBox runat="server" ID="txtEmail" CssClass="form-control"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td class="text-center"><h5>Enter Age</h5></td>
            <td><h5>:</h5></td>
            <td><asp:TextBox runat="server" ID="txtAge" CssClass="form-control"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td class="text-center"><h5>Enter Address</h5></td>
            <td><h5>:</h5></td>
            <td><asp:TextBox runat="server" ID="txtAddress" CssClass="form-control"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td class="text-center"><h5>Enter BloodGroup</h5></td>
            <td><h5>:</h5></td>
            <td><asp:TextBox runat="server" ID="txtBloodGroup" CssClass="form-control"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td class="text-center"><h5>Enter LinkedinId</h5></td>
            <td><h5>:</h5></td>
            <td><asp:TextBox runat="server" ID="txtLinkedinId" CssClass="form-control"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td class="text-center"><h5>Enter FaceBookId</h5></td>
            <td><h5>:</h5></td>
            <td><asp:TextBox runat="server" ID="txtFaceBookId" CssClass="form-control"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="3" class="text-center"><asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-danger" OnClick="btnSave_Click" ValidationGroup="ContactForm"/></td>
        </tr>
        
            

        
    </table>
</asp:Content>

