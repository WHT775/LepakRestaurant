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
            <asp:Repeater runat="server" ID="rptOrders" OnItemDataBound="rptOrders_ItemDataBound" OnItemCommand="rptOrders_ItemCommand">
            </asp:Repeater>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
