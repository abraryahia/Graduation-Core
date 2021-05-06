using System;
using System.Collections.Generic;

namespace Graduation_Core.Models
{
    public partial class ReceiverInfo
    {
        public long RId { get; set; }
        public string RName { get; set; }
        public string RMobile { get; set; }
        public string REmail { get; set; }
        public string RAddress { get; set; }
        public string RSsn { get; set; }
        public long SId { get; set; }
        public int RCId { get; set; }
        public string RAddressDetail { get; set; }
        public int RCDId { get; set; }

        public virtual SenderInfo S { get; set; }
    }
}
