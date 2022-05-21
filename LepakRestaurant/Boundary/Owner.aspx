<%@ Page Title="" Language="C#" MasterPageFile="~/Boundary/MasterPage.Master" AutoEventWireup="true" CodeBehind="Owner.aspx.cs" Inherits="LepakRestaurant.Boundary.Owner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        /*        div {
            position: relative;
            margin-left: 230px;
            font-family: Arial, Helvetica, sans-serif;
            top: 10px;
        }*/

        /*        .manage {
            top: 100px;
        }

        .adduser {
            top: 110px;
        }*/

        table {
            margin: 0 auto;
        }

        .grid {
            left: -110px;
            top: 115px;
        }
        /*body {font-family: Arial;}*/
        div {
            font-family: Arial, Helvetica, sans-serif;
        }
        /* Style the tab */
        .tab {
            overflow: hidden;
            border: 1px solid #ccc;
            background-color: #f1f1f1;
            /*width:100%;*/
            text-align: center;
            width: 100vw;
        }

            /* Style the buttons inside the tab */
            .tab input[type="submit"] {
                background-color: inherit;
                border: none;
                outline: none;
                cursor: pointer;
                padding: 14px 16px;
                transition: 0.3s;
                font-size: 17px;
                height: auto;
                color: black;
            }

                /* Change background color of buttons on hover */
                .tab input[type="submit"]:hover {
                    background-color: #ddd;
                }

                /* Create an active/current tablink class */
                .tab input[type="submit"].active {
                    background-color: #ccc;
                }

        /* Style the tab content */
        .tabcontent {
            display: none;
            padding: 6px 12px;
            border: 1px solid #ccc;
            border-top: none;
        }
    </style>
    <asp:ScriptManager runat="server" ID="scriptManager1"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="upOwner" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="tab">
                <asp:Button runat="server" CssClass="tablinks" Text="Customer Insights" ID="btnInsightsTab" OnClick="btnInsightsTab_Click" />
                <asp:Button runat="server" CssClass="tablinks" Text="Manage User" ID="btnUserTab" OnClick="btnUserTab_Click" />
                <asp:Button runat="server" CssClass="tablinks" Text="Generate QR Code" ID="btnQrCode" OnClick="btnQrCode_Click" />
            </div>
            <div id="divInsights" runat="server" class="tabcontent">
                <div style="text-align: center">
                    <h1>
                        <asp:Label runat="server" Text="Overall Customer Data" Width="100%" ></asp:Label></h1>
                    <div>
                        <h3 style="display:contents"><asp:Label runat="server" Text="Customer Data: "></asp:Label></h3>
                        <asp:DropDownList runat="server" ID="ddlInsights" OnSelectedIndexChanged="ddlInsights_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Text="Average Spending" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Most Menu Preferred"></asp:ListItem>
                            <asp:ListItem Text="Cancelled Order"></asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <br />
                        <asp:GridView runat="server" ID="gvStatistics">
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <div id="divUsers" runat="server" class="tabcontent">
                <div class="manage" style="text-align: center;">
                    <h1>
                        <asp:Label runat="server" ID="manUsers" Text="Manage Users"></asp:Label></h1>
                </div>
                <div class="adduser" style="text-align: center;">
                    <asp:Button runat="server" ID="btnAddUsers" Text="Add User" OnClick="btnAddUsers_Click" />
                </div>
                <br />
                <div style="text-align: center; width: 100%;">
                    <asp:GridView runat="server" ID="gvUsers" AutoGenerateColumns="false" OnRowCommand="gvUsers_RowCommand" OnRowDeleting="gvUsers_RowDeleting" OnRowDataBound="gvUsers_RowDataBound">
                        <Columns>
                            <asp:BoundField HeaderText="Username" DataField="user_id" />
                            <asp:BoundField HeaderText="Role" DataField="Roles.role_name" />
                            <asp:BoundField HeaderText="Disabled" DataField="is_deleted" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button runat="server" CommandName="Edit" CommandArgument='<%#Eval("id") %>' Text="Edit" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="btnDelete" CommandName="Delete" CommandArgument='<%#Eval("id") %>' Text="Delete" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div id="divQrCode" runat="server" class="tabcontent">
                <div class="manage" style="text-align: center;">
                    <h1>
                        <asp:Label runat="server" ID="lblQrCode" Text="Generate QR Code"></asp:Label></h1>
                </div>
                <table>
                    <tr>
                        <td>
                            <h3>
                                <asp:Label runat="server" Text="Table Number:"></asp:Label></h3>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtTableId" TextMode="Number"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button runat="server" ID="btnGenerateQrCode" Text="Generate" OnClick="btnGenerateQrCode_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Label runat="server" ID="lblWrong3" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table style="width: 100%; text-align: center;">
                    <tr>
                        <td colspan="2">
                            <h2>
                                <asp:Label runat="server" ID="lblTitle"></asp:Label></h2>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 50%; border-right: 1px solid black;">
                            <asp:Image runat="server" ID="imgQrCode" Height="200px" AlternateText="" /></td>
                        <td style="width: 50%">
                            <asp:Label runat="server" ID="lblUniqueCode"></asp:Label>
                            <br />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
