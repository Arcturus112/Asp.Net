<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculotar.aspx.cs" Inherits="myFirstProject.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #btnEnter, #btnReset{
            display: block;
            margin: auto;
        }
        .auto-style1 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
            <h1>Calculotar</h1>
            <table>
                <tr>
                    <td class="auto-style1">
                        Enter First Number:
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtFirstNo" runat="server" Width="175px"></asp:TextBox>
                    </td>
                    <td class="auto-style1">
                        <asp:Label ID="lblMassage1" runat="server"></asp:Label>
                        <asp:RangeValidator ID="rvFirstNumber" runat="server" ControlToValidate="txtFirstNo" Display="Dynamic" ErrorMessage="Only Number Allowed" MaximumValue="10000000" MinimumValue="0" Type="Double"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Enter Operator:
                    </td>
                    <td>
                        <asp:TextBox ID="txtOperator" runat="server" Width="175px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblMassage2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Enter Second Number:
                    </td>
                    <td>
                        <asp:TextBox ID="txtSecondNo" runat="server" Width="175px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblMassage3" runat="server"></asp:Label>
                        <asp:RangeValidator ID="rvSecondNumber" runat="server" ControlToValidate="txtSecondNo" Display="Dynamic" ErrorMessage="Only Number Allowed" MaximumValue="10000000" MinimumValue="0" Type="Double"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnEnter" runat="server" Text="Enter" Width="138px" OnClick="btnEnter_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Answer:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAnswer" runat="server" Width="175px" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblAnswer" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="Clear" Width="138px" />
                    </td>
                </tr>
            </table>
    </form>
</body>
</html>
