using System;
using System.Collections.Generic;

namespace Graduation_Core.Models
{
    public partial class SenderInfo
    {
        public SenderInfo()
        {
            ReceiverInfo = new HashSet<ReceiverInfo>();
        }

        public long SId { get; set; }
        public string SName { get; set; }
        public string SMobile { get; set; }
        public string SEmail { get; set; }
        public string SAddress { get; set; }
        public string SSsn { get; set; }
        public int SCId { get; set; }
        public string SAddressDetail { get; set; }
        public int SCDId { get; set; }

        public virtual ICollection<ReceiverInfo> ReceiverInfo { get; set; }
    }
}
