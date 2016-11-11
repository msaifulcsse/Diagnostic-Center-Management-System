using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenter.Models
{
    public class Payment
    {
        public string BillNo { get; set; }
        public string MobileNo { get; set; }
        public string TestName { get; set; }
        public string TestFee { get; set; }
        public DateTime DueDate { get; set; }
        public Decimal TotalAmount { get; set; }
        public Decimal PaidAmount { get; set; }

        public decimal GetDueAmount(decimal TotalAmount, decimal PaidAmount)
        {
            return (TotalAmount - PaidAmount);
        }
    }
}