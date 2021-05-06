using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation_Core.Models
{
    public class CityModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class LocationsModel:CityModel
    {
        public string From { get; set; }
        public string To { get; set; }
        public int LocationID { get; set; }
        public int CityID { get; set; }
        public int Price { get; set; }

    }
}
