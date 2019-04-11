<%@ Page Title="Drinks Shopping" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="E_Commerce.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="Assets/css/main.css" />
    <meta name="viewport" content="width=device-width,initial-scale=1.0" />
    <style type="text/css">
        table {
            opacity: 0.98;
            background-color: white;
            border-radius: 20px;
        }

        body {
            margin: auto;
            width: 100%;
            border: 3px solid #deb887;
            padding: 4%;
            background-image: url("Assets/background2.jpg");
            opacity: 5;
            background-repeat: round;
            background-attachment: fixed;
        }

        .style1 {
            width: 1200px;
        }

        .style2 {
            width: 800px;
            text-align: left;
        }

        .style3 {
            width: 257px;
            text-align: center;
            font-family: Perpetua;
            font-size: larger;
            text-decoration: none;
        }

        .catlist:hover {
            text-decoration: underline;
            -webkit-transform: scale(1.2);
            font-size: x-large;
        }

        .style4 {
            width: 185px;
            text-align: center;
        }

        .style6 {
            width: 260px;
            text-align: left;
        }

        .style7 {
            width: 427px;
            text-align: center;
        }

        .style8 {
            width: 108px;
            text-align: center;
        }

        .auto-style1 {
            width: 61px;
        }

        .link {
            text-decoration: none;
            text-decoration: underline;
            -webkit-transform: scale(1.2);
            font-size:large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table align="center" class="style1">
                    <tr>
                        <td>
                            <table align="center" class="style1" style="border-width: medium;">
                                <tr>
                                    <td class="style8" rowspan="2">
                                        <asp:LinkButton ID="lblLogo" runat="server" OnClick="lblLogo_Click" CssClass="link">
                                            <asp:Image ID="Image1" runat="server" Height="83px" Width="110px" ImageUrl="~/Assets/logo.png" />
                                        </asp:LinkButton>
                                        &nbsp
                                    </td>
                                    <td class="style6" rowspan="2" style="font-family: cursive,fantasy; font-size: xx-large; color: burlywood;">&nbsp
                                        On Break...?
                                    </td>
                                    <td class="style7" rowspan="2">&nbsp
                                    </td>
                                    <td rowspan="2" align="right" class="auto-style1">
                                        <asp:Image ID="Image2" runat="server" Height="43px" Width="60px" ImageUrl="~/Assets/Cart.png" />
                                    </td>
                                    <td align="left">
                                        <asp:LinkButton ID="btnShoppingCart" runat="server" Font-Size="20pt" ForeColor="BurlyWood" OnClick="btnShoppingCart_Click">0</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3" valign="middle">&nbsp
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table align="center" class="style1">
                                <tr>
                                    <td class="style2">&nbsp
                                        <asp:Label ID="lblCategoryName" runat="server"></asp:Label>
                                    </td>
                                    <td class="style3">&nbsp
                                        <asp:Label ID="lblProducts" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="style1" align="center">
                                <tr>
                                    <td class="style2" valign="top">
                                        <asp:Panel runat="server" ID="pnlProducts" ScrollBars="Auto" Height="500px" BorderStyle="Inset" BorderWidth="1px">
                                            <asp:DataList runat="server" ID="dlProducts" RepeatColumns="4" Width="600px" Font-Bold="false" Font-Italic="false" Font-Overline="false" Font-Strikeout="false" Font-Underline="false">
                                                <ItemTemplate>
                                                    <!--<div align="left">-->
                                                    <div style="align-content: space-around;">
                                                        <table cellspacing="1" class="style4" style="border: 1px ridge;">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("Name") %>' Style="font-weight: 700;"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <img alt="" src='<%# Eval("ImageUrl")%>' runat="server" id="imgProductPhoto" style="border: ridge 1px; width: 173px; height: 160px;" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Price:
                                                                   
                                                                    <asp:Label runat="server" ID="lblPrice" Text='<%# Eval("Price") %>'></asp:Label>
                                                                    /= Stock:&nbsp
                                                                   
                                                                    <asp:Label ID="lblAvailableStock" runat="server" Text='<%# Eval("AvailableStock") %>' ToolTip="Available Stock" ForeColor="BurlyWood"></asp:Label>
                                                                    <asp:HiddenField ID="hfProductID" runat="server" Value='<%# Eval("ProductID") %>' />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="btnAddToCart" runat="server" CommandArgument='<%# Eval("ProductID") %>' Text="Add To Cart" Width="100%" BorderStyle="Inset" BorderWidth="1px" OnClick="btnAddToCart_Click" CausesValidation="false" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle Width="33%" />
                                            </asp:DataList>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlMyCart" runat="server" Visible="false" ScrollBars="Auto" Height="500px" BorderColor="BurlyWood" BorderStyle="Inset">
                                            <table align="center" cellspacing="1">
                                                <tr>
                                                    <td align="center">
                                                        <asp:Label ID="lblAvailableStockAlert" runat="server" Font-Bold="true" ForeColor="BurlyWood"></asp:Label>
                                                        <asp:DataList ID="dlCartProducts" runat="server" repeatColumn="4" Font-Bold="false" Font-Italic="false" Font-Overline="false" Font-Strikeout="false" Font-Underline="false" Width="750px" OnSelectedIndexChanged="dlCartProducts_SelectedIndexChanged">
                                                            <ItemTemplate>
                                                                <div align="left">
                                                                    <table cellspacing="1" style="border: 1px ridge; text-align: center;">
                                                                        <tr>
                                                                            <td style="border-bottom-style: ridge; border-color: #deb887;">
                                                                                <asp:Label ID="lblProductName" runat="server" Style="font-weight: 700;" Text='<%# Eval("Name") %>'></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <img alt="" src='<%# Eval("ImageUrl")%>' runat="server" id="imgProductPhoto" style="border: ridge 1px; width: 157px; height: 130px;" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>AvailableStock:&nbsp;
                                                                            <asp:Label ID="lblAvailableStock" runat="server" ForeColor="BurlyWood" Text='<%# Eval("AvailableStock") %>' ToolTip="Available Stock"></asp:Label>
                                                                                <br />
                                                                                Price<asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                                                                &nbsp;x
                                                                            <asp:TextBox ID="txtProductQuantity" runat="server" Height="10px" Width="10px" MaxLength="1" OnTextChanged="txtProductQuantity_TextChanged" AutoPostBack="true" Text='<%# Eval("ProductQuantity") %>'></asp:TextBox>
                                                                                &nbsp;<asp:HiddenField ID="hfProductID" runat="server" Value='<%# Eval("ProductID") %>' />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <hr />
                                                                                <asp:Button ID="btnRemoveFromCart" runat="server" BorderStyle="Inset" BorderWidth="1px" CausesValidation="false" CommandArgument='<%# Eval("ProductID") %>' OnClick="btnAddToCart_Click" Text="Remove From Cart" Width="100%" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="33%" />
                                                        </asp:DataList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                    <td class="style3" valign="top" align="center">
                                        <asp:Panel ID="pnlCategories" runat="server" ScrollBars="Auto" Height="500px" BorderStyle="Inset" BorderWidth="1px">
                                            <asp:DataList ID="dlCategories" runat="server" BorderStyle="None" BorderWidth="1px" CellPadding="4" GridLines="Horizontal" Width="252px" OnSelectedIndexChanged="dlCategories_SelectedIndexChanged">
                                                <FooterStyle BackColor="Beige" ForeColor="Black" />
                                                <HeaderStyle BackColor="BurlyWood" ForeColor="White" Font-Bold="true" />
                                                <ItemTemplate>
                                                    <asp:LinkButton CssClass="link" ID="lbtnCategory" runat="server" Text='<%# Eval("CategoryName") %>' CommandArgument='<%# Eval("CategoryID") %>' OnClick="lbtnCategory_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                                <SelectedItemStyle BackColor="AppWorkspace" Font-Bold="true" ForeColor="GreenYellow" />
                                            </asp:DataList>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlCheckOut" ScrollBars="Auto" Height="500px" BorderStyle="Inset" BorderWidth="1px" Visible="false" runat="server">
                                            <table style="width: 259px">
                                                <tr>
                                                    <td align="left">Name:
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtCustomerName" Width="231px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtCustomerName" ErrorMessage="*" ForeColor="red"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">Phone No.:
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtCustomerPhoneNo" Width="231px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" maxlength="10" ControlToValidate="txtCustomerPhoneNo" ErrorMessage="*" ForeColor="red"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">Customer Email:
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtCustomerEmailID" Width="231px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="txtCustomerEmailID" ErrorMessage="*" ForeColor="red"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">Address:
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">&nbsp; 
                                                       
                                                        <asp:TextBox ID="txtCustomerAddress" Width="227" Height="81px" TextMode="MultiLine" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="txtCustomerAddress" ErrorMessage="*" ForeColor="red"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">Total Products:
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtTotalProducts" Width="231px" ReadOnly="True"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="txtTotalProducts" ErrorMessage="*" ForeColor="red"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">Total Price:
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtTotalPrice" Width="231px" ReadOnly="true"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator6" ControlToValidate="txtTotalPrice" ErrorMessage="*" ForeColor="red"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">Payment Mode:
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:RadioButtonList ID="rblPaymentMethod" runat="server">
                                                            <asp:ListItem Value="1">
                                                                Cash On Delivery
                                                            </asp:ListItem>
                                                            <asp:ListItem Value="2" Selected="True">
                                                                Mobile Payment
                                                            </asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button OnClick="btnPlaceOrder_Click" ID="btnPlaceOrder" runat="server" Text="CheckOut" Style="width: 90px; font-weight: 700;" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <!--Regular Expression validator for email missing-->
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Panel ID="pnlEmptyCart" runat="server" Visible="false">
                                            <div style="text-align: center;">
                                                <br />
                                                <div style="align-content: center; text-align: center; ">
                                                    <h1>Whoops! Your cart is still empty :)</h1>
                                                </div>
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <asp:Image ID="Image3" runat="server" ImageUrl="~/Assets/Empty.png" />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                            </div>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlOrderPlacedSuccessfully" runat="server" Visible="false">
                                            <div style="text-align: center;">
                                                <asp:Image ID="Image4" runat="server" ImageUrl="~/Assets/successful.png" />
                                                <br />
                                                <br />
                                                <asp:Label ID="Label1" runat="server" Text="Order has been succesfully placed!"></asp:Label>
                                                <br />
                                                Transaction Details will be sent at the email ID provided by you!
                                               
                                                <br />
                                                <br />
                                                <asp:Label ID="lblTransactionNo" runat="server" Font-Bold="true"></asp:Label>
                                                <br />
                                                <br />
                                                <br />
                                                <a href="#" target="_blank">Track your order</a>
                                                <br />
                                                <br />
                                                <br />
                                            </div>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div style="align-content: center; align: center; background-color: burlywood; opacity: 0.9; border-radius: 20px; width: 1200px; color: white;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           
            <asp:Label ID="Label2" runat="server" Text="CMT 423 E-COMMERCE PROJECT"></asp:Label>
            &nbsp;||&nbsp;
            <asp:LinkButton ID="btnAdmin" runat="server" OnClick="btnAdmin_Click">Administrator Panel</asp:LinkButton>
            &nbsp;||&nbsp;
            <asp:Label ID="Label3" runat="server" Text="2019"></asp:Label>
        </div>
    </form>
</body>
</html>
