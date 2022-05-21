<%@ Page Title="" Language="C#" MasterPageFile="~/Boundary/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddCoupon.aspx.cs" Inherits="LepakRestaurant.Boundary.AddCoupon" %>

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
                <h1>Add Coupon</h1>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" Text="Code:"></asp:Label></td>
            <td>
                <asp:TextBox runat="server" ID="txtCode" AutoCompleteType="Disabled"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" Text="Discount:"></asp:Label></td>
            <td>
                <asp:TextBox runat="server" ID="txtDiscount" AutoCompleteType="Disabled"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" Text="Expiry Date:"></asp:Label></td>
            <td>
                <asp:TextBox runat="server" ID="txtExpiryDate" AutoCompleteType="Disabled" TextMode="Date"></asp:TextBox></td>
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
