<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateProduct.aspx.cs" Inherits="QuizEnamSesi.view.UpdateProduct" %>

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
        <h1>UPDATE PRODUCT</h1>
        <asp:Label ID="Label1" runat="server" Text="Name "></asp:Label>
        <asp:TextBox ID="TxtNewName" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Stock "></asp:Label>
        <asp:TextBox ID="TxtNewStock" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Price "></asp:Label>
        <asp:TextBox ID="TxtNewPrice" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="LblError" runat="server" ForeColor="Red" Text=" "></asp:Label>
        <br />
        <br />
        <asp:Button ID="BtnSubmit" runat="server" OnClick="UpdateData" Text="Update" />
        <br />
    </div>
    </form>
</body>
</html>
