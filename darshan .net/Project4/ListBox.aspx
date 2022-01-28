<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListBox.aspx.cs" Inherits="Project4.ListBox" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <table style="margin: 30px">
            <tr>
                <td>
                    <asp:ListBox ID="lstbCountry" runat="server" SelectionMode="Multiple">
                        <asp:ListItem Value="91">India</asp:ListItem>
                        <asp:ListItem Value="92">China</asp:ListItem>
                        <asp:ListItem Value="93">Srilanka</asp:ListItem>
                        <asp:ListItem Value="94">Bangladesh</asp:ListItem>
                        <asp:ListItem Value="95">Nepal</asp:ListItem>
                        <asp:ListItem Value="96">USA</asp:ListItem>
                    </asp:ListBox>
                </td>
                <td>
                    <asp:Button ID="btn1" runat="server" Text=">"/><br />
                    <asp:Button ID="btn2" runat="server" Text=">>"/><br />
                    <asp:Button ID="btn3" runat="server" Text="<"/><br />
                    <asp:Button ID="btn4" runat="server" Text="<<"/><br />
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
</body>
</html>
