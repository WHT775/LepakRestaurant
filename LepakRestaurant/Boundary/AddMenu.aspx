<%@ Page Title="" Language="C#" MasterPageFile="~/Boundary/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddMenu.aspx.cs" Inherits="LepakRestaurant.Boundary.AddMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
    table{
            margin-left: 825px;
            font-family: Arial, Helvetica, sans-serif;
        }    
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="tableStyle">
        <tr>
            <td colspan="2">
                <h1>
                    <asp:Label runat="server" ID="lbltitle"></asp:Label></h1>
            </td>
        </tr>
        <tr>
            <td>Name:</td>
            <td>
                <asp:TextBox runat="server" ID="txtName"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Description:</td>
            <td>
                <asp:TextBox runat="server" ID="txtDescription"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Price:</td>
            <td>
                <asp:TextBox runat="server" ID="txtCost" AutoCompleteType="Disabled"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Image:</td>
            <td style="float: left;">
                <asp:FileUpload runat="server" ID="fUpload" /></td>
        </tr>
        <tr>
            <td>Category:</td>
            <td>
                <asp:DropDownList runat="server" ID="ddlCategory" DataTextField="category_name" DataValueField="category_id"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>Status:</td>
            <td>
                <asp:DropDownList runat="server" ID="ddlStatus" DataTextField="status_name" DataValueField="status_id"></asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label runat="server" ID="lblWrong" ForeColor="Red" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button runat="server" ID="btnCancel" OnClick="btnCancel_Click" Text="Cancel"/>
            </td>
            <td>
                <asp:Button runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" Text="Create"/>
            </td>
        </tr>
    </table>
</asp:Content>
