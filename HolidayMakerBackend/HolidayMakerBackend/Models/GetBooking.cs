using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayMakerBackend.Models
{
    public class GetBooking
    {
        public int BookingID { get; set; }
        public Room BookedRoom { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public int UserID { get; set; }
        public GetBooking()
        {
        }
    }
}
