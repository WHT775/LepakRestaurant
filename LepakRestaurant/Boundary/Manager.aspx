<%@ Page Title="" Language="C#" MasterPageFile="~/Boundary/MasterPage.Master" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="LepakRestaurant.Boundary.Manager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="scriptManager"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="upManager" UpdateMode="Conditional">
        <ContentTemplate>
            <div style="width: 100%; text-align: center;">
                <asp:Button runat="server" ID="btnAddMenu" Text="Add Menu" OnClick="btnAddMenu_Click" />
            </div>
            <div style="overflow-x: auto; text-align: center; width: 100%">
                <div style="width: 60%; margin: 0 auto; height: 600px;">
                    <asp:Repeater ID="rptMenu" runat="server" EnableViewState="true" OnItemDataBound="rptMenu_ItemDataBound" OnItemCommand="rptMenu_ItemCommand">
                        <ItemTemplate>
                            <div style="display: inline-grid; text-align: center; border: 1px solid black; margin: 8px">
                                <asp:Image runat="server" ID="menuImage" Width="250px" Height="150px" />
                                <asp:Label runat="server" ID="menuName" Text='<%#Eval("item_name") %>'></asp:Label>
                                <asp:Label runat="server" ID="menuPrice"></asp:Label>
                                <asp:Label runat="server" ID="menuCategory" Text='<%#Eval("category.category_name") %>'></asp:Label>
                                <%--                            <b><asp:Label runat="server" ID="menuStatus" Text='<%#Eval("FKmenuStatusType") %>'></asp:Label></b>--%>
                                <br />
                                <div style="display: inline-flex;">
                                    <asp:Button Width="100%" runat="server" ID="btnDelete" Text="Delete" CommandName="Delete" CommandArgument='<%#Eval("menu_id") %>' />
                                    <asp:Button Width="100%" runat="server" ID="btnEdit" Text="Edit" CommandName="Edit" CommandArgument='<%#Eval("menu_id") %>' />
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div style="width: 100%; text-align: center;">
                <asp:Button runat="server" ID="btnAddCoupon" Text="Add Coupon" OnClick="btnAddCoupon_Click" />
            </div>
            <div style="overflow-x: auto; text-align: center; width: 100%">
                <div style="width: 60%; margin: 0 auto; height: 600px;">
                    <asp:GridView runat="server" ID="gvCoupon" AutoGenerateColumns="false" OnRowCommand="gvCoupon_RowCommand" OnRowDeleting="gvCoupon_RowDeleting" OnRowDataBound="gvCoupon_RowDataBound">
                        <Columns>
                            <asp:BoundField HeaderText="Coupon Code" DataField="coupon_code" />
                            <asp:BoundField HeaderText="Amount" DataField="discount_amt" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
