﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayMakerUWP.Model
{
    public class Room
    {
        public int ID { get; set; }
        public int HotelID { get; set; }
        public int Price { get; set; }
        public bool ExtraBed { get; set; }
        public bool IsExtraBed { get; set; }
        public bool HasAllInclusive { get; set; }
        public double Rating { get; set; }
        public bool IsAllInclusive { get; set; }
        public bool HasFullBoard { get; set; }
        public bool IsFullBoard { get; set; }
        public bool HasHalfBoard { get; set; }
        public bool IsHalfBoard { get; set; }
        public string RoomName { get; set; }
        public int BookingID { get; set; }
    }
}
