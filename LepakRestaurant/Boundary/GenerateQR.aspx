<%@ Page Title="" Language="C#" MasterPageFile="~/Boundary/MasterPage.Master" AutoEventWireup="true" CodeBehind="GenerateQR.aspx.cs" Inherits="LepakRestaurant.Boundary.GenerateQR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        img.one {
            width: 270px;
            position: relative;
            display: block;
        }

        .tableqr1 {
            position: absolute;
            top: 50px;
            left: 75px;
        }

        .tableqr2 {
            position: absolute;
            top: 50px;
            left: 350px;
        }

        .tableqr3 {
            position: absolute;
            top: 290px;
            left: 75px;
        }

        .tableqr4 {
            position: absolute;
            top: 290px;
            left: 350px;
        }

        .tableqr5 {
            position: absolute;
            top: 525px;
            left: 75px;
        }

        .tableqr6 {
            position: absolute;
            top: 525px;
            left: 350px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="txtTableId" ></asp:TextBox>
                </td>
                <td>
                    <asp:Button runat="server" ID="btnGenerateQrCode" Text="Generate" OnClick="btnGenerateQrCode_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <img class="one" src="tableimg.png" />
                    <asp:Image runat="server" ID="Table1" CssClass="tableqr1" />
                </td>
                <td>
                    <img class="one" src="tableimg.png" />
                    <asp:Image runat="server" ID="Table2" CssClass="tableqr2" />
                </td>
            </tr>
            <tr>
                <td>
                    <img class="one" src="tableimg.png" />
                    <asp:Image runat="server" ID="Table3" CssClass="tableqr3" />
                </td>
                <td>
                    <img class="one" src="tableimg.png" />
                    <asp:Image runat="server" ID="Table4" CssClass="tableqr4" />
                </td>
            </tr>
            <tr>
                <td>
                    <img class="one" src="tableimg.png" />
                    <asp:Image runat="server" ID="Table5" CssClass="tableqr5" />
                </td>
                <td>
                    <img class="one" src="tableimg.png" />
                    <asp:Image runat="server" ID="Table6" CssClass="tableqr6" />
                </td>
            </tr>
                    <tr>
            <td colspan="2">
                <asp:Label runat="server" ID="lblWrong" ForeColor="Red" Visible="false"></asp:Label>
            </td>
        </tr>
        </table>
    </div>
</asp:Content>
