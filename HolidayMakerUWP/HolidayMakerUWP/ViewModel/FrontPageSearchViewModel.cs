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

        private HttpClient httpClient;
        private string roomURL = "";
        //Just a comment.

        public FrontPageSearchViewModel()
        {
            Rooms = new ObservableCollection<Room>();
            httpClient = new HttpClient();
        }

        public async Task<ObservableCollection<Room>> GetAllRoomsAsync()
        {
            var jsonRooms = await httpClient.GetStringAsync(roomURL);

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Error;

            var rooms = JsonConvert.DeserializeObject<ObservableCollection<Room>>(jsonRooms, settings);

            return rooms;
        }

        public ObservableCollection<Regions> GetRegions()
        {
            ObservableCollection<Regions> Regions = new ObservableCollection<Regions>();
            //List<Hotel> hotels = GetHotels().ToList();
            var cities = new List<City>
            {
                new City { NameOfCity = "Malmö", CityID = 1, RegionID = 1},
                new City {NameOfCity = "Lund", CityID = 2, RegionID = 1},
                new City {NameOfCity = "Kristianstad", CityID = 3, RegionID = 1}
            };
            Regions r1 = new Regions
            {
                NameOfRegion = "Skåne",
                RegionID = 1,
                Cities = cities
            };

            Regions.Add(r1);

            return Regions;
        }

        public ObservableCollection<Room> GetRooms()
        {
            ObservableCollection<Room> Rooms = new ObservableCollection<Room>();

            Room room1 = new Room { HotelID = 1, IsAllInclusive = false, NumberOfBeds = 3, RoomID = 1 };

            Rooms.Add(room1);

            return Rooms;
        }
    }
}
