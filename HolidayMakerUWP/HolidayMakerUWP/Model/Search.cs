using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayMakerUWP.Model
{
    class Search
    {
        public List<Regions> Regions { get; set; }
        public List<City> Cities { get; set; }
        public List<Hotel> Hotels { get; set; }
        public double DistanceToCityCenter { get; set; }
        public bool HasFullBoard { get; set; }
        public bool HasHalfBoard { get; set; }
        public bool HasRestaurant { get; set; }
        public bool HasChildrensClub { get; set; }
        public bool HasEntertainment { get; set; }
        public bool HasPool { get; set; }
    }
}
