<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="QuizEnamSesi.view.TransactionHistory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 451px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style1">
    
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">&lt; Back to Home Page</asp:LinkButton>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Font-Size="30pt" Text="Transaction History"></asp:Label>
        <br />
        <asp:GridView ID="GridView1" AutoGenerateColumns= "false" runat="server">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                <asp:BoundField DataField="transDate" HeaderText="Transaction Date" />
                <asp:BoundField DataField="paymentType" HeaderText="Payment Type" />
                <asp:BoundField DataField="productName" HeaderText="Product Name" />
                <asp:BoundField DataField="quantity" HeaderText="Product Quantity" />
                <asp:BoundField DataField="subTotal" HeaderText="Subtotal" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    
        <br />
        <asp:Label ID="Label2" runat="server" Font-Size="15pt" Text="Grand Total : "></asp:Label>
        <asp:Label ID="GrandTotal" runat="server" Font-Size="15pt" Text="No Item"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnTransReport" runat="server" OnClick="btnTransReport_Click" Text="Transaction Report" Visible="False" />
    
    </div>
    </form>
</body>
</html>
