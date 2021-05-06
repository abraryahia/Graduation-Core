using System;
using System.Collections.Generic;

namespace Graduation_Core.Models
{
    public partial class Locations
    {
        public Locations()
        {
            Employee = new HashSet<Employee>();
            PackagesInfo = new HashSet<PackagesInfo>();
        }

        public int LId { get; set; }
        public string LFrom { get; set; }
        public string LTo { get; set; }
        public int Price { get; set; }
        public int CId { get; set; }

        public virtual City C { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<PackagesInfo> PackagesInfo { get; set; }
    }
}
