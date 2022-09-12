<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Movies_System.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign Up Customer</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <link rel="stylesheet" href="https://pro.fontawesome.com/releases/v5.10.0/css/all.css" integrity="sha384-AYmEC3Yw5cVb3ZcuHtOA93w35dYTsvhLPVnYs9eStHfGJvOvKxVfELGroGkvsg+p" crossorigin="anonymous" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.22/css/jquery.dataTables.min.css" />
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.22/js/jquery.dataTables.min.js"></script>
    <script>

        function CheckName() {
            var regName = /^[a-zA-Z]+ [a-zA-Z]+$/;
            var name = document.getElementById('name').value;
            $('#invalidName').empty();
            $('#InvalidLabel').empty();
            if (name == "") {
                $('#invalidName').append("Name is Required");
                return false;
            }
            if (name != "") {
                if (!regName.test(name)) {
                    $('#invalidName').append("Enter Correct Name e.g Zaheer Abbas");
                    return false;
                }
            }
            return true;

        }

        function CheckUserName() {
            var userName = document.getElementById('userName').value;
            $('#invalidUserName').empty();
            $('#InvalidLabel').empty();
            if (userName == "") {
                $('#invalidUserName').append("User Name is Required");
                return false;
            }

            if (userName != "") {
                $.ajax({
                    url: 'SignUp.aspx/CheckUserName',
                    type: "Post",
                    data: JSON.stringify({ "userName": userName }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#invalidUserName').empty();
                        if (data.d == "Already Taken") {
                            $('#invalidUserName').append(["Already Taken"]);
                            return false;
                        }
                        return true;
                    }
                });
            }

        }

        function CheckEmail() {
            var regEmail = /^w+[+.w-]*@([w-]+.)*w+[w-]*.([a-z]{2,4}|d+)$/i;
            var email = document.getElementById('email').value;
            $('#InvalidEmail').empty();
            $('#InvalidLabel').empty();

            if (email == "") {
                $('#InvalidEmail').append("Email is Required");
                return false;
            }
            else {
                $.ajax({
                    url: 'SignUp.aspx/CheckEmail',
                    type: "Post",
                    data: JSON.stringify({ "email": email }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#InvalidEmail').empty();
                        if (data.d == "Already Taken") {
                            $('#InvalidEmail').append(["Already Taken"]);
                            return false;
                        }
                        return true;
                    }
                });
            }

        }

        function CheckPhoneNumber() {
            var regPhoneNumber = /^\+92\d{10}$/;
            var phoneNumber = document.getElementById('phoneNumber').value;
            $('#InvalidPhoneNumber').empty();
            $('#InvalidLabel').empty();
            if (phoneNumber == "") {
                $('#InvalidPhoneNumber').append("Phone Number is Required");
                return false;
            }
            if (phoneNumber != "") {
                if (!regPhoneNumber.test(phoneNumber)) {
                    $('#InvalidPhoneNumber').append("Enter Correct Phone Number e.g +92XXXXXXXXXX");
                    return false;
                }
            }
            return true;
        }

        function AddCustomer() {
            var name = document.getElementById("name").value;
            var userName = document.getElementById("userName").value;
            var email = document.getElementById("email").value;
            var password = document.getElementById("password").value;
            var repeatpassword = document.getElementById("repeatpassword").value;
            var roles = document.getElementById("Roles").value;
            var phoneNumber = document.getElementById('phoneNumber').value;
            $('#InvalidPassword').empty();
            $('#InvalidLabel').empty();
            if (CheckName() == false || CheckUserName() == false || CheckEmail() == false || CheckPhoneNumber == false) {
                $('#InvalidLabel').append("Some Field Are Required");
                return false;
            }
            else if (repeatpassword != password || password == "" || password.length < 8) {

                $('#InvalidPassword').append("Password Should be same and Minimum length is 8");
                return false;
            }
            else if (roles == "") {
                $('#InvalidPassword').append("Roles Should Be Selected");
                return false;
            }
            else {
                $.ajax({
                    url: 'SignUp.aspx/AddCustomer',
                    type: "Post",
                    data: JSON.stringify({ "name": name, "userName": userName, "phoneNumber": phoneNumber, "email": email, "password": password }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#InvalidLabel').val("");
                        $('#phoneNumber').val("");
                        $('#name').val("");
                        $('#userName').val("");
                        $('#email').val("");
                        $('#password').val("");
                        $('#repeatpassword').val("");
                        if (data.d == "Added") {
                            
                            $('#InvalidLabel').append("SuccessFully Added");
                        }
                    }
                });
            }

        }



    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="vh-100">
            <div class="container py-5 h-100">
                <div class="row d-flex justify-content-center align-items-center h-60">
                    <div class="col col-xl-10">
                        <div class="card-title">
                            <h1>Add Customer</h1>
                        </div>
                        <div class="card-body">
                            <div class="form-outline mb-4">
                                <asp:Label runat="server" class="form-label" for="name" Text="Full Name"></asp:Label>
                                <asp:TextBox runat="server" ID="name" class="form-control form-control-lg" onblur="return CheckName();"></asp:TextBox>
                                <asp:Label runat="server" class="form-label" ID="invalidName"></asp:Label>
                            </div>
                            <div class="form-outline mb-4">
                                <asp:Label runat="server" class="form-label" for="userName" Text="User Name"></asp:Label>
                                <asp:TextBox runat="server" ID="userName" class="form-control form-control-lg" onblur="return CheckUserName();return false;"></asp:TextBox>
                                <asp:Label runat="server" class="form-label" ID="invalidUserName"></asp:Label>

                            </div>
                            <div class="form-outline mb-4">
                                <asp:Label runat="server" class="form-label" for="email" Text="Email"></asp:Label>
                                <asp:TextBox runat="server" TextMode="Email" ID="email" class="form-control form-control-lg" onblur="return CheckEmail();return false;"></asp:TextBox>
                                <asp:Label runat="server" class="form-label" ID="InvalidEmail"></asp:Label>
                            </div>

                            <div class="form-outline mb-4">
                                <asp:Label runat="server" class="form-label" for="phoneNumber" Text="Phone Number"></asp:Label>
                                <asp:TextBox runat="server" ID="phoneNumber" class="form-control form-control-lg" onblur="return CheckPhoneNumber();"> </asp:TextBox>
                                <asp:Label runat="server" class="form-label" for="phoneNumber" ID="InvalidPhoneNumber"></asp:Label>
                            </div>

                            <div class="form-outline mb-4">
                                <asp:Label runat="server" class="form-label" for="password" Text="Password"></asp:Label>
                                <asp:TextBox runat="server" TextMode="Password" ID="password" class="form-control form-control-lg" onblur="return CheckPassword();"> </asp:TextBox>
                                <asp:Label runat="server" class="form-label" for="phoneNumber" ID="InvalidPassword"></asp:Label>
                            </div>

                            <div class="form-outline mb-4">
                                <asp:Label runat="server" class="form-label" for="repeatpassword" Text="Repeat Password"></asp:Label>
                                <asp:TextBox runat="server" TextMode="Password" ID="repeatpassword" class="form-control form-control-lg" onblur="return CheckPasswordSame();"> </asp:TextBox>
                            </div>

                            <div class="form-outline mb-4">
                                <asp:Label runat="server" class="form-label" for="phoneNumber" Text="Roles"></asp:Label>
                                <asp:DropDownList runat="server" class="form-control form-control-lg" ID="Roles">
                                    <asp:ListItem Value="">Select</asp:ListItem>
                                    <asp:ListItem Value="Customer" Text="Customer"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label runat="server" class="form-label" for="phoneNumber" ID="InvalidRoles"></asp:Label>
                            </div>
                            <div>
                                <asp:Label runat="server" ID="InvalidLabel"></asp:Label>
                            </div>
                            <div class="btn-group">
                                <input type="button" onclick="return AddCustomer();return false;" class="btn btn-success btn-lg " value="Sign Up"/>
                                <asp:Button runat="server" class="btn btn-success btn-lg" type="button" Text="Back" OnClick="Unnamed_Click"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
