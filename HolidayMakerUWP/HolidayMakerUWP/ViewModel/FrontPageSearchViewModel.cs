using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HolidayMakerUWP.DAL;
using HolidayMakerUWP.Model;
using Newtonsoft.Json;

namespace HolidayMakerUWP.Viewmodel
{
    public class FrontPageSearchViewModel
    {
        public ObservableCollection<Regions> Regions { get; set; }
        public ObservableCollection<City> Cities { get; set; }
        public ObservableCollection<City> TempCity { get; set; }
        public Search Search { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public FrontPageSearchViewModel()
        {
            Regions = new ObservableCollection<Regions>();
            Cities = new ObservableCollection<City>();
            TempCity = new ObservableCollection<City>();

            var cities = new List<City>
            {
                new City { NameOfCity = "Malmö", CityID = 1, RegionID = 1},
                new City {NameOfCity = "Lund", CityID = 2, RegionID = 1},
                new City {NameOfCity = "Kristianstad", CityID = 3, RegionID = 1}
            };

            Regions.Add(new Regions{NameOfRegion = "Skåne", RegionID = 1, Cities = cities});
            Regions.Add(new Regions{NameOfRegion = "Stockholm", RegionID = 2});
            Cities.Add(new City{NameOfCity = "Nån stad i Skåne", RegionID = 1});
            Cities.Add(new City { NameOfCity = "En till stad i Skåne", RegionID = 1 });
            Cities.Add(new City{NameOfCity = "Nån stad i Sthlm", RegionID = 2, CityID = 4});
            
        }

    }

}
