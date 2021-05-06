using System;
using System.Collections.Generic;

namespace Graduation_Core.Models
{
    public partial class Employee
    {
        public long EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpMobile { get; set; }
        public string EmpEmail { get; set; }
        public string EmpAddress { get; set; }
        public string EmpSsn { get; set; }
        public int EmpCId { get; set; }
        public string EmpAddressDetails { get; set; }
        public int? EmpLId { get; set; }

        public virtual City EmpC { get; set; }
        public virtual Locations EmpL { get; set; }
    }
}
