    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewProduct.aspx.cs" Inherits="QuizEnamSesi.view.ViewProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:Button ID="BtnToHome" runat="server" OnClick="BtnToHome_Click" Text="&lt; Go To Home" />

    </div>
    <div>
        <h1>Item List</h1>
    </div>
    <div>
        <asp:GridView ID="GridAllItem" runat="server" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Product ID" />
                <asp:BoundField DataField="ProductType" HeaderText="Product Type" />
                <asp:BoundField DataField="Name" HeaderText="Product Name" />
                <asp:BoundField DataField="Price" HeaderText="Product Price" />
                <asp:BoundField DataField="Stock" HeaderText="Product Stock" />
                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:LinkButton ID = "BtnUpdateProduct" runat="server" Text="Update" CommandArgument='<%# Eval("Id") %>' OnClick="BtnUpdateProduct_Click"></asp:LinkButton>
                        <asp:LinkButton ID = "BtnDeleteProduct" runat="server" Text="Delete" CommandArgument='<%# Eval("Id") %>' OnClick="BtnDeleteProduct_Click"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible ="false">
                    <ItemTemplate>
                        <asp:LinkButton ID = "BtnAddToCart" runat="server" Text="Add to Cart" CommandArgument='<%# Eval("Id") %>' OnClick="BtnAddToCart_Click"></asp:LinkButton>
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
        <br />
        <br />
        <asp:Label ID="LblError" runat="server" Text=" " ForeColor="Red"></asp:Label>
    </div>
    <div runat="server" id="BtnForAdmin">
        <br />
        <asp:Button ID="BtnInsertProduct" runat="server" Text="Insert Product" OnClick="BtnInsertProduct_Click" />
    </div>
    </form>
</body>
</html>
