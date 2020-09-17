using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayMakerBackend.Model
{
    public class Region
    {
        [Key]
        public int RegionID { get; set; }
        public string NameOfRegion { get; set; }
        public virtual List<City> Cities { get; set; }
    }
}
