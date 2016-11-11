using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DiagnosticCenter.Models;

namespace DiagnosticCenter.DAL
{
    public class ReportGateWay
    {
        private string connectionString =
           WebConfigurationManager.ConnectionStrings["diagnosticCenterApp"].ConnectionString;

        public List<Report> GetTestWiseReport(DateTime fromDate, DateTime toDate)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "select pt.Test_id, tn.Name, SUM(cast(replace(tn.Fee, ',', '.') as decimal(18, 0))) AS TotalFee, Count(pt.Test_id) AS TestCount from patient_test as pt LEFT OUTER JOIN test_name as tn on pt.Test_id = tn.Id WHERE pt.created_at BETWEEN '" + fromDate + "' AND '" + toDate + "' GROUP BY pt.Test_id, tn.Name, tn.Fee";
            SqlCommand command = new SqlCommand(query, connection);

            List<Report> report = new List<Report>();

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Report reportData = new Report();

                reportData.TestName = reader["Name"].ToString();
                reportData.TotalFee = Convert.ToInt32(reader["TotalFee"]);
                reportData.TestCount = Convert.ToInt32(reader["TestCount"]);

                report.Add(reportData);
            }

            connection.Close();

            return report;
        }

        public List<Report> GetTypeWiseReport(DateTime fromDate, DateTime toDate)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "select ty.Name as TypeName, SUM(cast(replace(tn.Fee, ',', '.') as decimal(18, 0))) AS TotalFee, Count(pt.Test_id) AS TestCount FROM test_type AS ty FULL OUTER JOIN test_name AS tn ON ty.Id = tn.type_id FULL OUTER JOIN patient_test AS pt ON tn.Id = pt.Test_id WHERE pt.created_at BETWEEN '" + fromDate + "' AND '" + toDate + "' GROUP BY ty.Name";
            SqlCommand command = new SqlCommand(query, connection);

            List<Report> report = new List<Report>();

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Report reportData = new Report();

                reportData.TestTypeName = reader["TypeName"].ToString();
                reportData.TotalFee = Convert.ToInt32(reader["TotalFee"]);
                reportData.TestCount = Convert.ToInt32(reader["TestCount"]);

                report.Add(reportData);
            }

            connection.Close();

            return report;
        }

        public List<Report> GetUnpaidBillReport(DateTime fromDate, DateTime toDate)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT Name, BillNo, MobileNo, TotalAmount, PaidAmount FROM patient WHERE TotalAmount > PaidAmount AND created_at BETWEEN '" + fromDate + "' AND '" + toDate + "'";
            SqlCommand command = new SqlCommand(query, connection);

            List<Report> report = new List<Report>();

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Report reportData = new Report();

                reportData.PatientName = reader["Name"].ToString();
                reportData.BillNo = reader["BillNo"].ToString();
                reportData.MobileNo = reader["MobileNo"].ToString();
                reportData.TotalAmount = Convert.ToDecimal(reader["TotalAmount"]);
                reportData.PaidAmount = Convert.ToDecimal(reader["PaidAmount"]);

                report.Add(reportData);
            }

            connection.Close();

            return report;
        }

    }
}