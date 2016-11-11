<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="paymentEntryUI.aspx.cs" Inherits="DiagnosticCenter.Accountant.paymentEntryUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title>Payment</title>
    <style>
        .center-div { margin: 0 auto; width: 50% }
        .center-table { margin: 0 auto; width: 100%; }
        .center-table-halfwidth { margin: 50px auto 0; width: 50%; }
        .table-bg { background: #ccc; }
    </style>
</head>
<body>
<center>
     <h2 style="color: white; background-color: darkcyan">Welcome to DiagnosticCenter || Account Section</h2>
   <h3><a href="accountantHome.aspx">Accountant Home</a></h3>
   <h3 style="color: white; background-color:darkgoldenrod">Bill Payment</h3>
    <form id="form1" runat="server">
    <div>
        <fieldset class="center-div">
            <legend>PayBill</legend>
            <table>
                <tr>
                    <td>Bill No.</td>
                    <td>
                        <asp:TextBox ID="billNoSearchTextBox" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:Button ID="billSearchButton" runat="server" Text="Search" OnClick="billSearchButton_Click" /></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td><asp:Label ID="messageLabel" runat="server" Text=""></asp:Label></td>
                </tr>
            </table>
        </fieldset>
    </div>

        <div style="margin: 50px auto 0; width: 52%">

        <asp:GridView ID="billDetailGridView" runat="server" AutoGenerateColumns="false" CssClass="center-table">
            <Columns>
                <asp:TemplateField HeaderText="SL" HeaderStyle-CssClass="table-bg">
                    <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Test Name" HeaderStyle-CssClass="table-bg">
                    <ItemTemplate>
                        <%# Eval("TestName") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Test Fee" HeaderStyle-CssClass="table-bg">
                    <ItemTemplate>
                        <%# Eval("TestFee") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
  <table class="center-table-halfwidth">
                <tr>
                    <td>
                        <asp:Label ID="billDateLabel" runat="server" Text="Bill Date" Visible="false" Font-Bold="true"></asp:Label> </td>
                    <td>
                        <asp:Label ID="DueDateLabel" runat="server" Text=""></asp:Label></td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="totalFeeLabel" runat="server" Text="Total Fee" Visible="false" Font-Bold="true"></asp:Label> </td>
                    <td>
                        <asp:Label ID="totalFeeAmount" runat="server" Text=""></asp:Label></td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="paidAmountLabel" runat="server" Text="Paid Amount" Visible="false" Font-Bold="true"></asp:Label> </td>
                    <td>
                        <asp:Label ID="paidAmountValue" runat="server" Text=""></asp:Label></td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="dueAmountLabel" runat="server" Text="Due Amount" Visible="false" Font-Bold="true"></asp:Label> </td>
                    <td>
                        <asp:Label ID="dueAmountValue" runat="server" Text=""></asp:Label></td>
                </tr>

                 <tr>
                    <td>
                        <asp:Label ID="AmountLabel" runat="server" Text="Amount" Visible="false" Font-Bold="true"></asp:Label> </td>
                    <td>
                        <asp:TextBox ID="amountTextBox" runat="server" Visible="false"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="payAmountButton" runat="server" Text="Pay" OnClick="payAmountButton_Click" Visible="false" />
                    </td>
                </tr>

                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Label ID="errorMessageLabel" runat="server" Text="" Visible="false" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br/>
      <asp:Button ID="logoutButton" runat="server" Text="Logout" OnClick="logoutButton_Click" />
    </form>
</center>
</body>
</html>
