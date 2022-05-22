<%@ Page Title="" Language="C#" MasterPageFile="~/Boundary/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditCategory.aspx.cs" Inherits="LepakRestaurant.Boundary.EditCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        table {
            margin-left: 825px;
            font-family: Arial, Helvetica, sans-serif;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td colspan="2">
                <h1>Update Category</h1>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" Text="Category Name: "></asp:Label></td>
            <td>
                <asp:TextBox runat="server" ID="txtCategory" AutoCompleteType="Disabled"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label runat="server" ID="lblWrong" ForeColor="Red" Visible="false"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:Button runat="server" ID="btnCancel" Text="Cancel" OnClick="btnCancel_Click" /></td>
            <td>
                <asp:Button runat="server" ID="btnUpdate" Text="Update" OnClick="btnUpdate_Click" /></td>
        </tr>
    </table>
</asp:Content>
