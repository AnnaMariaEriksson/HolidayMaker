using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HolidayMakerUWP.Model;
using Newtonsoft.Json;

namespace HolidayMakerUWP.Viewmodel
{
    public class FrontPageSearchViewModel
    {
        public ObservableCollection<Room> Rooms { get; set; }
        public ObservableCollection<Regions> Regions { get; set; }
        public ObservableCollection<City> Cities { get; set; }

        //Just a comment.

        public FrontPageSearchViewModel()
        {
            Regions = new ObservableCollection<Regions>();
            Cities = new ObservableCollection<City>();
        }

    }

}
