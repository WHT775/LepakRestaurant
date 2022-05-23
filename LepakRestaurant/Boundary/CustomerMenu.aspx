<%@ Page Title="" Language="C#" MasterPageFile="~/Boundary/MobileMaster.Master" AutoEventWireup="true" CodeBehind="CustomerMenu.aspx.cs" Inherits="LepakRestaurant.Boundary.CustomerMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        a.popup:target {
            display: block;
        }

            a.popup:target + div.popup {
                display: block;
            }

        a.popup {
            display: none;
            position: fixed;
            top: 0;
            left: 0;
            z-index: 3;
            width: 100%;
            height: 100%;
            background: rgba(0, 0, 0, 0.8);
            cursor: default;
        }

        div.popup {
            display: none;
            background: white;
            width: 80%;
            height: 100%;
            position: fixed;
            top: 0;
            left: 10%;
            /*margin-left: -320px;*/ /* = -width / 2 */
            /*margin-top: -240px;*/ /* = -height / 2 */
            z-index: 4;
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
            -ms-box-sizing: border-box;
            box-sizing: border-box;
        }

            /* links to close popup */
            div.popup > a.close {
                color: white;
                position: absolute;
                font-weight: bold;
                right: 10px;
            }

                div.popup > a.close.word {
                    top: 100%;
                    margin-top: 5px;
                }

                div.popup > a.close.x {
                    bottom: 100%;
                    margin-bottom: 5px;
                }
    </style>
    <script type="text/javascript">
        function showShoppingCart() {
            document.getElementsByClassName("popup")[0].style.display = "block";
            document.getElementsByClassName("popup")[1].style.display = "block";
        }

        function closeShoppingCart() {
            document.getElementsByClassName("popup")[0].style.display = "none";
            document.getElementsByClassName("popup")[1].style.display = "none";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="scriptManager"></asp:ScriptManager>

    <asp:UpdatePanel runat="server" ID="upMenu" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="menuDiv" runat="server">
                <div class="fullwidthcenter">
                    <asp:Image ID="ibtnHome" runat="server" Width="260px" ImageUrl="~/CSS/logo.jpg" />
                    <h3 style="margin: 0px 0px 28px 0px;">Dining at your convenience</h3>
                </div>
                <asp:Table runat="server" CssClass="fullwidthcenter">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Repeater ID="rptItemCategory" runat="server">
                                <HeaderTemplate></HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Button ID="selectedCategory" runat="server" Text='<%#Eval("CATEGORY_NAME") %>' OnClick="selectedCategory_Click" />
                                </ItemTemplate>
                                <FooterTemplate></FooterTemplate>
                            </asp:Repeater>
                            <br />
                            <div style="overflow-x: auto; text-align: center;">
                                <asp:Repeater ID="rptItem" runat="server">
                                    <HeaderTemplate></HeaderTemplate>
                                    <ItemTemplate>
                                        <div style="display: inline-grid; text-align: center;">
                                            <asp:Label ID="itemID" runat="server" Text='<%#Eval("MENU_ID") %>' Visible="false"></asp:Label>
                                            <asp:Image ID="itemImg" runat="server" ImageUrl='<%# "images\\" + Eval("ITEM_IMG") %>' Height="125px" Width="100%" AlternateText='<%#Eval("ITEM_NAME") %>' />
                                            <br />
                                            <asp:Label ID="itemName" runat="server" Text='<%#Eval("ITEM_NAME") %>'></asp:Label>
                                            <%--<br />--%>
                                            <asp:Label ID="itemPrice" runat="server" Text='<%# "Price: $" + Eval("ITEM_PRICE") %>'></asp:Label>
                                            <br />
                                            <asp:TextBox ID="itemQty" runat="server" TextMode="Number" placeholder="Enter quantity here" AutoCompleteType="Disabled"></asp:TextBox>
                                            <br />
                                            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                                            <asp:Button ID="btnRemove" runat="server" Text="Remove" OnClick="btnRemove_Click" />
                                            <br />
                                        </div>
                                    </ItemTemplate>
                                    <FooterTemplate></FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </asp:TableCell>
                    </asp:TableRow>
                    <%--            <asp:TableRow>
                <asp:TableCell>
                    <br />
                    <div id="cartDiv" runat="server">
                    </div>
                    <asp:Button ID="cfmOrder" runat="server" Text="Confirm Order" OnClick="cfmOrder_Click" />
                    <br />
                    <br />
                </asp:TableCell>
            </asp:TableRow>--%>
                </asp:Table>


                <div style="height: 40px;">
                    <span></span>
                </div>
            </div>
            <div class="fullwidthcenter">
                <asp:Button runat="server" ID="btnShoppingCart" Text="Shopping Cart" Width="100%" Height="40px" CssClass="shoppingCart" OnClientClick="showShoppingCart();return false;" />
            </div>


            <a runat="server" id="my_popup" class="popup"></a>
            <div runat="server" id="popup" class="popup">
                <div style="display: inline-flex;">
                    <h3><span style="left: 20px;position:absolute;">Shopping Cart</span></h3>
                    <h3>
                        <asp:Label runat="server" ID="lblTableNum" CssClass="tblNum"></asp:Label></h3>
                </div>
                <br />
                <br />
                <div style="position: absolute; left: 20px;">
                    <div id="cartDiv" runat="server">
                    </div>
                    <br />
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Close" OnClientClick="closeShoppingCart();return false;" />
                    <asp:Button ID="cfmOrder" runat="server" Text="Confirm Order" OnClick="cfmOrder_Click" />
                </div>
                <a class="close x">
                    <asp:LinkButton runat="server" CssClass="close x" OnClientClick="closeShoppingCart();return false;">x</asp:LinkButton></a>
                <a class="close word">
                    <asp:LinkButton runat="server" CssClass="close word" OnClientClick="closeShoppingCart();return false;">Close</asp:LinkButton></a>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
