<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListControls.aspx.cs" Inherits="Project4.ListControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:DropDownList ID="ddlCountry" runat="server"></asp:DropDownList>
            </div>
            <br />
            <div>
                <asp:Button ID="btnDisplayListCountry" runat="server" Text="Disply" OnClick="btnDisplayListCountry_Click" />
            </div>
            <br />
            <div>
                <asp:Label ID="lblListMassage" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
