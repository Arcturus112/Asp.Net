<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListControls.aspx.cs" Inherits="Project4.ListControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="margin : 30px">
                <tr>
                    <td>Country Name:</td>
                    <td><asp:TextBox ID="txtCountryName" class="form-control" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvCountryName" runat="server" ControlToValidate="txtCountryName" CssClass="alert" Display="Dynamic" EnableViewState="False" ErrorMessage="Enter Country Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Country Code:</td>
                    <td><asp:TextBox ID="txtCountryCode" class="form-control" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:RangeValidator ID="rvCountryCode" runat="server" ControlToValidate="txtCountryCode" CssClass="alert" Display="Dynamic" EnableViewState="False" ErrorMessage="Enter Country Code" MaximumValue="999" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                    </td>
                </tr>
                <tr class="text-center">
                    <td><asp:Button ID="btnAddItem" runat="server" Text="Add" OnClick="btnAddItem_Click" Width="74px" /></td>
                    <td><asp:Button ID="btnRemoveItem" runat="server" Text="Remove" OnClick="btnRemoveItem_Click"/></td>
                </tr>
            </table>
            <hr />
            <table style="margin : 30px">
                <tr class="dropdown">
                    <td><asp:DropDownList class="btn btn-secondary dropdown-toggle" ID="ddlCountry" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td><asp:Button ID="btnDisplayListCountry" runat="server" Text="Disply" OnClick="btnDisplayListCountry_Click" /></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblListMassage" runat="server" EnableViewState="False"></asp:Label></td>
                </tr>
            </table>
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
</body>
</html>
