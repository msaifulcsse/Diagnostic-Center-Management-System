using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DiagnosticCenter
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void logiButton_Click(object sender, EventArgs e)
        {
           string connectionString =
           WebConfigurationManager.ConnectionStrings["diagnosticCenterApp"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT count(*) FROM users where email='"+emailTextBox.Text+"'";
            SqlCommand command = new SqlCommand(query, connection);
            int temp = Convert.ToInt32(command.ExecuteScalar().ToString());
            connection.Close();
            if (temp == 1)
            {
                connection.Open();
                string queryPass = "SELECT password FROM users where email='" + emailTextBox.Text + "'";
                SqlCommand commandPass = new SqlCommand(queryPass, connection);
                string pass = commandPass.ExecuteScalar().ToString().Replace(" ","");
                if (pass == passTextBox.Text)
                {
                    string queryType = "SELECT acctype FROM users where email='" + emailTextBox.Text + "' and password='" + passTextBox.Text + "'";
                    SqlCommand commandType = new SqlCommand(queryType, connection);
                    string acctype = commandType.ExecuteScalar().ToString().Replace(" ","");
                    if (acctype == "Admin")
                    {
                        Session["admin"] = emailTextBox.Text;
                        Response.Redirect("Admin/adminHome.aspx");
                    }
                    if (acctype == "Accountant")
                    {
                        Session["accountant"] = emailTextBox.Text;
                        Response.Redirect("Accountant/accountantHome.aspx");
                    }
                    if (acctype == "Receptionist")
                    {
                        Session["receptionist"] = emailTextBox.Text;
                        Response.Redirect("Receptionist/receptionistHome.aspx");
                    }
                    else
                    {
                        infoLabel.Text = "Do not match";
                    }
                }
                else
                {
                    infoLabel.Text = "Password is not correct";
                }
                
            }
            else
            {
                infoLabel.Text = "Email/Password does not correct";
                emailTextBox.Text = "";
                passTextBox.Text = "";
            }
        }
    }
}