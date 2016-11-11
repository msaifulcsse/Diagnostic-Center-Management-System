using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DiagnosticCenter.Models;

namespace DiagnosticCenter.DAL
{
    public class TestEntryGateWay
    {
        private string connectionString =
           WebConfigurationManager.ConnectionStrings["diagnosticCenterApp"].ConnectionString;
        public List<TestEntry> GetAllTest()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT Id, Name, Fee FROM test_name ORDER BY Name";
            SqlCommand command = new SqlCommand(query, connection);

            List<TestEntry> testEntry = new List<TestEntry>();

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                TestEntry testEntries = new TestEntry();

                testEntries.TestId = Convert.ToInt32(reader["Id"]);
                testEntries.TestName = reader["Name"].ToString();
                testEntry.Add(testEntries);
            }

            connection.Close();

            return testEntry;
        }

        public string GetTestFee(int testValue)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT FEE FROM test_name WHERE Id='" + testValue + "'";
            SqlCommand command = new SqlCommand(query, connection);

            TestEntry testEntry = new TestEntry();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                testEntry.TestFee = reader["Fee"].ToString();

            }

            connection.Close();

            string testFee = testEntry.TestFee;
            return testFee;
        }

        public int SavePatient(TestEntry testEntry)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            DateTime created_at = DateTime.Now;

            string query = "INSERT INTO patient(Name, DOB, MobileNo, BillNo, TotalAmount, DueDate, PaidAmount, created_at) VALUES('" + testEntry.Name + "', '" + testEntry.DOB + "', '" + testEntry.MobileNo + "', '" + testEntry.BillNo + "', '" + testEntry.TotalAmount + "', '" + testEntry.DueDate + "', '" + testEntry.PaidAmount + "', '" + created_at + "') SELECT SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = query;

            connection.Open();
            var Id = command.ExecuteScalar();
            connection.Close();

            int patientId = Convert.ToInt32(Id);

            if (patientId > 0)
            {
                return patientId;
            }
            else
            {
                return 0;
            }
        }

        public bool IsMobileNoExists(string MobileNo)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT MobileNo FROM patient WHERE MobileNo='" + MobileNo + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            bool IsPatientTestExists = reader.HasRows;
            connection.Close();

            return IsPatientTestExists;
        }

        public bool IsPatientTestExists(int patientId, int testId)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT Request_id, test_id FROM patient_test WHERE Request_id='" + patientId + "' AND Test_id='" + testId + "' ";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            bool IsPatientTestExists = reader.HasRows;
            connection.Close();

            return IsPatientTestExists;
        }

        public bool SavePatientTest(int patientId, int testId)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            DateTime created_at = DateTime.Now;

            string query = "INSERT INTO patient_test(Request_id, Test_id, created_at) VALUES('" + patientId + "', '" + testId + "', '" + created_at + "')";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            if (rowAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}