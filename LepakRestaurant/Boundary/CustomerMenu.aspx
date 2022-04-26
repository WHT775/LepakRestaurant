<%@ Page Title="" Language="C#" MasterPageFile="~/Boundary/MobileMaster.Master" AutoEventWireup="true" CodeBehind="CustomerMenu.aspx.cs" Inherits="LepakRestaurant.Boundary.CustomerMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Repeater id="rptItemCategory" runat="server">
        <HeaderTemplate></HeaderTemplate>
        <ItemTemplate>
            <asp:Button ID="selectedCategory" runat="server" Text='<%#Eval("CATEGORY_NAME") %>' OnClick="selectedCategory_Click"/>
        </ItemTemplate>
        <FooterTemplate></FooterTemplate>
    </asp:Repeater>
    <br />
    <asp:Repeater ID="rptItem" runat="server">
        <HeaderTemplate></HeaderTemplate>
        <ItemTemplate>
            <asp:Label ID="itemName" runat="server" Text='<%#Eval("ITEM_NAME") %>'></asp:Label>
            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
        </ItemTemplate>
        <FooterTemplate></FooterTemplate>
    </asp:Repeater>
</asp:Content>
