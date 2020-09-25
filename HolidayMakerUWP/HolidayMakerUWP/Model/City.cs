using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayMakerUWP.Model
{
    public class City
    {

        public int CityID { get; set; }
        public int RegionID { get; set; }
        public string NameOfCity { get; set; }
        public ObservableCollection<Hotel> Hotels { get; set; }

        public City(int cityId, int regionId, string nameOfCity, ObservableCollection<Hotel> hotels)
        {
            this.CityID = cityId;
            this.RegionID = regionId;
            this.NameOfCity = nameOfCity;
            this.Hotels = hotels;
        }

        public City() { }

    }
}
