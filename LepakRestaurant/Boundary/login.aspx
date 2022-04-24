<%@ Page Title="" Language="C#" MasterPageFile="~/Boundary/MasterPage.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="LepakRestaurant.Boundary.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table>
        <tr>
            <td>Login ID:
            </td>
            <td>
                <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
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
            <td colspan="2">
                <asp:Button ID="btnLogin" runat="server" Text="Login" Style="width: 100%" OnClick="btnLogin_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
