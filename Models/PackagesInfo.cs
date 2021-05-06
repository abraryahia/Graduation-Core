using System;
using System.Collections.Generic;

namespace Graduation_Core.Models
{
    public partial class PackagesInfo
    {
        public long PId { get; set; }
        public int PWeight { get; set; }
        public string PFaragial { get; set; }
        public double PPrice { get; set; }
        public string Description { get; set; }
        public string Earlydelivery { get; set; }
        public DateTime? Deleverydate { get; set; }
        public string SSsn { get; set; }
        public string RSsn { get; set; }
        public string PDeliverStatus { get; set; }
        public int PLId { get; set; }

        public virtual Locations PL { get; set; }
    }
}
