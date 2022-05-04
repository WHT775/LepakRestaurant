<%@ Page Title="" Language="C#" MasterPageFile="~/Boundary/MobileMaster.Master" AutoEventWireup="true" CodeBehind="CustomerMenu.aspx.cs" Inherits="LepakRestaurant.Boundary.CustomerMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="menuDiv" runat="server">
        <asp:Table runat="server">
            <asp:TableRow>
                <asp:TableCell>
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
                            <asp:Button ID="btnRemove" runat="server" Text="Remove" OnClick="btnRemove_Click" />
                            <br />
                        </ItemTemplate>
                        <FooterTemplate></FooterTemplate>
                    </asp:Repeater>
                </asp:TableCell>
                <asp:TableCell>
                    <div id="cartDiv" runat="server">
                        
                    </div>
                    <asp:Button ID ="cfmOrder" runat="server" Text="Confirm Order" OnClick="cfmOrder_Click" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    
</asp:Content>
