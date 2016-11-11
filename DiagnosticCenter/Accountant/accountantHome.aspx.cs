using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DiagnosticCenter.Accountant
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["accountant"] != null)
            {
                //Response.Write("Welcome to Accountant");
            }
            else
            {
                Response.Redirect("../Index.aspx");
            }
        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("../Index.aspx");
        }
    }
}