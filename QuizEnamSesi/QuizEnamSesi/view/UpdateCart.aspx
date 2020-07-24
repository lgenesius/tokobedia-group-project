<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateCart.aspx.cs" Inherits="QuizEnamSesi.view.UpdateCart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 382px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style1">
    
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">&lt; Back to View Cart</asp:LinkButton>
        <br />
        <div>
        <h1>Update Cart</h1>
    </div>
        <div>
        <h4>Item Quantity</h4>
        <asp:TextBox ID="TxtItemQuantity" runat="server" Text=""></asp:TextBox>
        <br />
    </div>
        <div>
        <asp:Label ID="TxtError" runat="server" ForeColor="Red" Text=" " ></asp:Label>
        <br />
        <asp:Button ID="BtnSubmit" runat="server" Text="Submit" OnClick="UpdateData" />
    </div>
    </div>
    </form>
</body>
</html>
