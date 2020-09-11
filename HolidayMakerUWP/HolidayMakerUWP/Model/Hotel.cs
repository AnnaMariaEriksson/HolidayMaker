using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayMakerUWP.Model
{
    class Hotel
    {
        public List<Room> Rooms { get; set; }

        public Hotel( List<Room> rooms)
        {
            rooms = Rooms;
        }
    }
}
