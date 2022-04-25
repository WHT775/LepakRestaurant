<%@ Page Title="" Language="C#" MasterPageFile="~/Boundary/MasterPage.Master" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="LepakRestaurant.Boundary.Manager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:100%;text-align:center;">
        <asp:Button runat="server" ID="btnAddMenu" Text="Add Menu" OnClick="btnAddMenu_Click"/>
    </div>
</asp:Content>
