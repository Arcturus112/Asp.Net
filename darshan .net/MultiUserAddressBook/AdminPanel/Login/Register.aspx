<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MultiUserAddressBook.AdminPanel.Login.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Content/Css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../../Content/Css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/Css/Custom.css" rel="stylesheet" />
    <link href="../../Content/Css/SignUP.css" rel="stylesheet" />
    <%--<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>--%>
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" />
    <link href="https://fonts.googleapis.com/css2?family=Bad+Script&display=swap" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/4.1.1/animate.min.css" />
</head>
<body>
    <section class="login bg-light">
        <div class="container center-login">
            <div class="row d-flex justify-content-center" style="background-color:lightgray;">
                <div class="col-lg-7 text-center py-3">
                    <h1>Register</h1>
                    <asp:Label ID="lblMassage" runat="server" ForeColor="Red"></asp:Label>
                    <form runat="server">
                        <div class="form-row py-2 pt-5">
                            <div class="offset-1 col-lg-10">
                                <asp:TextBox ID="txtUsername" runat="server" CssClass="inp px-3" placeholder="Username*"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row py-3">
                            <div class="offset-1 col-lg-10">
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="inp px-3" placeholder="Password*"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row py-3">
                            <div class="offset-1 col-lg-10">
                                <asp:TextBox ID="txtContactno" runat="server" CssClass="inp px-3" placeholder="Mobile No*"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row py-3">
                            <div class="offset-1 col-lg-10">
                                <asp:TextBox ID="txtDisplayName" runat="server" CssClass="inp px-3" placeholder="DisplayName*"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row py-3">
                            <div class="offset-1 col-lg-10">
                                <asp:TextBox ID="txtEmail" runat="server" type="Email" CssClass="inp px-3" placeholder="Email"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row py-3">
                            <div class="offset-1 col-lg-10">
                                <asp:Button ID="btnSignUP" CssClass="btn2" runat="server" Text="Sign UP" OnClick="btnSignUP_Click"/>
                            </div>
                        </div>
                    </form>
                    <p class="mb-5 pb-lg-2">already have an account? <asp:HyperLink ID="hlRegister" runat="server" NavigateUrl="~/AdminPanel/Login/Login.aspx">Login here</asp:HyperLink></p>
                </div>
            </div>
        </div>
    </section>
    <script src="../../Content/Js/bootstrap.bundle.min.js"></script>
</body>
</html>
