<%@ Page Title="" Language="C#" MasterPageFile="~/Boundary/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddCoupon.aspx.cs" Inherits="LepakRestaurant.Boundary.AddCoupon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td><asp:Label runat="server" Text="Code:"></asp:Label></td>
            <td><asp:TextBox runat="server" ID="txtCode" AutoCompleteType="Disabled"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label runat="server" Text="Discount:"></asp:Label></td>
            <td><asp:TextBox runat="server" ID="txtDiscount" AutoCompleteType="Disabled"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2"><asp:Label runat="server" ID="lblWrong" ForeColor="Red" Visible="false"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Button runat="server" ID="btnCancel" Text="Cancel" OnClick="btnCancel_Click"/></td>
            <td><asp:Button runat="server" ID="btnCreate" Text="Create" OnClick="btnCreate_Click"/></td>
        </tr>
    </table>
</asp:Content>
