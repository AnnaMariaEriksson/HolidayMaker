using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayMakerBackend.Models
{
    public class City
    {
        public int CityID { get; set; }
        public int RegionID { get; set; }
        public string NameOfCity { get; set; }

        public City()
        {

        }
    }
}
