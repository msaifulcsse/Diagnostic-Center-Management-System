using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Web.UI;
using DiagnosticCenter.BLL;
using DiagnosticCenter.Models;
namespace DiagnosticCenter.Admin
{
    public partial class unpaidReportUI : System.Web.UI.Page
    {
        ReportManager reportManager = new ReportManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != null)
            {
                //Response.Write("Welcome to AdminPanel");
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

        protected void testReportButton_Click(object sender, EventArgs e)
        {
            if (fromDateTextBox.Value == string.Empty || toDateTextBox.Value == string.Empty)
            {
                messageLabel.Text = "Please select both date.";
                return;
            }

            DateTime fromDate = Convert.ToDateTime(fromDateTextBox.Value);
            DateTime toDate = Convert.ToDateTime(toDateTextBox.Value);

            List<Report> ReportList = reportManager.GetUnpaidBillReport(fromDate, toDate);

            if (ReportList.Count != 0)
            {
                decimal totalAmount = ReportList.Sum(item => item.TotalAmount);
                decimal paidAmount = ReportList.Sum(item => item.PaidAmount);

                //unpaidBillPDFButton.Visible = true;
                unpaidBillReportGridView.Visible = true;
                unpaidBillReportGridView.DataSource = ReportList;
                unpaidBillReportGridView.DataBind();

                messageLabel.Visible = false;
            }
            else
            {
                unpaidBillReportGridView.Visible = false;
                messageLabel.Visible = true;
                messageLabel.Text = "Sorry, No data found.";
            }
        }

        int serialNo;
        decimal totalAmount;
        decimal paidAmount;
        decimal superTotal;
        protected void unpaidBillReportGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = (serialNo += 1).ToString();
                e.Row.Cells[1].Text = DataBinder.Eval(e.Row.DataItem, "BillNO").ToString();
                e.Row.Cells[2].Text = DataBinder.Eval(e.Row.DataItem, "MobileNo").ToString();
                e.Row.Cells[3].Text = DataBinder.Eval(e.Row.DataItem, "PatientName").ToString();
                e.Row.Cells[4].Text = DataBinder.Eval(e.Row.DataItem, "TotalAmount").ToString();
                e.Row.Cells[5].Text = DataBinder.Eval(e.Row.DataItem, "PaidAmount").ToString();

                totalAmount = totalAmount + Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalAmount"));
                paidAmount = paidAmount + Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PaidAmount"));

                superTotal = (totalAmount - paidAmount);
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "";
                e.Row.Cells[1].Text = "";
                e.Row.Cells[2].Text = "";
                e.Row.Cells[3].Text = "";
                e.Row.Cells[4].Text = "Total Unpaid Amount: ";
                e.Row.Cells[5].Text = superTotal.ToString();
            }
        }
    }
}