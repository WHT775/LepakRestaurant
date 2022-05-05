﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Boundary/MobileMaster.Master" AutoEventWireup="true" CodeBehind="PaymentPage.aspx.cs" Inherits="LepakRestaurant.Boundary.PaymentPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="mainPay" runat="server">
        <asp:Label ID="lblTableNum" runat="server"></asp:Label>
        <div id="itemDiv" runat="server">

        </div>
        <asp:Label ID="lblSubtotal" runat="server"></asp:Label>
        <br />
        <br />
        <asp:RadioButtonList ID="cardType" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem>Visa</asp:ListItem>
            <asp:ListItem>Debit</asp:ListItem>
        </asp:RadioButtonList>
        <asp:TextBox ID="cardNum" runat="server" placeholder="Card Number"></asp:TextBox>
        <asp:TextBox ID="cardExpiry" runat="server" placeholder="Card Expiry"></asp:TextBox>
        <asp:TextBox ID="CVV" runat="server" placeholder="CVV"></asp:TextBox>
        <asp:TextBox ID="cardName" runat="server" placeholder="Card holder name"></asp:TextBox>

        <br />
        <br />
        <asp:Label runat="server" Text="Coupon code:"></asp:Label>
        <asp:TextBox ID="couponTxt" runat="server" placeholder="Enter coupon code"></asp:TextBox>
        <asp:Button ID="checkCoupon" runat="server" Text="Check coupon" OnClick="checkCoupon_Click" UseSubmitBehavior="false"/>
        <asp:Label ID="lblDiscountTxt" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblFinalTotal" runat="server"></asp:Label>
        <asp:Button ID ="btnPayment" runat="server" Text="Complete Payment" OnClick="btnPayment_Click"/>
    </div>
    <div id="paySuccess" runat="server">
        <asp:Label ID="successText" runat="server" Text="Payment Successful."></asp:Label>
    </div>
</asp:Content>
