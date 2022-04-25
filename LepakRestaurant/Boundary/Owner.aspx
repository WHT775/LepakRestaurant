<%@ Page Title="" Language="C#" MasterPageFile="~/Boundary/MasterPage.Master" AutoEventWireup="true" CodeBehind="Owner.aspx.cs" Inherits="LepakRestaurant.Boundary.Owner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%; text-align: center">
        <asp:Label runat="server" Text="Overall Customer Data" Width="100%"></asp:Label>
    </div>
    <asp:GridView runat="server" ID="gvCustomerData"></asp:GridView>
    <div style="width: 100%; text-align: center;">
        <asp:Label runat="server" Text="Manager Users" Width="100%"></asp:Label>
        <asp:Button runat="server" ID="btnAddUsers" Text="Add User" OnClick="btnAddUsers_Click" />
    </div>
    <asp:ScriptManager runat="server" ID="scriptMangager"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="upUsers">
        <ContentTemplate>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
