using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenter.DAL;
using DiagnosticCenter.Models;

namespace DiagnosticCenter.BLL
{
    public class TestEntryManager
    {
        TestEntryGateWay testEntryGateWay = new TestEntryGateWay();
        public List<TestEntry> GetAllTest()
        {
            List<TestEntry> testTypes = testEntryGateWay.GetAllTest();
            return testTypes;
        }

        public string GetTestFee(int testValue)
        {
            return testEntryGateWay.GetTestFee(testValue);
        }

        public bool IsMobileNoExists(string mobileNo)
        {
            return testEntryGateWay.IsMobileNoExists(mobileNo);
        }

        public int SavePatient(TestEntry testEntry)
        {
            return testEntryGateWay.SavePatient(testEntry);
        }
        public bool SavePatientTest(int patientId, int testId)
        {
            if (testEntryGateWay.IsPatientTestExists(patientId, testId))
            {
                throw new Exception("Added Duplicate Tests, please select single test.");
            }
            else
            {
                return testEntryGateWay.SavePatientTest(patientId, testId);
            }
        }
    }
}