using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayMakerUWP.Model
{
    public class Room
    {
        public int RoomID { get; set; }
        public int HotelID { get; set; }
        public int NumberOfBeds { get; set; }
        public bool IsAllInclusive { get; set; }
    }
}
