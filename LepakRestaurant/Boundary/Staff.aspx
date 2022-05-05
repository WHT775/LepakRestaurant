<%@ Page Title="" Language="C#" MasterPageFile="~/Boundary/MasterPage.Master" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="LepakRestaurant.Boundary.Staff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="upStaff" UpdateMode="Conditional">
        <ContentTemplate>
            <div style="width: 100%; text-align: center;">
                <h1>Pending Orders</h1>
            </div>
            <div style="overflow-x: auto; text-align: center; width: 100%">
                <div style="width: 60%; margin: 0 auto; display: -webkit-inline-box">
                    <asp:Repeater runat="server" ID="rptOrders" OnItemDataBound="rptOrders_ItemDataBound" OnItemCommand="rptOrders_ItemCommand">
                        <ItemTemplate>
                            <div style="display: inline-grid; text-align: center; border: 1px solid black;height:100%; margin: 7px 7px;">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="lblOrderId"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="lblTableId"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="width: 100%; height:200px;overflow-y:auto;">
                                            <asp:Repeater runat="server" ID="rptMenu" OnItemDataBound="rptMenu_ItemDataBound">
                                                <ItemTemplate>
                                                    <table>
                                                        <tr>
                                                            <td style="width:100px;word-break:break-word;"><asp:Label runat="server" ID="lblMenuName"></asp:Label></td>
                                                            <td style="width:40px;"><asp:Label runat="server" ID="lblCost"></asp:Label></td>
                                                            <td style="width:30px;"><asp:Label runat="server" ID="lblQuantity"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                    <div style="text-align: center;">
                                                        
                                                        
                                                        
                                                        
                                                    </div>
                                                    <table>
                                                        <tr style="width: 100%">
                                                            <td>
                                                                </td>
                                                            <td>
                                                                </td>
                                                            <td>
                                                                </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </td>
                                    </tr>
                                    <%--                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="lblTotalCost"></asp:Label>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td>
                                            <asp:Button runat="server" Text="Cancel" Width="100%" CommandName="Cancel" CommandArgument='<%#Eval("orders.orders_id") %>' />
                                        </td>
                                        <td>
                                            <asp:Button runat="server" Text="Complete" Width="100%" CommandName="Complete" CommandArgument='<%#Eval("orders.orders_id") %>' />
                                        </td>
                                    </tr>
                                </table>





                            </div>


                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
