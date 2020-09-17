using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayMakerBackend.Model
{
    public class City
    {
        [Key]
        public int CityID { get; set; }
        public int RegionID { get; set; }
        public string NameOfCity { get; set; }
        public virtual List<Hotel> Hotels { get; set; }
    }
}
