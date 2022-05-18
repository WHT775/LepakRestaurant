<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenerateQR.aspx.cs" Inherits="LepakRestaurant.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        img.one {
            width:270px;
            position: relative;
            display:block;
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
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
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
            <asp:Image runat="server" ID="Table5"  CssClass="tableqr5"/>
            </td>
            <td>
            <img class="one" src="tableimg.png" />
            <asp:Image runat="server" ID="Table6" CssClass="tableqr6"/>
            </td>
            </tr>
            </table>
        </div>
    </form>
</body>
</html>
