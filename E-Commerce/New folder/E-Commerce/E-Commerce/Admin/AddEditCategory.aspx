<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddEditCategory.aspx.cs" Inherits="E_Commerce.Admin.AddEditCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="w3-container"  style="padding-left:20%; padding-right:20%;">
        <h2>Add New Category</h2>

        <table class="w3-table w3-striped w3-bordered">
            <tr>
                <td>Product Category:</td>
                <td><asp:TextBox ID="txtCategory" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"></asp:Button>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
