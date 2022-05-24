<%@ Page Title="" Language="C#" MasterPageFile="~/Boundary/MobileMaster.Master" AutoEventWireup="true" CodeBehind="CustomerLogin.aspx.cs" Inherits="LepakRestaurant.Boundary.CustomerLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
        <div class="fullandcenter">
            <asp:Image ID="ibtnHome" runat="server" Width="260px" ImageUrl="./images/logo.jpg" />
        </div>
            <div id="mainDiv" runat="server">
                <asp:Label runat="server" Text="Unique Code"></asp:Label>
                <asp:TextBox CssClass="cusBtn" ID="codeTxt" placeholder="Enter unique code here" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                <asp:Label runat="server" Text="Phone Number"></asp:Label>
                <asp:TextBox ID="phoneTxt" placeholder="Enter phone number here" runat="server" type="number"></asp:TextBox>
                <asp:Button CssClass="cusBtn" ID="btnCode" Text="Enter" runat="server" OnClick="btnCode_Click" />
            </div>
            <div id="custDiv" runat="server">
                <asp:Label ID="nameLbl" Text="Name" runat="server"></asp:Label>
                <asp:TextBox ID="nameTxt" placeholder="Enter your name here" runat="server"></asp:TextBox>
                <asp:Button ID="btnAdd" Text="Submit" runat="server" OnClick="btnAdd_Click" CssClass="fullbtn" />
            </div>
            <div id="errorDiv" runat="server">
                <asp:Label ID="errorMsg" runat="server"></asp:Label>
            </div>
</asp:Content>
