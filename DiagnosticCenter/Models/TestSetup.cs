using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenter.Models
{
    public class TestSetup
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Fee { set; get; }
        public int TypeId { set; get; }
        public string TypeName { set; get; }
    }
}