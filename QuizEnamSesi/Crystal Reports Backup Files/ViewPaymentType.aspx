<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPaymentType.aspx.cs" Inherits="QuizEnamSesi.view.ViewPaymentType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Payment Type</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="BtnBack" runat="server" OnClick="BtnBack_Click" Text="&lt; Back" />
    </div>
    <div>
        <div class="col-md-12">
            <div class="container">
                <center>
                    <h2>Payment Types</h2>
                    <asp:Table ID="paymentTable" Class="table" CellSpacing="50" runat="server">
                        <asp:TableHeaderRow>
                            <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                            <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                            <asp:TableHeaderCell ID="action" ColumnSpan="2">Action</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                    <div><asp:Label ID="errorMsg" runat="server" Text="" ForeColor="Red"></asp:Label></div>
                    <br />
                    <br />
                    <asp:Button runat="server" id="InsertPaymentType" Text="Insert Payment Type" OnClick="BtnInsertPaymentType_Click"/>
                </center>       
            </div>
        </div>
    </div>
    </form>
</body>
</html>
