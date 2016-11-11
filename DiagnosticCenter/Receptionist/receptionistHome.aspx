<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="receptionistHome.aspx.cs" Inherits="DiagnosticCenter.Receptionist.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<center>
  <h2 style="color: white; background-color: darkcyan" >Welcome to DiagnosticCenter || Reception Dashboard</h2>
    <form id="form1" runat="server">
    <div>
        <ul>
            <li><a href="testRequestEntryUI.aspx">Test Request Entry</a></li>
            <li><a href="allTestInfoUI.aspx">All Test Info</a></li>
        </ul>
        <asp:Button ID="logoutButton" runat="server" Text="Logout" OnClick="logoutButton_Click" />
    </div>
    </form>
</center>
</body>
</html>
