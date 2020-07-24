<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertPaymentType.aspx.cs" Inherits="QuizEnamSesi.view.InsertPaymentType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Insert Payment Type</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="BtnBack" runat="server" Text="&lt; Back" OnClick="BtnBack_Click" />
    </div>
    <div>
        <h1>INSERT PAYMENT TYPE</h1>
    </div>
        
    <div>
        <asp:Label ID="Label1" runat="server" Text="Payment Type Name"></asp:Label>
        <asp:TextBox ID="TxtTypeName" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="LblError" runat="server" ForeColor="Red" Text=" "></asp:Label>
        <br />
        <br />
        <asp:Button ID="BtnSubmitType" runat="server" OnClick="DoInsertNewType" Text="Submit" />
    </div>
    </form>
</body>
</html>
