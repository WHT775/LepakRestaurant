<%@ Page Title="" Language="C#" MasterPageFile="~/Boundary/MobileMaster.Master" AutoEventWireup="true" CodeBehind="CustomerLogin.aspx.cs" Inherits="LepakRestaurant.Boundary.CustomerLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
      <div id="mainDiv" runat="server">
          <asp:TextBox ID="codeTxt" placeholder="Enter unique code here" runat="server"></asp:TextBox>
          <asp:TextBox ID="phoneTxt" placeholder="Enter phone number here" runat ="server"></asp:TextBox>
          <asp:Button id="btnCode" Text="Enter" runat="server" OnClick="btnCode_Click" />
      </div>
      <div id="custDiv" runat="server">
          <asp:Label ID="nameLbl" Text="Enter your name" runat="server"></asp:Label>
          <asp:TextBox ID ="nameTxt" placeholder="Enter your name here" runat="server"></asp:TextBox>
          <asp:Button ID="btnAdd" Text="Submit" runat="server" OnClick="btnAdd_Click" />
      </div>
    <div id="errorDiv" runat="server">
        <asp:Label ID="errorMsg" runat="server"></asp:Label>
    </div>
</asp:Content>
