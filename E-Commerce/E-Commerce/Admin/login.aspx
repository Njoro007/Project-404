<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="E_Commerce.Admin.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            font-family: Arial, Helvetica, sans-serif;
        }

        form {
            border: 3px solid #f1f1f1;
        }

        .input[type=text], input[type=password] {
            width: 100%;
            padding: 12px 20px;
            margin: 8px 0;
            display: inline-block;
            border: 1px solid #ccc;
            box-sizing: border-box;
        }

        .button {
            background-color: #4CAF50;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            cursor: pointer;
            width: 100%;
        }

            .button:hover {
                opacity: 0.8;
            }

        .cancelbtn {
            width: auto;
            padding: 10px 18px;
            background-color: #f44336;
        }

        .imgcontainer {
            text-align: center;
            margin: 24px 0 12px 0;
        }

        img.avatar {
            width: 40%;
            border-radius: 50%;
        }

        .container {
            padding: 16px;
        }

        span.psw {
            float: right;
            padding-top: 16px;
        }

        /* Change styles for span and cancel button on extra small screens */
        @media screen and (max-width: 300px) {
            span.psw {
                display: block;
                float: none;
            }

            .cancelbtn {
                width: 100%;
            }
        }
    </style>
</head>
<body style="padding-left:30%;padding-right:30%;">
    <h2>Administrator Login Panel</h2>
    <form id="form1" runat="server">
        <div>
            <div class="imgcontainer">
                <img src="img_avatar2.png" alt="Avatar" class="avatar">
            </div>

            <div class="container">
                <asp:Label ID="lbluname" runat="server" Text="Username"></asp:Label>
                <asp:TextBox ID="txtUname" runat="server" CssClass="input"></asp:TextBox>

                <asp:Label ID="lblpwd" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="txtPwd" runat="server" CssClass="input"></asp:TextBox>

                <asp:Button CssClass="button" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            </div>

            <div class="container" style="background-color: #f1f1f1">
                <asp:Button CssClass="cancelbtn" ID="btnCancel" runat="server" Text="Cancel" />
                <asp:Label ID="lblAlert" runat="server" Text="" ForeColor="red"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
