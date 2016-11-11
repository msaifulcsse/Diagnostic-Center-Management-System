<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="allTestInfoUI.aspx.cs" Inherits="DiagnosticCenter.Receptionist.allTestInfoUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<center>
 <h2 style="color: white; background-color: darkcyan">Welcome to DiagnosticCenter || Reception Dashboard</h2>
    <h3><a href="receptionistHome.aspx">Reception Home</a></h3>
       <h3 style="color: white; background-color:darkgoldenrod">Some Sample Test Name, Fee and Type</h3>
    <form id="form1" runat="server">
    <div>
    <table border="1">
        <tr>
            <th>Test Name</th>
            <th>Fee</th>
            <th>Test Type</th>
        </tr>
        <tr>
            <td>Complete Blood count</td>
            <td>400</td>
            <td>Blood</td>
        </tr>
         <tr>
            <td>RBS</td>
            <td>150</td>
            <td>Blood</td>
        </tr>
         <tr>
            <td>S. Creatinine</td>
            <td>350</td>
            <td>Blood</td>
        </tr>
         <tr>
            <td>Lipid profile</td>
            <td>450</td>
            <td>Blood</td>
        </tr>
        <tr>
            <td>Hand X-ray</td>
            <td>200</td>
            <td>X-Ray</td>
        </tr>
         <tr>
            <td>Feet X-ray</td>
            <td>300</td>
            <td>X-Ray</td>
        </tr>
         <tr>
            <td>LS Spine</td>
            <td>1100</td>
            <td>X-Ray</td>
        </tr>
         <tr>
            <td>Lower Abdomen</td>
            <td>550</td>
            <td>USG</td>
        </tr>
         <tr>
            <td>Whole Abdomen</td>
            <td>800</td>
            <td>USG</td>
        </tr>
         <tr>
            <td>Pregnancy profile</td>
            <td>550</td>
            <td>USG</td>
        </tr>
         <tr>
            <td>Echo</td>
            <td>1000</td>
            <td>Echo</td>
        </tr>
        <tr>
            <td>ECG</td>
            <td>150</td>
            <td>ECG</td>
        </tr>
    </table>
      <br/>
      <asp:Button ID="logoutButton" runat="server" Text="Logout" OnClick="logoutButton_Click" />
    </div>
    </form>
   </center>
</body>
</html>
