using HolidayMakerUWP.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HolidayMakerUWP.Viewmodel;
using Newtonsoft.Json;

namespace HolidayMakerUWP.DAL
{
    public class HotelsService
    {

        private HttpClient httpClient;

        private string roomURL = "";

        private string regionURL = "";

        private string cityURL = "";

        public FrontPageSearchViewModel FrontPageSearchViewModel { get; set; }
        public ObservableCollection<Hotel> GetHotels()
        {
            ObservableCollection<Hotel> Hotels = new ObservableCollection<Hotel>();
            Hotel h1 = new Hotel() { Name = "Hotel 1", HotelDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec nulla mauris, fermentum condimentum metus sed, pretium venenatis diam. Sed luctus malesuada interdum. Praesent eros diam, aliquam ac enim et, mattis aliquet dolor. Aliquam erat volutpat. Maecenas lacinia dignissim nunc vel fermentum. Proin a nibh eget libero sagittis sodales. Donec et laoreet arcu. Curabitur ut massa mi. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas porttitor lectus eu tortor vulputate dignissim. Proin ultrices risus ut lectus volutpat, quis maximus odio faucibus. Quisque placerat in dui nec placerat. Suspendisse sem mauris, tristique nec ullamcorper ut, pellentesque tempor nisi. Cras accumsan urna ligula, vitae congue sem sollicitudin sit amet.", Test = true, FilterReset = true, DistansToCenter = 40, DistansToBeach = 10, HasAllInclusive = false, HasFullBoard = true, HasHalfBoard = false, HasRestaurant = true, HasChildrensClub = false, HasEntertainment = true, HasPool = false, HotelID = 1 };
            Hotel h2 = new Hotel() { Name = "Hotel 2", HotelDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec nulla mauris, fermentum condimentum metus sed, pretium venenatis diam. Sed luctus malesuada interdum. Praesent eros diam, aliquam ac enim et, mattis aliquet dolor. Aliquam erat volutpat. Maecenas lacinia dignissim nunc vel fermentum. Proin a nibh eget libero sagittis sodales. Donec et laoreet arcu. Curabitur ut massa mi. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas porttitor lectus eu tortor vulputate dignissim. Proin ultrices risus ut lectus volutpat, quis maximus odio faucibus. Quisque placerat in dui nec placerat. Suspendisse sem mauris, tristique nec ullamcorper ut, pellentesque tempor nisi. Cras accumsan urna ligula, vitae congue sem sollicitudin sit amet.", Test = true, FilterReset = true, DistansToCenter = 30, DistansToBeach = 25, HasAllInclusive = true, HasFullBoard = false, HasHalfBoard = true, HasRestaurant = true, HasChildrensClub = false, HasEntertainment = true, HasPool = false, HotelID = 2 };
            Hotel h3 = new Hotel() { Name = "Hotel 3", HotelDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec nulla mauris, fermentum condimentum metus sed, pretium venenatis diam. Sed luctus malesuada interdum. Praesent eros diam, aliquam ac enim et, mattis aliquet dolor. Aliquam erat volutpat. Maecenas lacinia dignissim nunc vel fermentum. Proin a nibh eget libero sagittis sodales. Donec et laoreet arcu. Curabitur ut massa mi. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas porttitor lectus eu tortor vulputate dignissim. Proin ultrices risus ut lectus volutpat, quis maximus odio faucibus. Quisque placerat in dui nec placerat. Suspendisse sem mauris, tristique nec ullamcorper ut, pellentesque tempor nisi. Cras accumsan urna ligula, vitae congue sem sollicitudin sit amet.", Test = true, FilterReset = true, DistansToCenter = 49, DistansToBeach = 45, HasAllInclusive = false, HasFullBoard = false, HasHalfBoard = false, HasRestaurant = true, HasChildrensClub = false, HasEntertainment = true, HasPool = false, HotelID = 3 };
            Hotels.Add(h1);
            Hotels.Add(h2);
            Hotels.Add(h3);

            return Hotels;
        }

        public ObservableCollection<Room> GetRooms()
        {
            ObservableCollection<Room> Rooms = new ObservableCollection<Room>();
            Room r1 = new Room()
            {
                Price = 1999,
                ExtraBed = false,
                HasAllInclusive = true,
                IsAllInclusive = false,
                HasFullBoard = true,
                HasHalfBoard = true,
                RoomName = "Deluxe rum, utsikt över havet"
            };
            Room r2 = new Room()
            {
                Price = 50,
                ExtraBed = false,
                HasAllInclusive = true,
                IsAllInclusive = false,
                HasFullBoard = false,
                HasHalfBoard = true,
                RoomName = "Basic rum, Källare"
            };
            Room r3 = new Room()
            {
                Price = 3999,
                ExtraBed = false,
                HasAllInclusive = false,
                IsAllInclusive = false,
                HasFullBoard = true,
                HasHalfBoard = false,
                RoomName = "Suite rum"
            };
            Rooms.Add(r1);
            Rooms.Add(r2);
            Rooms.Add(r3);

            return Rooms;
        }

        public async Task<ObservableCollection<Room>> GetAllRoomsAsync()
        {
            var jsonRooms = await httpClient.GetStringAsync(roomURL);

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Error;

            var rooms = JsonConvert.DeserializeObject<ObservableCollection<Room>>(jsonRooms, settings);

            return rooms;
        }

        public async Task<ObservableCollection<Regions>> GetAllRegionsAsync()
        {
            var jsonRegions = await httpClient.GetStringAsync(regionURL);

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Error;

            var regions = JsonConvert.DeserializeObject<ObservableCollection<Regions>>(jsonRegions, settings);

            return regions;
        }

        public async Task<ObservableCollection<City>> GetAllCitiesAsync()
        {
            var jsonCities = await httpClient.GetStringAsync(cityURL);

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Error;

            var cities = JsonConvert.DeserializeObject<ObservableCollection<City>>(jsonCities, settings);

            return cities;
        }



        public ObservableCollection<Regions> GetRegions()
        {
            ObservableCollection<Regions> Regions = FrontPageSearchViewModel.Regions;
            // todo fix the list below so it's accessible.
            List<Hotel> hotels = GetHotels().ToList();
            var cities = new List<City>
            {
                new City { NameOfCity = "Malmö", CityID = 1, RegionID = 1, Hotels = hotels},
                new City {NameOfCity = "Lund", CityID = 2, RegionID = 1, Hotels = hotels},
                new City {NameOfCity = "Kristianstad", CityID = 3, RegionID = 1, Hotels = hotels}
            };
            Regions region1 = new Regions
            {
                NameOfRegion = "Skåne",
                RegionID = 1,
                Cities = cities
            };

            Regions.Add(region1);

            return Regions;
        }

        public User GetUser()
        {
            User user1 = new User()
            {
                UserID = 1,
                Password = "Skander123",
                FirstName = "Skander",
                LastName = "Damoussi",
                Email = "Skander.Damoussi@gmail.com",
                UserBookings = new ObservableCollection<Booking>
                {
                    new Booking()
                    {
                        BookingID = 1,
                        EndDate = DateTime.Now,
                        StartDate = DateTime.Now
                    },
                    new Booking()
                    {
                        BookingID = 2,
                        EndDate = DateTime.Now,
                        StartDate = DateTime.Now
                    }
                }
            };
            
            return user1;
        }
    }
}
