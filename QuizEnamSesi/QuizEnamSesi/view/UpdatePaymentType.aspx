<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePaymentType.aspx.cs" Inherits="QuizEnamSesi.view.UpdatePaymentType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Payment Type</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="BtnBack" runat="server" OnClick="BtnBack_Click" Text="&lt; Back" />
    </div>
    <div>
        <h1>UPDATE PAYMENT TYPE</h1>
    </div>
    <div>
        <asp:Label ID="Label1" runat="server" Text="Payment Type Name"></asp:Label>
        <asp:TextBox ID="TxtTypeName" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="LblError" runat="server" ForeColor="Red" Text=" "></asp:Label>
        <br />
        <br />
        <asp:Button ID="BtnSubmitType" runat="server" Text="Update" OnClick="DoUpdateType" />
    </div>
    </form>
</body>
</html>
