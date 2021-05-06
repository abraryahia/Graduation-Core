using System;
using System.Collections.Generic;

namespace Graduation_Core.Models
{
    public partial class City
    {
        public City()
        {
            CityDetails = new HashSet<CityDetails>();
            Employee = new HashSet<Employee>();
            Locations = new HashSet<Locations>();
        }

        public int CId { get; set; }
        public string CName { get; set; }
        public string DayOfTravel { get; set; }
        public double CLat { get; set; }
        public double CLong { get; set; }

        public virtual ICollection<CityDetails> CityDetails { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Locations> Locations { get; set; }
    }
}
