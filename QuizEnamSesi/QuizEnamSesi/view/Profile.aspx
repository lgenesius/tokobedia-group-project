<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="QuizEnamSesi.view.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="BtnToHome" runat="server" Text="< back to home" OnClick="BtnToHome_Click"/>
    </div>
    <div>
        <h1>USER PROFILE</h1>
    </div>
    <br />
    <div>
        <asp:Label ID="LblEmail" runat="server" Text="Email"></asp:Label>
        <h5 id="UserEmail" runat="server"></h5>
        <asp:Label ID="LblName" runat="server" Text="Name"></asp:Label>
        <h5 id="UserName" runat="server"></h5>
        <asp:Label ID="LblGender" runat="server" Text="Gender"></asp:Label>
        <h5 id="UserGender" runat="server"></h5>
    </div>

    <div>

        <asp:Button ID="BtnUpdateProfile" runat="server" Text="Update Profile" OnClick="GoToUpdateProfile" />

        <br />
        <asp:Button ID="BtnUpdatePassword" runat="server" Text="Update Password" OnClick="GoToUpdatePassword" />

    </div>
    </form>
</body>
</html>
