using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayMakerUWP.Model
{
   public class Hotel
    {
        public  int HotelID { get; set; }
        public  int DistansToBeach { get; set; }
        public  int DistansToCenter { get; set; }
        public string HasAllInclusive { get; set; }
        public  string HasFullBoard { get; set; }
        public  bool HasHalfBoard { get; set; }
        public  bool HasRestaurant { get; set; }
        public  bool HasChildrensClub { get; set; }
        public  bool HasEntertainment { get; set; }
        public  bool HasPool { get; set; }

        public Hotel()
        {
        }
    }
}
