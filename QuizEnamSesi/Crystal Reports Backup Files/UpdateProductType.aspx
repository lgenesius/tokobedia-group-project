<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateProductType.aspx.cs" Inherits="QuizEnamSesi.view.UpdateProductType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:Button ID="BtnBack" runat="server" OnClick="BtnBack_Click" Text="&lt; Back" />

    </div>
    <div>
        <h1>UPDATE PRODUCT TYPE</h1>
    </div>
    <div>
        <asp:Label ID="Label1" runat="server" Text="Product Type Name"></asp:Label>
        <asp:TextBox ID="TxtTypeName" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label>
        <asp:TextBox ID="TxtDescription" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="LblError" runat="server" ForeColor="Red" Text=" "></asp:Label>
        <br />
        <br />
        <asp:Button ID="BtnSubmitType" runat="server" Text="Submit" OnClick="DoUpdateType" />
    </div>
    </form>
</body>
</html>
