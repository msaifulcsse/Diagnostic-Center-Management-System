<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testRequestEntryUI.aspx.cs" Inherits="DiagnosticCenter.Receptionist.testRequestEntryUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Request Form</title>
    <style>
        .center-div { margin: 0 auto; width: 50% }
        .center-table { margin: 0 auto; width: 100%; }
        .table-bg { background: #ccc; }
        .btn-pos { float: right; margin-top: 20px; }
        .label-padding { padding: 5px; margin: 7px 0; }
    </style>
</head>
<body>
<center>
 <h2 style="color: white; background-color: darkcyan">Welcome to DiagnosticCenter || Reception Dashboard</h2>
    <h3><a href="receptionistHome.aspx">Reception Home</a></h3>
       <h3 style="color: white; background-color:darkgoldenrod">Test Request Entry</h3>
    <form id="form1" runat="server">
    <div>
        <fieldset class="center-div">
            <legend>Test Request Entry</legend>
            <table>
                <tr>
                    <td>Name of the patient</td>
                    <td>
                        <asp:TextBox ID="patientNameTextBox" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Date of Birth</td>
                    <td>  
                        <input type="date" id="dobTextBox" runat="server" placeholder="DD-MM-YYYY" readonly />
                    </td>
                </tr>
                <tr>
                    <td>Mobile Number</td>
                    <td>
                        <asp:TextBox ID="mobileNoTextBox" runat="server"></asp:TextBox></td>
                </tr>
                
                <tr>
                    <td>Select Test</td>
                    <td>
                        <asp:DropDownList ID="testDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="testDropDownList_OnSelectedIndexChanged"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Fee</td>
                    <td>
                        <asp:TextBox ID="feeTextBox" ReadOnly="true" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="addButton" runat="server" Text="ADD" OnClick="addButton_Click" /></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Label ID="billNoLabel" runat="server" Text="" BackColor="#f5f5f5" ForeColor="#66ff33" Font-Bold="true" CssClass="label-padding" Visible="false"></asp:Label></td>
                </tr>
            </table>
        </fieldset>  
    </div>
    <div style="margin: 50px auto 0; width: 52%"> 
        <asp:GridView ID="showSelectedTest" runat="server" AutoGenerateColumns="False" CssClass="center-table" OnRowDataBound="showSelectedTest_RowDataBound" ShowFooter="True">
            <Columns>
                <asp:TemplateField HeaderText="SL" HeaderStyle-CssClass="table-bg">
                    <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Test" HeaderStyle-CssClass="table-bg">
                    <ItemTemplate>
                        <%# Eval("TestName") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Fee" HeaderStyle-CssClass="table-bg">
                    <ItemTemplate>
                        <%# Eval("TestFee") %>
                    </ItemTemplate>
                    <FooterStyle BackColor="#cccccc" Font-Bold="True" ForeColor="White" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
            <asp:Button Visible="false" ID="testSaveButton" runat="server" Text="Save" OnClick="testSaveButton_Click" CssClass="btn-pos" />
    </div>
      <br/>
      <asp:Button ID="logoutButton" runat="server" Text="Logout" OnClick="logoutButton_Click" />
    </form>
<link href="../Scripts/jquery-ui.css" rel="stylesheet" />
<script src="../Scripts/jquery-3.1.1.min.js"></script>
<script src="../Scripts/jquery-ui.js"></script>
      <script type="text/javascript">
          $(document).ready(function() {
              $('#dobTextBox').datepicker({
                  showOn: 'button',
                  dateFormat: 'dd-mm-yy',
                  changeMonth: true,
                  changeYear: true
              });
          });
 </script>
</center>
</body>
</html>
