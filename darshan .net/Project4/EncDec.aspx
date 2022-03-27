<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EncDec.aspx.cs" Inherits="Project4.EncDec" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:TextBox ID="txtEnc" runat="server"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Button ID="btnEnc" runat="server" Text="Encrypt" OnClick="btnEnc_Click" />
            </div>
            <br />
            <div>
                <asp:Label ID="lblEnc" runat="server"></asp:Label>
            </div>
        </div>
        <br />
        <br />
        <br />

        <div>
            <div>
                <asp:TextBox ID="txtDec" runat="server"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Button ID="btnDec" runat="server" Text="Decrypt" OnClick="btnDec_Click" />
            </div>
            <br />
            <div>
                <asp:Label ID="lblDec" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
