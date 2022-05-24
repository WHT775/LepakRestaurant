<%@ Page Title="" Language="C#" MasterPageFile="~/Boundary/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="LepakRestaurant.Boundary.AddCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td colspan="2">
                <h1>Add Category</h1>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" Text="Category Name:"></asp:Label></td>
            <td>
                <asp:TextBox runat="server" ID="txtCategory" AutoCompleteType="Disabled"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label runat="server" ID="lblWrong" ForeColor="Red" Visible="false"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:Button runat="server" ID="btnCancel" Text="Cancel" OnClick="btnCancel_Click" CssClass="fullbtn" /></td>
            <td>
                <asp:Button runat="server" ID="btnCreate" Text="Create" OnClick="btnCreate_Click" CssClass="fullbtn" /></td>
        </tr>
    </table>
</asp:Content>
