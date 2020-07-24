<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCart.aspx.cs" Inherits="QuizEnamSesi.view.ViewCart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 769px;
        }
    </style>
</head>
<body style="height: 769px">
    <form id="form1" runat="server">
    <div class="auto-style1">
    
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">&lt; Back to Home</asp:LinkButton>
        <br />
    <div>
        <h1>Cart</h1>
    </div>
        <div>
        <asp:GridView ID="GridAllCart" runat="server" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                <asp:BoundField DataField="productId" HeaderText="Product ID" />
                <asp:BoundField DataField="productName" HeaderText="Product Name" />
                <asp:BoundField DataField="productPrice" HeaderText="Product Price" />
                <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                <asp:BoundField DataField="subTotal" HeaderText="Subtotal" />
                <asp:TemplateField Visible="true">
                    <ItemTemplate>
                        <asp:LinkButton ID = "BtnUpdateProduct" runat="server" Text="Update" CommandArgument='<%# Eval("productId") %>' OnClick="UpdateCartItem"></asp:LinkButton>
                        <asp:LinkButton ID = "BtnDeleteProduct" runat="server" Text="Delete" CommandArgument='<%# Eval("productId") %>' OnClick="DeleteCartItem"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:Label ID="ErrorMsg" runat="server" Text=" "></asp:Label>
        <h3>Grand Total:</h3>
        <asp:Label ID="GrandTotal" runat="server" Text="No Items"></asp:Label>
        <br />
    </div>
        <div>

            <br />
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Select Payment Type Before Checkout"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Select Payment Type ID : "></asp:Label>
            <asp:TextBox ID="TBPayment" runat="server"></asp:TextBox>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <br />

        </div>
        <div>
        <asp:Button ID="BtnCheckout" runat="server" Text="Checkout" OnClick="BtnCheckout_Click" />
            <br />
            <asp:Label ID="LblError" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
    </div>
    </div>
    </form>
</body>
</html>
