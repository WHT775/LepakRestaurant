<%@ Page Title="" Language="C#" MasterPageFile="~/Boundary/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="LepakRestaurant.Boundary.EditUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <asp:Label runat="server" Text="Login ID:"></asp:Label>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtLoginId" AutoCompleteType="Disabled"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" Text="Password:"></asp:Label>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtPassword" AutoCompleteType="Disabled"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" Text="Role:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlRole" DataTextField="role_name" DataValueField="roles_id"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" Text="Disabled:"></asp:Label></td>
            <td>
                <asp:DropDownList runat="server" ID="ddlDisabled">
                    <asp:ListItem Text="False" Value="False"></asp:ListItem>
                    <asp:ListItem Text="True" Value="True"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button runat="server" ID="btnCancel" OnClick="btnCancel_Click" Text="Back" />
            </td>
            <td>
                <asp:Button runat="server" ID="btnUpdate" OnClick="btnUpdate_Click" Text="Update" />
            </td>
        </tr>
    </table>
</asp:Content>
