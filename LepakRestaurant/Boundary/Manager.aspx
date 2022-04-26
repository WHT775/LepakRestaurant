<%@ Page Title="" Language="C#" MasterPageFile="~/Boundary/MasterPage.Master" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="LepakRestaurant.Boundary.Manager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:100%;text-align:center;">
        <asp:Button runat="server" ID="btnAddMenu" Text="Add Menu" OnClick="btnAddMenu_Click"/>
    </div>
            <div style="overflow-x: auto; text-align: center; width: 100%">
            <div style="width:40%;margin:0 auto">
                <asp:Repeater ID="rptBranch" runat="server" EnableViewState="false">
                    <ItemTemplate>
                        <div style="display: inline-grid; text-align: center">
<%--                            <asp:Image runat="server" ID="menuImage" Width="150px" />
                            <asp:Label runat="server" ID="menuName" Text='<%#Eval("menuName") %>'></asp:Label>
                            <asp:Label runat="server" ID="menuPrice"></asp:Label>
                            <asp:Label runat="server" ID="menuFoodType" Text='<%#Eval("FKmenuFoodType") %>'></asp:Label>
                            <b><asp:Label runat="server" ID="menuStatus" Text='<%#Eval("FKmenuStatusType") %>'></asp:Label></b>
                            <br />
                            <asp:Button runat="server" ID="btnEdit" Text="Edit" CommandName="Edit" CommandArgument='<%#Eval("menuId") %>' />--%>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
</asp:Content>
