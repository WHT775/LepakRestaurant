<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="LepakRestaurant.Boundary.login" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <style>
    table.center{
            margin-left: 825px;
            width: 300px;
            font-family: Arial, Helvetica, sans-serif;
        }    
</style>
</asp:Content>--%>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">--%>
<html>
<head>
    <title>Lepak Restaurant</title>
        <link href="css/Master.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
</head>
<body>
    <form id="form2" runat="server"> 

        <table class="fullandcenter">
            <tr>
                <td colspan="2"><asp:ImageButton ID="ibtnHome" runat="server" Width="100%" Height="200px" ImageUrl="./images/logo.jpg"/></td>
            </tr>
            <tr>
                <td>Login ID:
                </td>
                <td>
                    <asp:TextBox ID="txtUser" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Password:
                </td>
                <td>
                    <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label runat="server" ID="lblWrong" ForeColor="Red" Text="Wrong username/password" Visible="false"></asp:Label></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="2">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" Style="width: 50%" OnClick="btnLogin_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
<%--</asp:Content>--%>
