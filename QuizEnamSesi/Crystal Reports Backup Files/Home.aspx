<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="QuizEnamSesi.view.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <div>

    </div>

   <div>
       <h1 runat="server" id="Greetings">Welcome</h1>
   </div>

    <form id="form1" runat="server">
    <div>
        <asp:Button ID="BtnViewProduct" runat="server" Text="View Product" OnClick="ViewProduct"/>
        <span id="BtnForLoggedInUser" runat="server">
            <asp:Button ID="BtnViewProfile" runat="server" Text="View Profile" OnClick="ViewProfile" />
            <asp:Button ID="BtnViewCart" runat="server" OnClick="ViewCart" Text="View Cart" />
            <asp:Button ID="btnTransHis" runat="server" OnClick="btnTransHis_Click" Text="View Transaction History" />
            <asp:Button ID="BtnLogout" runat="server" Text="LOGOUT" OnClick="LogoutButton" />
        </span>
        <asp:Button ID="BtnLogin" runat="server" Text="Login" OnClick="ToLogin"/>
        <asp:Button ID="BtnRegister" runat="server" Text="Register" OnClick="ToRegister"/>
        
        <asp:GridView ID="GridRandomItem" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="productId" HeaderText="Product ID" />
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                <asp:BoundField DataField="ProductPrice" HeaderText="Product Price" />
                <asp:BoundField DataField="ProductStock" HeaderText="Product Stock" />
                <asp:TemplateField Visible ="false">
                    <ItemTemplate>
                        <asp:LinkButton ID = "BtnAddToCart" runat="server" Text="Add to Cart" CommandArgument='<%# Eval("productId") %>' OnClick="BtnAddToCart_Click"></asp:LinkButton>
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
        
    </div>

    <div runat="server" id="DivAdminPrivilege">
        <asp:Button runat="server" id="BtnViewUser" Text="View user" OnClick="BtnViewUser_Click"/>
        <br />
        <br />
        <asp:Button runat="server" id="BtnInsertProduct" Text="Insert Product" OnClick="BtnInsertProduct_Click"/>
        <br />
        <br />
        <asp:Button runat="server" id="BtnUpdateProduct" Text="Update Product" OnClick="BtnUpdateProduct_Click"/>
        &nbsp;<asp:TextBox ID="TxtInputProductId" runat="server"></asp:TextBox>
        <asp:Label ID="LblErrorProduct" runat="server" ForeColor="Red" Text="Input ID"></asp:Label>
        <br />
        <br />
        <asp:Button runat="server" id="BtnViewProductType" Text="View Product Type" OnClick="BtnViewProductType_Click"/>
        <br />
        <br />
        <asp:Button runat="server" id="BtnInsertProductType" Text="Insert Product Type" OnClick="BtnInsertProductType_Click"/>
        <br />
        <br />
        <asp:Button runat="server" id="BtnUpdateProductType" Text="Update Product Type" OnClick="BtnUpdateProductType_Click"/>
        <asp:TextBox ID="TxtInputProductTypeId" runat="server"></asp:TextBox>
        <asp:Label ID="LblErrorProductType" runat="server" ForeColor="Red" Text="Input ID"></asp:Label>
        <br />
        <br />
        <asp:Button runat="server" id="BtnViewPaymentType" Text="View Payment Type" OnClick="BtnViewPaymentType_Click"/>

    </div>
    </form>

    </body>
</html>
