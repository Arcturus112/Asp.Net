<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logiin.aspx.cs" Inherits="MultiUserAddressBook.Logiin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/Css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Content/Css/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/Css/Custom.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
    <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin/>
    <link href="https://fonts.googleapis.com/css2?family=Bad+Script&display=swap" rel="stylesheet"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/4.1.1/animate.min.css"/>
    <title></title>
</head>
<body>
    <section class="login bg-light">
        <div class="container center-login">
            <div class="row d-flex align-items-center">
                <div class="col-lg-5">
                    <asp:Image ID="Image1" runat="server" CssClass="img-fluid" ImageUrl="~/Content/Images/address_book.png"/>
                </div>
                <div class="col-lg-7 text-center py-5">
                    <h1 class="animate__animated animate__pulse animate__infinite">WELCOME BACK</h1>
                    <form runat="server">
                        <div class="form-row py-2 pt-5">
                            <div class="offset-1 col-lg-10">
                                <asp:TextBox ID="txtUsername" runat="server" CssClass="inp px-3" placeholder="Username"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row py-3">
                            <div class="offset-1 col-lg-10">
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="inp px-3" placeholder="Password" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row py-3">
                            <div class="offset-1 col-lg-10">
                                <asp:Button ID="btnSign" CssClass="btn1" runat="server" Text="Sign In" />
                            </div>
                        </div>
                    </form>
                    <p> OR Register</p>
                </div>
            </div>
        </div>
    </section>
</body>
</html>
