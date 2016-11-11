using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DiagnosticCenter.Models;

namespace DiagnosticCenter.DAL
{
    public class PaymentGateWay
    {
        private string connectionString =
           WebConfigurationManager.ConnectionStrings["diagnosticCenterApp"].ConnectionString;

        public List<Payment> GetBillInfo(string billNo)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT p.MobileNo, p.BillNo, p.DueDate, p.TotalAmount, p.PaidAmount, tn.Name as TestName, tn.Fee as TestFee FROM patient as p INNER JOIN patient_test as pt ON p.Id = pt.Request_id INNER JOIN test_name as tn ON pt.Test_id = tn.id WHERE(p.BillNo = '" + billNo + "' OR p.MobileNo = '" + billNo + "')";
            SqlCommand command = new SqlCommand(query, connection);

            List<Payment> payment = new List<Payment>();

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Payment payments = new Payment();

                payments.BillNo = reader["BillNo"].ToString();
                payments.MobileNo = reader["MobileNo"].ToString();
                payments.TestName = reader["TestName"].ToString();
                payments.TestFee = reader["TestFee"].ToString();
                payments.TotalAmount = Convert.ToDecimal(reader["TotalAmount"]);
                payments.PaidAmount = Convert.ToDecimal(reader["PaidAmount"]);
                payments.DueDate = Convert.ToDateTime(reader["DueDate"]);

                payment.Add(payments);
            }

            connection.Close();

            return payment;
        }

        public bool UpdatePayment(string payAmount, string billNo)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            DateTime created_at = DateTime.Now;

            string query = "UPDATE patient SET PaidAmount = '" + payAmount + "' WHERE BillNo = '" + billNo + "'";

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