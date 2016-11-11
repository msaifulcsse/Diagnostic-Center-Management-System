using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenter.Models
{
    public class TestEntry
    {
        public string Name { get; set; }
        public DateTime DOB { set; get; }
        public string MobileNo { get; set; }
        public string BillNo { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime DueDate { get; set; }
        public decimal PaidAmount { get; set; }
        public int TestId { get; set; }
        public string TestName { get; set; }
        public string TestFee { get; set; }
    }
}