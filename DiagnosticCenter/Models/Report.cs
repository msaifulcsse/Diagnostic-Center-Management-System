using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenter.Models
{
    public class Report
    {
        public string TestName { get; set; }
        public int TotalFee { get; set; }
        public int TestCount { get; set; }
        public string TestTypeName { get; set; }
        public string BillNo { get; set; }
        public string MobileNo { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public string PatientName { get; set; }
    }
}