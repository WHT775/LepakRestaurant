<%@ Page Title="" Language="C#" MasterPageFile="~/Boundary/MobileMaster.Master" AutoEventWireup="true" CodeBehind="PaymentPage.aspx.cs" Inherits="LepakRestaurant.Boundary.PaymentPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="mainPay" runat="server">
        <div style="display: inline-flex;">
            <h3><span style="left: 20px; position: absolute;">Payment</span></h3>
            <h3>
                <asp:Label ID="lblTableNum" runat="server" CssClass="tblNum"></asp:Label></h3>
        </div>
        <br />
        <br />
        <div id="itemDiv" runat="server">
        </div>
        
        <br />
        <br />
        <asp:RadioButtonList ID="cardType" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem>Visa</asp:ListItem>
            <asp:ListItem>Master Card</asp:ListItem>
        </asp:RadioButtonList>
        <asp:TextBox ID="cardNum" runat="server" placeholder="Card Number" MaxLength="16"></asp:TextBox>
        <asp:TextBox ID="cardExpiry" runat="server" placeholder="Card Expiry" TextMode="Date"></asp:TextBox>
        <asp:TextBox ID="CVV" runat="server" placeholder="CVV" MaxLength="3"></asp:TextBox>
        <asp:TextBox ID="cardName" runat="server" placeholder="Card holder name"></asp:TextBox>
        <asp:Label ID="lblCardError" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label runat="server" Text="Coupon code:"></asp:Label>
        <asp:TextBox ID="couponTxt" runat="server" placeholder="Enter coupon code"></asp:TextBox>
        <asp:Button ID="checkCoupon" runat="server" Text="Check coupon" OnClick="checkCoupon_Click" UseSubmitBehavior="false" />
        <asp:Label ID="lblDiscountTxt" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblSubtotal" runat="server"></asp:Label>
        <asp:Label ID="lblGst" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblFinalTotal" runat="server"></asp:Label>
        <br />
        <asp:Button ID="btnPayment" runat="server" Text="Complete Payment" OnClick="btnPayment_Click" />
    </div>
    <div class="fullandcenter" style="display: block !important" id="paySuccess" runat="server">
        <br />
        <asp:Label ID="successText" runat="server" Text="Payment Successful."></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnCont" runat="server" Text="Continue" OnClick="btnCont_Click" />
    </div>
</asp:Content>
