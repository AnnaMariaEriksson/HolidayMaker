using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayMakerUWP.Model
{
    public class Booking
    {
        public int BookingID { get; set; }
        public ObservableCollection<Room> BookingRooms { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserID { get; set; }
        public Booking() { }
    }
}
