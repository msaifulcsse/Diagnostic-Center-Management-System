<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminHome.aspx.cs" Inherits="DiagnosticCenter.Admin.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<center>
  <h2 style="color: white; background-color: darkcyan" >Welcome to DiagnosticCenter || Admin Panel</h2>
    <form id="form1" runat="server">
    <div>
        <ul>
            <li><a href="testTypeEntryUI.aspx">Test Type Entry</a></li>
            <li><a href="testSetupEntryUI.aspx">Test Setup Entry</a></li>
            <li><a href="testReportUI.aspx">Test Wise Report</a></li>
            <li><a href="typeReportUI.aspx">Type Wise Report</a></li>
            <li><a href="unpaidReportUI.aspx">Unpaid Bill Report</a></li>
        </ul>
        <asp:Button ID="logoutButton" runat="server" Text="Logout" OnClick="logoutButton_Click" />
    </div>
    </form>
</center>
</body>
</html>
