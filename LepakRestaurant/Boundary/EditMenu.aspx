<%@ Page Title="" Language="C#" MasterPageFile="~/Boundary/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditMenu.aspx.cs" Inherits="LepakRestaurant.Boundary.EditMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table id="tableStyle">
        <tr>
            <td colspan="2">
                <h1>
                    <asp:Label runat="server" ID="lbltitle" Width="100%"></asp:Label></h1>
            </td>
        </tr>
        <tr>
            <td>Name:</td>
            <td>
                <asp:TextBox runat="server" ID="txtName" Width="100%"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Description:</td>
            <td>
                <asp:TextBox runat="server" ID="txtDescription" Width="100%"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Price:</td>
            <td>
                <asp:TextBox runat="server" ID="txtCost" Width="100%" AutoCompleteType="Disabled"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Image:</td>
            <td style="float: left;">
                <asp:FileUpload runat="server" ID="fUpload" /></td>
        </tr>
        <tr>
            <td>Category:</td>
            <td>
                <asp:DropDownList runat="server" ID="ddlCategory" Width="100%" DataTextField="category_name" DataValueField="category_id"></asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label runat="server" ID="lblWrong" ForeColor="Red" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button runat="server" ID="btnCancel" OnClick="btnCancel_Click" Text="Cancel" Width="100%" />
            </td>
            <td>
                <asp:Button runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" Text="Create" Width="100%" />
            </td>
        </tr>
    </table>
</asp:Content>
