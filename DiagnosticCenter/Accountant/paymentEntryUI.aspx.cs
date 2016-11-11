using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenter.BLL;
using DiagnosticCenter.Models;

namespace DiagnosticCenter.Accountant
{
    public partial class paymentEntryUI : System.Web.UI.Page
    {
        PaymentManager paymentManager = new PaymentManager();
        Payment payment = new Payment();
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

        string dueDate;
        string totalAmount;
        string paidAmount;
        string mobileNo;
        string billNo;
        protected void billSearchButton_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment();

            if (billNoSearchTextBox.Text == string.Empty)
            {
                messageLabel.Text = "Please provide a bill number or mobile number.";
                return;
            }
            payment.BillNo = billNoSearchTextBox.Text;

            loadPaymentData(payment.BillNo);
        }
        private void loadPaymentData(string billNo)
        {
            List<Payment> payments = paymentManager.GetBillInfo(billNo);

            if (payments.Count != 0)
            {
                foreach (var payment1 in payments)
                {
                    dueDate = (payment1.DueDate).Date.ToString();
                    totalAmount = payment1.TotalAmount.ToString();
                    paidAmount = payment1.PaidAmount.ToString();
                    mobileNo = payment1.MobileNo.ToString();
                    billNo = payment1.BillNo.ToString();
                }

                ViewState["billNo"] = billNo;
                ViewState["totalAmount"] = totalAmount;
                ViewState["paidAmount"] = paidAmount;

                decimal dueAmount = payment.GetDueAmount(Convert.ToDecimal(totalAmount), Convert.ToDecimal(paidAmount));

                billDateLabel.Visible = true;
                DueDateLabel.Text = dueDate;

                totalFeeLabel.Visible = true;
                totalFeeAmount.Text = totalAmount;

                paidAmountLabel.Visible = true;
                paidAmountValue.Text = paidAmount;

                dueAmountLabel.Visible = true;
                dueAmountValue.Text = dueAmount.ToString();

                AmountLabel.Visible = true;
                amountTextBox.Visible = true;

                billDetailGridView.DataSource = payments;
                billDetailGridView.DataBind();

                errorMessageLabel.Visible = false;
                payAmountButton.Visible = true;
            }
            else
            {
                billDateLabel.Visible = false;
                totalFeeLabel.Visible = false;
                paidAmountLabel.Visible = false;
                dueAmountLabel.Visible = false;
                AmountLabel.Visible = false;

                payAmountButton.Visible = false;
                errorMessageLabel.Visible = true;
                errorMessageLabel.Text = "Sorry, Could not found data with this Bill or Mobile number.";
            }
        }

        protected void payAmountButton_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment();

            decimal totalAmount = Convert.ToDecimal(ViewState["totalAmount"]);
            decimal paidAmount = Convert.ToDecimal(ViewState["paidAmount"]);

            if (amountTextBox.Text == string.Empty)
            {
                errorMessageLabel.Visible = true;
                errorMessageLabel.Text = "Please give an amount.";
                return;
            }

            if (Convert.ToDecimal(amountTextBox.Text) > 0)
            {
                decimal payAmount = Convert.ToDecimal(amountTextBox.Text);
                string billNo = ViewState["billNo"].ToString();

                if (payAmount > totalAmount)
                {
                    errorMessageLabel.Visible = true;
                    errorMessageLabel.Text = "Please give valid amount.";
                    return;
                }

                if (totalAmount == paidAmount)
                {
                    errorMessageLabel.Visible = true;
                    errorMessageLabel.Text = "No Need to pay.";
                    return;
                }

                if (paidAmount < totalAmount)
                {
                    payAmount = paidAmount + payAmount;

                    if (paymentManager.UpdatePayment(payAmount.ToString(), billNo))
                    {
                        loadPaymentData(billNo);
                    }
                }


            }
            else
            {
                errorMessageLabel.Visible = true;
                errorMessageLabel.Text = "Please give valid amount.";
                return;
            }
        }
    }
}