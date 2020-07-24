<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewUser.aspx.cs" Inherits="QuizEnamSesi.view.ViewUser" %>

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
        <h1>USER LIST</h1>
    </div>
    <div>
        <asp:GridView ID="GridAllUser" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name"/>
                <asp:BoundField DataField="Email" HeaderText="Email"/>
                <asp:BoundField DataField="Password" HeaderText="Password"/>
                <asp:BoundField DataField="Gender" HeaderText="Gender"/>
                <asp:BoundField DataField="Status" HeaderText="Status"/>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="BtnChangeStatus" runat="server" Text="Change Status"  Visible='<%# IsOwnAccount(Int32.Parse(Eval("Id").ToString())) %>'  CommandArgument='<%# Eval("Id") %>' OnClick="BtnChangeStatus_Click"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="LblError" runat="server" Text=" "></asp:Label>
        <br />
        
    </div>
    </form>
</body>
</html>
