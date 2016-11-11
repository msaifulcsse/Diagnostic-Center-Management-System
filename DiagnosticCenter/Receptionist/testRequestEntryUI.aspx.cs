using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenter.BLL;
using DiagnosticCenter.Models;

namespace DiagnosticCenter.Receptionist
{
    public partial class testRequestEntryUI : System.Web.UI.Page
    {
        TestEntryManager testEntryManager = new TestEntryManager();
        decimal total;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                testDropDownList.DataSource = testEntryManager.GetAllTest();
                testDropDownList.DataTextField = "TestName";
                testDropDownList.DataValueField = "TestId";
                testDropDownList.DataBind();

                testDropDownList.Items.Insert(0, "Select Test");
            }
            if (Session["receptionist"] != null)
            {
                //Response.Write("Welcome to Receptionist");
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

        protected void addButton_Click(object sender, EventArgs e)
        {
            List<TestEntry> testEntry = new List<TestEntry>();

            if (testDropDownList.SelectedValue == "Select Test")
            {
                messageLabel.Text = "Please select a test";
                messageLabel.ForeColor = Color.Brown;
                return;
            }

            int testId = Convert.ToInt32(testDropDownList.SelectedValue);
            if (ViewState["TestId"] == null)
            {
                List<int> testsId = new List<int>();
                testsId.Add(testId);
                ViewState["TestId"] = testsId;

            }
            else
            {
                List<int> testIds = (List<int>)ViewState["TestId"];
                testIds.Add(testId);
                ViewState["TestId"] = testIds;
            }

            ShowGridView();
            testSaveButton.Visible = true;
        }
        private void ShowGridView()
        {
            DataTable dT = new DataTable();

            dT.Columns.Add("SerialNo");
            dT.Columns.Add("TestName");
            dT.Columns.Add("TestFee");

            DataRow dr = null;
            if (ViewState["tests"] != null)
            {
                for (int i = 0; i < 1; i++)
                {
                    dT = (DataTable)ViewState["tests"];
                    if (dT.Rows.Count > 0)
                    {
                        dr = dT.NewRow();
                        dr["SerialNo"] = ViewState["SerialNo"];
                        dr["TestName"] = testDropDownList.SelectedItem;
                        dr["TestFee"] = feeTextBox.Text;

                        dT.Rows.Add(dr);
                        showSelectedTest.DataSource = dT;
                        showSelectedTest.DataBind();
                    }
                }
            }
            else
            {
                ViewState["SerialNo"] = 1;

                dr = dT.NewRow();
                dr["SerialNo"] = ViewState["SerialNo"];
                dr["TestName"] = testDropDownList.SelectedItem;
                dr["TestFee"] = feeTextBox.Text;

                dT.Rows.Add(dr);
                showSelectedTest.DataSource = dT;
                showSelectedTest.DataBind();


            }

            ViewState["SerialNo"] = (int)ViewState["SerialNo"] + 1;
            ViewState["tests"] = dT;
        }



        protected void testDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (testDropDownList.SelectedIndex == 0)
            {
                messageLabel.Text = "Please select a test.";
                return;
            }
            else
            {
                int testValue = Convert.ToInt32(testDropDownList.SelectedValue);
                feeTextBox.Text = testEntryManager.GetTestFee(testValue);
            }

        }

        protected void testSaveButton_Click(object sender, EventArgs e)
        {

            if (patientNameTextBox.Text == "")
            {
                messageLabel.Text = "Patient Name cannot be blank.";
                return;
            }
            if (mobileNoTextBox.Text == "")
            {
                messageLabel.Text = "Patient mobile number cannot be blank.";
                return;
            }


            TestEntry testEntry = new TestEntry();
            testEntry.Name = patientNameTextBox.Text;
            testEntry.DOB = Convert.ToDateTime(dobTextBox.Value);
            testEntry.MobileNo = mobileNoTextBox.Text;
            testEntry.TotalAmount = Convert.ToDecimal(ViewState["TotalAmount"]);
            testEntry.DueDate = DateTime.Now;
            testEntry.PaidAmount = 0;

            if (testEntryManager.IsMobileNoExists(testEntry.MobileNo))
            {
                messageLabel.Text = "Mobile number already exits.";
                return;

            }
            else
            {
                testEntry.BillNo = "B-" + testEntry.MobileNo;
            }

            int patientId = testEntryManager.SavePatient(testEntry);

            List<int> testIds = (List<int>)ViewState["TestId"];

            if (testIds == null)
            {
                messageLabel.Text = "Please select a test.";
                return;
            }

            if (patientId != 0)
            {
                foreach (var testId in testIds)
                {
                    testEntryManager.SavePatientTest(patientId, testId);
                }

                messageLabel.Text = "Successfully saved.";
                messageLabel.ForeColor = Color.Green;

                patientNameTextBox.Text = "";
                dobTextBox.Value = "";
                mobileNoTextBox.Text = "";
                testDropDownList.ClearSelection();
                feeTextBox.Text = "";

                billNoLabel.Visible = true;
                billNoLabel.Text = "New Bill Number is: " + "B-" + testEntry.MobileNo;


            }
            else
            {
                messageLabel.Text = "Operation failed";
                messageLabel.ForeColor = Color.Red;
            }

        }

        protected void showSelectedTest_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                total = total + Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TestFee"));

            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {

                e.Row.Cells[0].Text = "";
                e.Row.Cells[1].Text = "Total : ";
                e.Row.Cells[2].Text = total.ToString();

            }

            ViewState["TotalAmount"] = total;
        }
    }
}