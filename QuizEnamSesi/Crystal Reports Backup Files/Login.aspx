<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="QuizEnamSesi.view.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="BtnBack" runat="server" Text="<Back To Home" OnClick="BtnBack_Click" />
    </div>
    <div>
        <h1>LOGIN</h1>
        <p>Email&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="LoginEmail" runat="server"></asp:TextBox>
        </p>
        <p>Password&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="LoginPassword" runat="server" TextMode="Password"></asp:TextBox>
        </p>
        <p>
            <asp:CheckBox ID="ChkRemember" runat="server" Text="Remember Me" />
        </p>
        <p>
            <asp:Label ID="LblError" runat="server" Text=" " ForeColor="Red"></asp:Label>
        </p>
    </div>
        <asp:Button ID="BtnLogin" runat="server" OnClick="BtnLogin_Click" Text="Login" />
    </form>
</body>
</html>
