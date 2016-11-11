using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenter.DAL;
using DiagnosticCenter.Models;

namespace DiagnosticCenter.BLL
{
    public class PaymentManager
    {
        PaymentGateWay paymentGateWay = new PaymentGateWay();

        public List<Payment> GetBillInfo(string billNo)
        {
            return paymentGateWay.GetBillInfo(billNo);
        }

        public bool UpdatePayment(string payAmount, string billNo)
        {
            return paymentGateWay.UpdatePayment(payAmount, billNo);
        }
    }
}