<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="unpaidBillUI.aspx.cs" Inherits="DiagnosticCenter.Accountant.unpaidReportUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<center>
<h2 style="color: white; background-color: darkcyan">Welcome to DiagnosticCenter || Account Section</h2>
<h3><a href="accountantHome.aspx">Accountant Home</a></h3>
<h3 style="color: white; background-color:darkgoldenrod">All Unpaid Bill</h3>
    <form id="form1" runat="server">
    <div>
    
    </div>
   <br/>
  <asp:Button ID="logoutButton" runat="server" Text="Logout" OnClick="logoutButton_Click" />
    </form>
</center>
</body>
</html>
