using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenter.BLL;
using DiagnosticCenter.Models;

namespace DiagnosticCenter.Admin
{
    public partial class testSetupEntryUI : System.Web.UI.Page
    {
        TestSetupManager testSetupManager = new TestSetupManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadAllTest();
            if (!IsPostBack)
            {

                testTypeDropDownList.DataSource = testSetupManager.GetAllTestType();
                testTypeDropDownList.DataTextField = "Name";
                testTypeDropDownList.DataValueField = "Id";
                testTypeDropDownList.DataBind();
            }
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

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (testNameTextBox.Text == "")
            {
                messageLabel.Text = "Name Cannot be blank.";
                return;
            }

            if (feeTextBox.Text == "")
            {
                messageLabel.Text = "Fee Cannot be blank.";
                return;
            }

            if (testNameTextBox.Text.Length < 3)
            {
                messageLabel.Text = "Name Should be atleast 3 character long.";
                return;
            }

            string name = testNameTextBox.Text;
            string fee = feeTextBox.Text;
            int type_id = Convert.ToInt32(testTypeDropDownList.SelectedValue);


            TestSetup testSetup = new TestSetup();

            testSetup.Name = name;
            testSetup.Fee = fee;
            testSetup.TypeId = type_id;

            if (testSetupManager.IsTestExists(name))
            {
                messageLabel.Text = "Test Name Already exists!";
                return;
            }

            bool isSaved = testSetupManager.SaveTestSetup(testSetup);

            if (isSaved)
            {
                messageLabel.Text = "Saved Successfully!";
                testNameTextBox.Text = "";
                feeTextBox.Text = "";
                LoadAllTest();

            }
            else
            {
                messageLabel.Text = "Insertion Failed!";
            }
        }
        private void LoadAllTest()
        {
            List<TestSetup> testTypes = testSetupManager.GetAllTest();

            showAllTest.DataSource = testTypes;
            showAllTest.DataBind();
        }
    }
}