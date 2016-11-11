using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenter.DAL;
using DiagnosticCenter.Models;

namespace DiagnosticCenter.BLL
{
    public class ReportManager
    {
        ReportGateWay reportGateWay = new ReportGateWay();
        public List<Report> GetTestWiseReport(DateTime fromDate, DateTime toDate)
        {
            return reportGateWay.GetTestWiseReport(fromDate, toDate);
        }

        public List<Report> GetTypeWiseReport(DateTime fromDate, DateTime toDate)
        {
            return reportGateWay.GetTypeWiseReport(fromDate, toDate);
        }

        public List<Report> GetUnpaidBillReport(DateTime fromDate, DateTime toDate)
        {
            return reportGateWay.GetUnpaidBillReport(fromDate, toDate);
        }
    }
}