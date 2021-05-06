using System;
using System.Collections.Generic;

namespace Graduation_Core.Models
{
    public partial class CityDetails
    {
        public int CDId { get; set; }
        public int CId { get; set; }
        public string TCName { get; set; }

        public virtual City C { get; set; }
    }
}
