<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="YemekTarifiSitesi4.AdminLogin" %>

<!DOCTYPE html>
<html lang="tr">
<head runat="server">
    <meta charset="utf-8" />
    <title>Admin Giriş</title>

    <style>
        body {
            background: linear-gradient(120deg, #3a7bd5, #3a6073);
            font-family: Arial;
        }

        .login-box {
            width: 350px;
            margin: 150px auto;
            background: #fff;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 10px 30px rgba(0,0,0,0.25);
        }

        .login-box h2 {
            text-align: center;
            margin-bottom: 25px;
            color: #3a6073;
        }

        .login-box input {
            width: 100%;
            padding: 10px;
            margin-top: 5px;
            border-radius: 5px;
            border: 1px solid #ccc;
        }

        .login-box button,
        .login-box input[type=submit] {
            width: 100%;
            margin-top: 20px;
            padding: 10px;
            background: #3a7bd5;
            color: white;
            border: none;
            border-radius: 5px;
            font-weight: bold;
            cursor: pointer;
        }

        .login-box button:hover {
            background: #2f6bc0;
        }

        .error {
            margin-top: 10px;
            color: red;
            text-align: center;
        }
    </style>
</head>

<body>
    <form runat="server">
        <div class="login-box">
            <h2>Admin Paneli</h2>

            <asp:TextBox ID="TxtKullanici" runat="server" Placeholder="Kullanıcı Adı"></asp:TextBox>

            <asp:TextBox ID="TxtSifre" runat="server" TextMode="Password" Placeholder="Şifre"></asp:TextBox>

            <asp:Button ID="BtnGiris" runat="server" Text="Giriş Yap" OnClick="BtnGiris_Click" />

            <asp:Label ID="LblHata" runat="server" CssClass="error"></asp:Label>
        </div>
    </form>
</body>
</html>
