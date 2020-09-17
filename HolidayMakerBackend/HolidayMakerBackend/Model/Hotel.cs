﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayMakerBackend.Model
{
    public class Hotel
    {
        [Key]
        public int HotelID { get; set; }
        public int CityID { get; set; }
        public string HotelDescription { get; set; }
        public string Name { get; set; }
        public int DistansToBeach { get; set; }
        public int DistansToCenter { get; set; }
        public bool HasAllInclusive { get; set; }

        public bool HasFullBoard { get; set; }
        public bool HasHalfBoard { get; set; }
        public bool HasRestaurant { get; set; }
        public bool HasChildrensClub { get; set; }
        public bool HasEntertainment { get; set; }
        public bool HasPool { get; set; }
        public bool FilterReset { get; set; }
        public bool Test { get; set; }
        public bool Test2 { get; set; }
    }
}
