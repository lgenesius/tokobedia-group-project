<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="QuizEnamSesi.view.Register" %>

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
        <h1>REGISTER</h1>
    </div>
    <div>


        <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
&nbsp;<asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Password"></asp:Label>


        <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Repeat Password"></asp:Label>


        <asp:TextBox ID="TxtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        Gender<br />
        <asp:RadioButtonList ID="RadioGender" runat="server">
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:Label ID="LblError" runat="server" ForeColor="Red" Text=" "></asp:Label>
        <br />
        <br />
        <asp:Button ID="BtnRegister" runat="server" Text="Register" OnClick="BtnRegister_Click" ForeColor="Black" />
        <br />
    </div>
    </form>
</body>
</html>
