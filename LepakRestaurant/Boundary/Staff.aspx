<%@ Page Title="" Language="C#" MasterPageFile="~/Boundary/MasterPage.Master" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="LepakRestaurant.Boundary.Staff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            padding-bottom: 8px;
            text-align: center;
            display: none;
            background: white;
            width: 500px;
            /*height: 40%;*/
            position: fixed;
            top: 35%;
            left: 40%;
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="upStaff" UpdateMode="Conditional">
        <ContentTemplate>
            <div style="font-family: Arial, Helvetica, sans-serif; text-align: center;">
                <h1>Pending Orders</h1>
            </div>
            <div style="overflow-x: auto; text-align: center; width: 100%">
                <div style="width: 60%; margin: 0 auto; display: -webkit-inline-box">
                    <asp:Repeater runat="server" ID="rptOrders" OnItemDataBound="rptOrders_ItemDataBound" OnItemCommand="rptOrders_ItemCommand">
                        <ItemTemplate>
                            <div style="display: inline-grid; text-align: center; border: 1px solid black; height: 100%; margin: 7px 7px;">
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
                                        <td colspan="2" style="width: 100%; height: 200px; overflow-y: auto;">
                                            <asp:Repeater runat="server" ID="rptMenu" OnItemDataBound="rptMenu_ItemDataBound">
                                                <ItemTemplate>
                                                    <table>
                                                        <tr>
                                                            <td style="width: 100px; word-break: break-word;">
                                                                <asp:Label runat="server" ID="lblMenuName"></asp:Label></td>
                                                            <td style="width: 40px;">
                                                                <asp:Label runat="server" ID="lblCost"></asp:Label></td>
                                                            <td style="width: 30px;">
                                                                <asp:Label runat="server" ID="lblQuantity"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                    <div style="text-align: center;">
                                                    </div>
                                                    <table>
                                                        <tr style="width: 100%">
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
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
            <a runat="server" id="my_popup" class="popup"></a>
            <div runat="server" id="popup" class="popup">
                <h3>
                    <asp:Label runat="server" ID="lblTitle"></asp:Label></h3>
                <asp:HiddenField runat="server" ID="hfcancelorderid" />
                <div>
                    <br />
                    <div style="vertical-align: middle;">
                        Reasoning:
                    </div>
                    <asp:TextBox runat="server" ID="txtReasoning" TextMode="MultiLine" Height="60px" Width="200px"></asp:TextBox>
                    <br />
                </div>
                <div>
                    <br />
                    <asp:Button runat="server" ID="btnSubmitReason" Text="Cancel Order" OnClick="btnSubmitReason_Click" />
                    <%--                    <asp:Button runat="server" ID="btnApproveMenu" Text="Approve" OnClick="btnApproveMenu_Click" />
                    <asp:Button runat="server" ID="btnRejectMenu" Text="Reject" OnClick="btnRejectMenu_Click" />--%>
                </div>
                <a class="close x">
                    <asp:LinkButton runat="server" CssClass="close x" OnClick="Unnamed_Click">x</asp:LinkButton></a>
                <a class="close word">
                    <asp:LinkButton runat="server" CssClass="close word" OnClick="Unnamed_Click">Close</asp:LinkButton></a>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
