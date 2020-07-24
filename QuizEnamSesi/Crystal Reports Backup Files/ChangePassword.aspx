<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="QuizEnamSesi.view.ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>CHANGE PASSWORD</h1>
    </div>
    <div>
        <asp:Label ID="Label1" runat="server" Text="Old Password"></asp:Label>
        &nbsp;<asp:TextBox ID="TxtOldPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="New Password "></asp:Label>
        <asp:TextBox ID="TxtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Confirm Password"></asp:Label>
        <asp:TextBox ID="TxtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="LblError" runat="server" ForeColor="Red" Text=" "></asp:Label>
        <br />
        <br />
        <asp:Button ID="BtnUpdate" runat="server" OnClick="BtnUpdate_Click" Text="Submit" />
    </div>
    </form>
</body>
</html>
