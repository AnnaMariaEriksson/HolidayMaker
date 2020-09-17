using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayMakerBackend.Model
{
    public class Room
    {
        [Key]
        public int RoomID { get; set; }
        public int HotelID { get; set; }
        public int Price { get; set; }
        public bool ExtraBed { get; set; }
        public bool HasAllInclusive { get; set; }
        public bool IsAllInclusive { get; set; }
        public bool HasFullBoard { get; set; }
        public bool HasHalfBoard { get; set; }
        public string RoomName { get; set; }
        public int NumberOfBeds { get; set; }
    }
}
