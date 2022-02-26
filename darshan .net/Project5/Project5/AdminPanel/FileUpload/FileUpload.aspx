<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUpload.aspx.cs" Inherits="Project5.AdminPanel.File_Uplode.FileUplode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Content/CSS/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../../Content/CSS/bootstrap.min.css" rel="stylesheet" />
    <script src="../../Content/JS/jquery-3.1.1.slim.min.js"></script>
    
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="m-5 col-md-12">
                    <div class="custom-file m-2">
                        <asp:FileUpload ID="fuFile" runat="server" CssClass="custom-file-input" />
                        <label class="custom-file-label" for="fuFile">Choose a file</label>
                        <small style="font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; color:red">Note : Max 50MB Content File Is Allowed</small>
                    </div>
                    <div class="m-2">
                        <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="btn btn-dark" OnClick="btnUpload_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click" /><br />
                        <asp:Label ID="lblMassage" runat="server" CssClass="form-label"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    <script src="../../Content/JS/bootstrap.bundle.min.js"></script>
    <script src="../../Content/JS/Custom.js"></script>

    </form>
    
</body>
</html>
