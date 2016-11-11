<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="accountantHome.aspx.cs" Inherits="DiagnosticCenter.Accountant.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<center>
  <h2 style="color: white; background-color: darkcyan" >Welcome to DiagnosticCenter || Account Section</h2>
    <form id="form1" runat="server">
    <div>
        <ul>
            <li><a href="paymentEntryUI.aspx">Payment Entry</a></li>
            <li><a href="unpaidReportUI.aspx">Unpaid Bill Report</a></li>
        </ul>
        <asp:Button ID="logoutButton" runat="server" Text="Logout" OnClick="logoutButton_Click" />
    </div>
    </form>
</center>
</body>
</html>
