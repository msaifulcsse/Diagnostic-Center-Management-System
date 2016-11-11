<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testSetupEntryUI.aspx.cs" Inherits="DiagnosticCenter.Admin.testSetupEntryUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Test Setup </title>
    <style>
        .center-div { margin: 0 auto; width: 50% }
        .center-table { margin: 0 auto; width: 100%; }
        .table-bg { background: #ccc; }
    </style>
</head>
<body>
<center>
 <h2 style="color: white; background-color: darkcyan" >Welcome to DiagnosticCenter || Admin Panel</h2> 
    <h3><a href="adminHome.aspx">Admin Home</a></h3>
<h3 style="color: white; background-color:darkgoldenrod">Test Name Setup</h3>
    <form id="form1" runat="server">
    <div>
        <fieldset class="center-div">
            <legend>Test Setup</legend>
            <table>
                <tr>
                    <td>Test Name </td>
                    <td>  
                        <asp:TextBox ID="testNameTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Fee </td>
                    <td>  
                        <asp:TextBox ID="feeTextBox" runat="server"></asp:TextBox> &nbsp; <asp:Label ID="BDTLabel" Text="BDT" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Test Type </td>
                    <td>  
                        <asp:DropDownList ID="testTypeDropDownList" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2"><asp:Label ID="messageLabel" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="SaveButton" runat="server" Text="Save" OnClick="SaveButton_Click" /></td>
                </tr>
            </table>
        </fieldset>
    </div>

        <div style="margin: 50px auto 0; width: 52%">
        
        <asp:GridView ID="showAllTest" runat="server" AutoGenerateColumns="false" CssClass="center-table">
            <Columns>
                <asp:TemplateField HeaderText="SL" HeaderStyle-CssClass="table-bg">
                    <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Type Name" HeaderStyle-CssClass="table-bg">
                    <ItemTemplate>
                        <%# Eval("Name") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Fee" HeaderStyle-CssClass="table-bg">
                    <ItemTemplate>
                        <%# Eval("Fee") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Type" HeaderStyle-CssClass="table-bg">
                    <ItemTemplate>
                        <%# Eval("TypeName") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
        <br/>
        <asp:Button ID="logoutButton" runat="server" Text="Logout" OnClick="logoutButton_Click" />
    </form>
</center>
</body>
</html>
