﻿using System;
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
        public Room BookedRoom { get; set; }
        public int roomID { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public int UserID { get; set; }
        public Booking() { }
    }
}
