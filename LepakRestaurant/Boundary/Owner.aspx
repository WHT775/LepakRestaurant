<%@ Page Title="" Language="C#" MasterPageFile="~/Boundary/MasterPage.Master" AutoEventWireup="true" CodeBehind="Owner.aspx.cs" Inherits="LepakRestaurant.Boundary.Owner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        div{
            position: relative;
            margin-left: 230px;
            font-family: Arial, Helvetica, sans-serif;
            top: 10px;
        }
        .manage{
            top: 100px;
        }
        .adduser{
            top: 110px;
        }
        .grid{
            left: -110px;
            top: 115px;
        }
    </style>
    <asp:ScriptManager runat="server" ID="scriptManager1"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="upOwner" UpdateMode="Conditional">
        <ContentTemplate>
            <div style="text-align: center">
                <asp:Label runat="server" Text="Overall Customer Data" Width="100%"></asp:Label>
            </div>
            <div>
                <asp:GridView runat="server" ID="gvCustomerData"></asp:GridView>
            </div>
            <div class="manage" style="text-align: center;">
                <asp:Label runat="server" ID="manUsers" Text="Manage Users"></asp:Label>
            </div>
            <div class="adduser" style="text-align: center;">
                <asp:Button runat="server" ID="btnAddUsers" Text="Add User" OnClick="btnAddUsers_Click" />
            </div>
            <div class="grid">
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
