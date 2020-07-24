<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewProductType.aspx.cs" Inherits="QuizEnamSesi.view.ViewProductType" %>

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
        <h1>PRODUCT TYPE</h1>
    </div>
    <div>
        
        <asp:GridView ID="GridProductType" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
            <Columns>
                <asp:BoundField Datafield="ID" HeaderText="Product Type ID"/>
                <asp:BoundField Datafield="Name" HeaderText="Product Type Name"/>
                <asp:BoundField Datafield="Description" HeaderText="Product Type Description"/>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton id="BtnUpdateProductType" runat="server" Text="Update" CommandArgument='<%# Eval("ID") %>' OnClick="BtnUpdateProductType_Click"></asp:LinkButton>
                        <asp:LinkButton id="BtnDeleteProductType" runat="server" Text="Delete" CommandArgument='<%# Eval("ID") %>' OnClick="BtnDeleteProductType_Click"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
        
    </div>
        <br />
        <asp:Label ID="LblError" runat="server" ForeColor="Red" Text=" "></asp:Label>
        <br />
        <br />

    <div>

        <asp:Button ID="BtnInsertProductType" runat="server" OnClick="BtnInsertProductType_Click" Text="Insert Product Type" />

    </div>
    </form>
</body>
</html>
