using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayMakerBackend.Models
{
    public class Booking
    {
        public int BookingID { get; set; }
        public int BookedRoomID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public int UserID { get; set; }
        public Booking()
        {
        }
    }
}
