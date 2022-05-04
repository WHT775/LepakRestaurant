<%@ Page Title="" Language="C#" MasterPageFile="~/Boundary/MobileMaster.Master" AutoEventWireup="true" CodeBehind="PaymentPage.aspx.cs" Inherits="LepakRestaurant.Boundary.PaymentPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td>
                <asp:Label ID="lblTableNum" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Image ID="lblImage" runat="server" />
            </td>
            <td>
                <asp:Label ID="lblItemName" runat="server"></asp:Label>
                <asp:Label ID="lblQty" runat="server"></asp:Label>
                <asp:Label ID="lblPrice" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
