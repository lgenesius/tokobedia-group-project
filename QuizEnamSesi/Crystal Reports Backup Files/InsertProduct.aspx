<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertProduct.aspx.cs" Inherits="QuizEnamSesi.view.InsertProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="BtnBack" runat="server" Text="< Back" OnClick="BtnBack_Click" />
    </div>
    <div>
        <h1>INSERT NEW PRODUCT</h1>
    </div>
    <div>
     
        <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="TxtProductName" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Stock"></asp:Label>
        <asp:TextBox ID="TxtProductStock" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Price"></asp:Label>
     
        <asp:TextBox ID="TxtProductPrice" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:GridView ID="GridProductType" runat="server">
        </asp:GridView>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Product Type"></asp:Label>
     
        <asp:TextBox ID="TxtProductType" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="LblError" runat="server" ForeColor="Red" Text=" "></asp:Label>
        <br />
        <br />
        <asp:Button ID="BtnSubmit" runat="server" OnClick="BtnSubmit_Click" Text="Input" />
     
    </div>
    </form>
</body>
</html>
