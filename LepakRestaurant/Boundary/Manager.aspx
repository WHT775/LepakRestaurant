<%@ Page Title="" Language="C#" MasterPageFile="~/Boundary/MasterPage.Master" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="LepakRestaurant.Boundary.Manager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /*body {font-family: Arial;}*/
        div{
            font-family: Arial, Helvetica, sans-serif;
        }
        /* Style the tab */
        .tab {
            overflow: hidden;
            border: 1px solid #ccc;
            background-color: #f1f1f1;
            /*width:100%;*/
            text-align: center;
            width: 100vw;
        }

            /* Style the buttons inside the tab */
            .tab input[type="submit"] {
                background-color: inherit;
                border: none;
                outline: none;
                cursor: pointer;
                padding: 14px 16px;
                transition: 0.3s;
                font-size: 17px;
            }

                /* Change background color of buttons on hover */
                .tab input[type="submit"]:hover {
                    background-color: #ddd;
                }

                /* Create an active/current tablink class */
                .tab input[type="submit"].active {
                    background-color: #ccc;
                }

        /* Style the tab content */
        .tabcontent {
            display: none;
            padding: 6px 12px;
            border: 1px solid #ccc;
            border-top: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="scriptManager"></asp:ScriptManager>

    <asp:UpdatePanel runat="server" ID="upManager" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="tab">
                <%--        <button class="tablinks" onclick="openCity(event, 'divMenu');return false;">Menu</button>
        <button class="tablinks" onclick="openCity(event, 'divCoupon');return false;">Coupon</button>--%>
                <asp:Button runat="server" CssClass="tablinks" Text="Menu  " ID="btnMenuTab" OnClick="btnMenuTab_Click" />
                <asp:Button runat="server" CssClass="tablinks" Text="Coupon" ID="btnCouponTab" OnClick="btnCouponTab_Click" />
            </div>
            <div id="divMenu" runat="server" class="tabcontent">
                <div style="width: 100%; text-align: center;">
                    <asp:Button runat="server" ID="btnAddMenu" Text="Add Menu" OnClick="btnAddMenu_Click" />
                </div>
                <br />
                <div style="overflow-x: auto; text-align: center; width: 100%">
                    <div style="width: 80%; margin: 0 auto;">
                        <div style="text-align: center;">
                            <h2>
                                <asp:Label runat="server" ID="lblCategories"></asp:Label></h2>
                        </div>
                        <asp:Repeater ID="rptItemCategory" runat="server" OnItemCommand="rptItemCategory_ItemCommand">
                            <ItemTemplate>
                                <asp:Button ID="selectedCategory" runat="server" Text='<%#Eval("CATEGORY_NAME")%>' CommandName='<%#Eval("CATEGORY_NAME")%>' CommandArgument='<%#Eval("category_id")%>' />
                            </ItemTemplate>
                            <FooterTemplate></FooterTemplate>
                        </asp:Repeater>
                        <br />
                        <asp:Repeater ID="rptMenu" runat="server" EnableViewState="true" OnItemDataBound="rptMenu_ItemDataBound" OnItemCommand="rptMenu_ItemCommand">
                            <ItemTemplate>
                                <div style="display: inline-grid; text-align: center; border: 1px solid black; margin: 8px">
                                    <asp:Image runat="server" ID="menuImage" Width="250px" Height="150px" />
                                    <asp:Label runat="server" ID="menuName" Text='<%#Eval("item_name") %>'></asp:Label>
                                    <asp:Label runat="server" ID="menuPrice"></asp:Label>
                                    <asp:Label runat="server" ID="menuCategory" Text='<%#Eval("category.category_name") %>'></asp:Label>
                                    <b>
                                        <asp:Label runat="server" ID="menuStatus" Text='<%#Eval("menustatus.status_name") %>'></asp:Label></b>
                                    <br />
                                    <div style="display: inline-flex;">
                                        <%--<asp:Button Width="100%" runat="server" ID="btnDelete" Text="Delete" CommandName="Delete" CommandArgument='<%#Eval("menu_id") %>' />--%>
                                        <asp:Button Width="100%" runat="server" ID="btnEdit" Text="Edit" CommandName="Edit" CommandArgument='<%#Eval("menu_id") %>' />
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
            <div id="divCoupon" runat="server" class="tabcontent">
                <div style="width: 100%; text-align: center;">
                    <asp:Button runat="server" ID="btnAddCoupon" Text="Add Coupon" OnClick="btnAddCoupon_Click" />
                </div>
                <br />
                <div style="overflow-x: auto; text-align: center; width: 100%">
                    <div style="width: 80%; margin: 0 auto;">

                        <asp:GridView runat="server" ID="gvCoupon" AutoGenerateColumns="false" OnRowCommand="gvCoupon_RowCommand" OnRowDeleting="gvCoupon_RowDeleting" OnRowDataBound="gvCoupon_RowDataBound" HorizontalAlign="Center">
                            <Columns>
                                <asp:BoundField HeaderText="Coupon Code" DataField="coupon_code" />
                                <asp:BoundField HeaderText="Amount" DataField="discount_amt" />
                                <asp:BoundField HeaderText="Expiry Date" DataField="expiry_date" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button runat="server" CommandName="Edit" CommandArgument='<%#Eval("coupon_id") %>' Text="Edit" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button runat="server" ID="btnDelete" CommandName="Delete" CommandArgument='<%#Eval("coupon_id") %>' Text="Delete" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--    <script>
        function openCity(evt, cityName) {
            var i, tabcontent, tablinks;
            tabcontent = document.getElementsByClassName("tabcontent");
            for (i = 0; i < tabcontent.length; i++) {
                tabcontent[i].style.display = "none";
            }
            tablinks = document.getElementsByClassName("tablinks");
            for (i = 0; i < tablinks.length; i++) {
                tablinks[i].className = tablinks[i].className.replace(" active", "");
            }
            document.getElementById("<%=cityName.ClientID%>").style.display = "block";
            evt.currentTarget.className += " active";
        }
    </script>--%>
</asp:Content>
