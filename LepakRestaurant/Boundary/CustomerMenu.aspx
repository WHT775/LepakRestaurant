<%@ Page Title="" Language="C#" MasterPageFile="~/Boundary/MobileMaster.Master" AutoEventWireup="true" CodeBehind="CustomerMenu.aspx.cs" Inherits="LepakRestaurant.Boundary.CustomerMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="cartId" runat="server"></asp:Label>
    <asp:Label ID="cartQty" runat="server"></asp:Label>
    <asp:Repeater id="rptItemCategory" runat="server">
        <HeaderTemplate></HeaderTemplate>
        <ItemTemplate>
            <asp:Button ID="selectedCategory" runat="server" Text='<%#Eval("CATEGORY_NAME") %>' OnClick="selectedCategory_Click"/>
        </ItemTemplate>
        <FooterTemplate></FooterTemplate>
    </asp:Repeater>
    <br />
    <asp:Repeater ID="rptItem" runat="server" >
        <HeaderTemplate></HeaderTemplate>
        <ItemTemplate>
            <asp:Label ID="itemID" runat="server" Text='<%#Eval("MENU_ID") %>' Visible="false"></asp:Label>
            <asp:Image ID="itemImg" runat="server" ImageUrl='<%# "images\\" + Eval("ITEM_IMG") %>' Height="100px" Width="100px" AlternateText='<%#Eval("ITEM_NAME") %>' />
            <br />
            <asp:Label ID="itemName" runat="server" Text='<%#Eval("ITEM_NAME") %>'></asp:Label>
            <br />
            <asp:Label ID="itemPrice" runat="server" Text='<%# "Price: $" + Eval("ITEM_PRICE") %>' ></asp:Label>
            <br />
            <asp:TextBox ID="itemQty" runat="server" placeholder="Enter quantity here"></asp:TextBox>
            <br />
            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
            <br />
        </ItemTemplate>
        <FooterTemplate></FooterTemplate>
    </asp:Repeater>
</asp:Content>
