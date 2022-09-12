<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="Movies_System.SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online Movie System</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <link rel="stylesheet" href="https://pro.fontawesome.com/releases/v5.10.0/css/all.css" integrity="sha384-AYmEC3Yw5cVb3ZcuHtOA93w35dYTsvhLPVnYs9eStHfGJvOvKxVfELGroGkvsg+p" crossorigin="anonymous" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.22/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.22/js/jquery.dataTables.min.js"></script>
    <script> 
        $(function () {
            if ($("#Email").is(":focus") || $("#password").is(":focus")) {
                $('#InvalidUser').val("");
            }
        });
        
        function checkValidField() {
            $('#InvalidUser').empty();
            //Getting Value of Customer
            var email = document.getElementById("Email").value;
            var password = document.getElementById("password").value;
            var role = document.getElementById("Roles").value;
            //Empty Value of Customers is Coming
            if (email == "" || role == "") {
                alert("Email and Roles Are Required");
                return false;
            }
            else if (password == "" || password.length < 8) {
                alert("Password Should Not Be Empty or Minimum 8 characters Required");
                return false;
            }
            return true;

        }
    </script>
</head>
<body>
    <section>
        <div class="container py-5 h-100">
            <div class="row d-flex justify-content-center align-items-center h-60">
                <div class="col col-xl-10">
                    <div class="card">
                        <div class="row g-0">
                            <div class="col-md-6 col-lg-5 d-none d-md-block">
                                <img src="https://images.pexels.com/photos/2873486/pexels-photo-2873486.jpeg?auto=compress&cs=tinysrgb&w=600"
                                    alt="Camera-Picture" class="img-fluid" />
                            </div>
                            <div class="col-md-6 col-lg-7 d-flex align-items-center">
                                <div class="card-body p-4 p-lg-5 text-black">

                                    <div class="d-flex align-items-center mb-3 pb-1">
                                        <i class="fas fa-duotone fa-film fa-2x me-3"></i>
                                        <span class="h1 fw-bold mb-0">Movies</span>
                                    </div>

                                    <form runat="server" id="SignInForm">

                                        <h5 class="fw-normal mb-3 pb-3">Sign into your account</h5>

                                        <div class="form-outline mb-4">
                                            <asp:TextBox runat="server" TextMode="Email" ID="Email" class="form-control form-control-lg"></asp:TextBox>
                                            <asp:Label runat="server" class="form-label" for="Email" Text="Email address"></asp:Label>

                                        </div>

                                        <div class="form-outline mb-4">
                                            <asp:DropDownList runat="server" class="form-control form-control-lg" ID="Roles">
                                                <asp:ListItem Value="">Select</asp:ListItem>
                                                <asp:ListItem Value="Admin" Text="Admin"></asp:ListItem>
                                                <asp:ListItem Value="Customer" Text="Customer"></asp:ListItem>
                                            </asp:DropDownList>

                                        </div>

                                        <div class="form-outline mb-4">
                                            <asp:TextBox runat="server" TextMode="Password" ID="password" class="form-control form-control-lg"> </asp:TextBox>
                                            <asp:Label runat="server" class="form-label" for="password" Text="Password"></asp:Label>

                                        </div>

                                        <div>
                                            <asp:Label runat="server" ID="InvalidUser"></asp:Label>
                                        </div>
                                        <div class="pt-1 mb-4">
                                            <asp:Button runat="server" class="btn btn-success btn-lg btn-block" type="button" Text="Sign In" OnClientClick="return checkValidField();" OnClick="LogIn" />
                                        </div>

                                        <p class="mb-5 pb-lg-2" style="color: #393f81;">
                                            Don't have an account? <a href="/SignUp.aspx"
                                                style="color: #393f81;">Sign Up</a>
                                        </p>

                                    </form>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</body>
</html>
