using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenter.DAL;
using DiagnosticCenter.Models;

namespace DiagnosticCenter.BLL
{
    public class TestTypeManager
    {
        TestTypeGateWay testTypeGateWay = new TestTypeGateWay();
        public bool IsTestTypeExists(string name)
        {
            return testTypeGateWay.IsTestTypeExists(name);
        }

        public bool SaveTestType(TestType testType)
        {
            return testTypeGateWay.SaveTestType(testType);
        }

        public List<TestType> GetAllTestType()
        {
            return testTypeGateWay.GetAllTestType();
        }
    }
}