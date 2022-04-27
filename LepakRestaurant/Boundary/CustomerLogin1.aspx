<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerLogin1.aspx.cs" Inherits="LepakRestaurant.Boundary.CustomerLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Login</title>
</head>
<body>
    <form id="loginForm" runat="server">
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
    </form>
</body>
</html>
