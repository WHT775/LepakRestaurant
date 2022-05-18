<%@ Page Title="" Language="C#" MasterPageFile="~/Boundary/MasterPage.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="LepakRestaurant.Boundary.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <style>
    table.center{
            margin-left: 825px;
            width: 300px;
            font-family: Arial, Helvetica, sans-serif;
        }    
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table class="center">
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
            <td colspan="2"><asp:Label runat="server" ID="lblWrong" ForeColor="Red" Text="Wrong username/password" Visible="false"></asp:Label></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="2">
                <asp:Button ID="btnLogin" runat="server" Text="Login" Style="width: 50%" OnClick="btnLogin_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
