using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DiagnosticCenter.Models;

namespace DiagnosticCenter.DAL
{
    public class TestSetupGateWay
    {
        private string connectionString =
           WebConfigurationManager.ConnectionStrings["diagnosticCenterApp"].ConnectionString;

        public List<TestType> GetAllTestType()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM test_type";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<TestType> testTypes = new List<TestType>();

            while (reader.Read())
            {
                TestType testType = new TestType();

                testType.Id = Convert.ToInt32(reader["Id"]);
                testType.Name = reader["Name"].ToString();

                testTypes.Add(testType);
            }

            return testTypes;
        }

        public List<TestSetup> GetAllTest()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT tn.Name, tn.Fee, tn.type_id, tt.Name AS TypeName from test_name AS tn INNER JOIN test_type AS tt ON tn.type_id = tt.Id ORDER BY tn.Name";

            SqlCommand command = new SqlCommand(query, connection);

            List<TestSetup> testSetup = new List<TestSetup>();

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                TestSetup testSetups = new TestSetup();

                testSetups.Name = reader["Name"].ToString();
                testSetups.Fee = reader["Fee"].ToString();
                testSetups.TypeId = Convert.ToInt32(reader["type_id"]);
                testSetups.TypeName = reader["TypeName"].ToString();
                testSetup.Add(testSetups);
            }

            connection.Close();

            return testSetup;
        }

        public bool SaveTestSetup(TestSetup testSetup)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            DateTime created_at = DateTime.Now;

            string query = "INSERT INTO test_name(Name, Fee, type_id, created_at) VALUES('" + testSetup.Name + "', '" + testSetup.Fee + "', '" + testSetup.TypeId + "','" + created_at + "')";


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

        public bool IsTestExists(string name)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM test_name WHERE Name='" + name + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            bool isTestExist = reader.HasRows;
            connection.Close();

            return isTestExist;
        }
    }
}