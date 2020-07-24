<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddToCartPage.aspx.cs" Inherits="QuizEnamSesi.view.AddToCartPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 464px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style1">
    
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">&lt; Back to View Product</asp:LinkButton>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="25pt" Text="Add to Cart"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Product Name : "></asp:Label>
        <asp:Label ID="LabelName" runat="server" Text="Label Product Name"></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Product Price : "></asp:Label>
        <asp:Label ID="LabelPrice" runat="server" Text="Label Product Price"></asp:Label>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Product Stock : "></asp:Label>
        <asp:Label ID="LabelStock" runat="server" Text="Label Product Stock"></asp:Label>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Product Type : "></asp:Label>
        <asp:Label ID="LabelType" runat="server" Text="Label Product Type"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Quantity to Add to Cart : "></asp:Label>
        <asp:TextBox ID="TBStock" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="BtnAddCart" runat="server" OnClick="BtnAddCart_Click" Text="Add to Cart" />
        <br />
        <asp:Label ID="LblError" runat="server" ForeColor="Red" Text="[ Error Message ]" Visible="False"></asp:Label>
    
    </div>
    </form>
</body>
</html>
