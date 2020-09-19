using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HolidayMakerUWP.DAL;
using HolidayMakerUWP.Model;

namespace HolidayMakerUWP.Viewmodel
{
    public class FrontPageSearchViewModel
    {
        public ObservableCollection<Regions> Regions { get; set; }
        public ObservableCollection<City> Cities { get; set; }
        public ObservableCollection<City> TempCity { get; set; }
        public Search Search { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }

        public FrontPageSearchViewModel()
        {
            Regions = new ObservableCollection<Regions>();
            Cities = new ObservableCollection<City>();
            TempCity = new ObservableCollection<City>();

            HotelsService.GetAllRegionsAsync();
            HotelsService.GetAllCitiesAsync();
        }

    }

}
