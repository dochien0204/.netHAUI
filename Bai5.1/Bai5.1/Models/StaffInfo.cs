using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai5._1.Models
{
    public class StaffInfo
    {

        public string id { get; set; }
        public string name { get; set; }
        public DateTime dateOfBirth { get; set; }
        public Decimal salary { get; set; }
        public string image { get; set; }
    }
}