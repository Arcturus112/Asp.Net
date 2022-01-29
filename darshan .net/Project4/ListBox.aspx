<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListBox.aspx.cs" Inherits="Project4.ListBox" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous"/>
</head>
<body>
    <form id="form1" runat="server">
        <table style="margin: 30px">
            <tr>
                <td>New Country Name:</td>
                <td>
                    <asp:TextBox ID="txtCountryName" class="form-control" runat="server"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvCountryName" runat="server" ControlToValidate="txtCountryName" CssClass="alert" Display="Dynamic" EnableViewState="False" ErrorMessage="Enter Country Name"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>New Country Code:</td>
                <td>
                    <asp:TextBox ID="txtCountryCode" class="form-control" runat="server"></asp:TextBox></td>
                <td>
                    <asp:RangeValidator ID="rvCountryCode" runat="server" ControlToValidate="txtCountryCode" CssClass="alert" Display="Dynamic" EnableViewState="False" ErrorMessage="Enter Country Code" MaximumValue="999" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td>Old Country Name:</td>
                <td>
                    <asp:TextBox ID="txtOldCountryName" class="form-control" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Old Country Code:</td>
                <td>
                    <asp:TextBox ID="txtOldCountryCode" class="form-control" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="text-center">
                <td>
                    <asp:Button ID="btnAddItem" runat="server" Text="Add" OnClick="btnAddItem_Click" Width="74px" /></td>
                <td>
                    <asp:Button ID="btnRemoveItem" runat="server" Text="Remove" OnClick="btnRemoveItem_Click" /></td>
                <td>
                    <asp:Button ID="btnUpdateItem" runat="server" Text="Update" OnClick="btnUpdateItem_Click"/></td>
            </tr>
        </table>
        <table style="margin: 30px">
            <tr>
                <td>
                    <asp:ListBox ID="lstBox1" runat="server" SelectionMode="Multiple">
                        <asp:ListItem Value="91">India</asp:ListItem>
                        <asp:ListItem Value="92">China</asp:ListItem>
                        <asp:ListItem Value="93">Srilanka</asp:ListItem>
                        <asp:ListItem Value="94">Bangladesh</asp:ListItem>
                        <asp:ListItem Value="95">Nepal</asp:ListItem>
                        <asp:ListItem Value="96">USA</asp:ListItem>
                    </asp:ListBox>
                </td>
                <td>
                    <asp:Button ID="btn1" runat="server" Text=">" OnClick="btn1_Click" Width="30px"/><br />
                    <asp:Button ID="btn2" runat="server" Text=">>" OnClick="btn2_Click"/><br />
                    <asp:Button ID="btn3" runat="server" Text="<" Width="30px" OnClick="btn3_Click"/><br />
                    <asp:Button ID="btn4" runat="server" Text="<<" OnClick="btn4_Click"/><br />
                </td>
                <td>
                    <asp:ListBox ID="lstBox2" runat="server" SelectionMode="Multiple">

                    </asp:ListBox>
                </td>
            </tr>
        </table>

        <div style="margin: 30px">
            <div>
                <asp:Button ID="btnListButton" runat="server" Text="Disply" OnClick="btnListButton_Click" />
            </div>
            <div>
                <asp:Label ID="lblLList" runat="server" EnableViewState="False"></asp:Label>
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
</body>
</html>
