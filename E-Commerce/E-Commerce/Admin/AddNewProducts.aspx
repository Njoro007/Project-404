<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddNewProducts.aspx.cs" Inherits="E_Commerce.Admin.AddNewProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../Assets/css/main.css" />

  

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="w3-container"  style="padding-left:20%; padding-right:20%;">
        <h2>Add New Product</h2>

        <table class="w3-table w3-striped w3-bordered">
            <tr>
                <th>Product Name:</th>
                <th><asp:TextBox id="txtProductName" runat="server"></asp:TextBox></th>
            </tr>
            <tr>
                <td>Product Category:</td>
                <td>
                    <asp:DropDownList ID="DropCategory" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>Product Description:</th>
                <th><asp:TextBox ID="txtProductDescription" runat="server"></asp:TextBox></th>
            </tr>
            <tr>
               <th>Product Image:</th>
                <th><asp:FileUpload ID="brwProductImage" runat="server"></asp:FileUpload></th>
            </tr>
            <tr>
               <th>Product Price:</th>
                <th><asp:TextBox ID="txtProductPrice" runat="server"></asp:TextBox></th>
            </tr>
            <tr>
                <th>
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"></asp:Button>
                </th>
            </tr>
        </table>
    </div>
</asp:Content>
