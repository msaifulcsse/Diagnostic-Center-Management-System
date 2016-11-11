<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DiagnosticCenter.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Scripts/jquery-3.1.1.min.js"></script>
    <title></title>
</head>
<body>
<center>
    <h2 style="color: white; background-color: darkcyan" >Welcome To New Diagnostic Center!!!</h2>
    <div>
  <form id="form1" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style4"><strong>Email</strong></td>
            <td class="auto-style6">
                <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style2">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Your Email" ControlToValidate="emailTextBox" ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Email" ControlToValidate="emailTextBox" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style3"><strong>Password</strong></td>
            <td class="auto-style7">
                <asp:TextBox ID="passTextBox" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Your Password" ControlToValidate="passTextBox" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style8"></td>
            <td class="auto-style9">
                <asp:Button ID="logiButton" runat="server" Text="Login" Width="91px" OnClick="logiButton_Click" />
            </td>
            <td class="auto-style2"></td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style7"><strong>
                <asp:Label ID="infoLabel" runat="server" ForeColor="Red"></asp:Label>
                </strong></td>
            <td>&nbsp;</td>
        </tr>
    </table>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
   </form>
   </div>
</center>
</body>
</html>
