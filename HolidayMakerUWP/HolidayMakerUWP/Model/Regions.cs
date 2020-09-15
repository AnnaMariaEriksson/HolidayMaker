using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayMakerUWP.Model
{
    public class Regions
    {
        public int RegionID { get; set; }
        public string NameOfRegion { get; set; }
        public List<City> Cities { get; set; }

        public Regions()
        {

        }

    }
}
