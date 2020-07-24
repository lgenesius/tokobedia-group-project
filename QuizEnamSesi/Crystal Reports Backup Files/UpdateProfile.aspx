<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="QuizEnamSesi.view.UpdateProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

    <div>
        <h1>UPDATE YOUR PROFILE</h1>
    </div>
    <div>
        
        <asp:Label ID="Label2" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Gender"></asp:Label>
        <asp:RadioButtonList ID="RadioGender" runat="server">
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Label ID="LblError" runat="server" ForeColor="Red" Text=" "></asp:Label>
        <br />
        <br />
        <asp:Button ID="BtnUpdateProfile" runat="server" OnClick="BtnUpdateProfile_Click" Text="Submit" />
        
    </div>

    </form>
</body>
</html>
