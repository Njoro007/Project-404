<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="E_Commerce.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1 {
            width: 900px;
        }

        .style2 {
            width: 633px;
            text-align: left;
        }

        .style3 {
            width: 257px;
            text-align: left;
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
                            <table class="style1" style="border-width: medium;">
                                <tr>
                                    <td class="style8" rowspan="2">
                                        <asp:Image ID="Image1" runat="server" Height="83px" Width="110px" ImageUrl="~/Assets/logo.png" />
                                        &nbsp
                                    </td>
                                    <td class="style6" rowspan="2">&nbsp
                                    </td>
                                    <td class="style7" rowspan="2">&nbsp
                                    </td>
                                    <td rowspan="2" align="right">
                                        <asp:Image ID="Image2" runat="server" Height="43px" Width="60px" ImageUrl="~/Assets/Cart.png" />
                                    </td>
                                    <td align="left">
                                        <asp:LinkButton ID="btnShoppingCart" runat="server" Font-Size="20pt" ForeColor="BurlyWood">0</asp:LinkButton>
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
                            <table align="center" class="style1" style="border: thin ridge #00ff90">
                                <tr>
                                    <td class="style3" style="border-left-style: ridge;">&nbsp
                                        <asp:Label ID="lblProducts" Text="Products" Font-Size="15pt" runat="server"></asp:Label>
                                    </td>
                                    <td class="style2">
                                        <asp:Label ID="lblCategoryName" Font-Size="15pt" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table align="center" class="style1">
                                <tr>
                                    <td class="style2" valign="top">
                                        <asp:Panel runat="server" ID="pnlProducts" ScrollBars="Auto" Height="500px" BorderStyle="Inset" BorderWidth="1px">
                                            <asp:DataList runat="server" ID="dlProducts" RepeatColumns="3" Width="600px" Font-Bold="false" Font-Italic="false" Font-Overline="false" Font-Strikeout="false" Font-Underline="false">
                                                <ItemTemplate>
                                                    <div align="left">
                                                        <table cellspacing="1" class="style4" style="border: 1px ridge;">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("Name") %>' Style="font-weight: 700;"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <img alt="" src="<%# Bind('ImageUrl')%>" runat="server" id="imgProductPhoto" style="border: ridge 1px; width: 173px; height: 160px;" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Price:
                                                                    <asp:Label runat="server" ID="lblPrice" Text="<%# Bind('Price') %>"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="btnAddToCart" runat="server" CommandArgument="<%# Bind('ProductID') %>" Text="Add To Cart" Width="100%" BorderStyle="Inset" BorderWidth="1px" OnClick="btnAddToCart_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </asp:Panel>
                                    </td>
                                    <td class="style3" valign="top" align="center">
                                        <asp:Panel ID="pnlCategories" runat="server" ScrollBars="Auto" Height="500px" BorderStyle="Inset" BorderWidth="1px">
                                            <asp:DataList ID="dlCategories" runat="server" BorderStyle="None" BorderWidth="1px" CellPadding="4" GridLines="Horizontal" Width="252px" >
                                                <FooterStyle BackColor="Beige" ForeColor="Black" />
                                                <HeaderStyle BackColor="BurlyWood" ForeColor="White" Font-Bold="true" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtnCategory" runat="server" Text="<%# Bind('CategoryName') %>" CommandArgument="<%# Bind('CategoryID') %>" ></asp:LinkButton>
                                                </ItemTemplate>
                                                <SelectedItemStyle BackColor="AppWorkspace" Font-Bold="true" ForeColor="GreenYellow" />
                                            </asp:DataList>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>

            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
