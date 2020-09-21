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
using System.Net.Http.Headers;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;
using System.Net;

namespace HolidayMakerUWP.DAL
{
    public class HotelsService
    {
        private string roomURL = "https://localhost:44368/api/rooms";
        private static string regionURL = "https://localhost:44368/api/regions";
        private static string cityURL = "https://localhost:44368/api/cities";
        private static string userURL = "https://localhost:44368/api/users";
        
        public static Hotel SelectedHotel { get; set; }
        public static int SortByInt { get; set; } = 1;

        private const string WebServiceUrl = "https://localhost:44368/api/";
        private static string TempOrderId = null;
        public static async Task<ObservableCollection<Hotel>> GetHotels()
        {
                using (HttpClient httpClient1 = new HttpClient())
                {
                    ObservableCollection<Hotel> Hotels = new ObservableCollection<Hotel>();
      
                    httpClient1.DefaultRequestHeaders.Accept.Clear();
                    httpClient1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var jsonResult = await httpClient1.GetStringAsync(WebServiceUrl + "hotels/" 
                        + FrontPageSearchViewModel.Search.Cities.CityID + "/"
                        + FrontPageSearchViewModel.Search.StartDate.UtcDateTime +"/" 
                        + FrontPageSearchViewModel.Search.EndDate.UtcDateTime);

                    Hotels = JsonConvert.DeserializeObject<ObservableCollection<Hotel>>(jsonResult);

                    httpClient1.Dispose();
                    return Hotels;
                }
        }

        public static async Task<ObservableCollection<Room>> GetRooms(int HotelId)
        {
            using (HttpClient httpClient1 = new HttpClient())
            {
                ObservableCollection<Room> Rooms = new ObservableCollection<Room>();
                httpClient1.Timeout = new TimeSpan(0, 0, 5);
                httpClient1.DefaultRequestHeaders.Accept.Clear();
                httpClient1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var jsonResult = await httpClient1.GetStringAsync(WebServiceUrl + "Rooms/" + HotelId + "/" + SortByInt);

                Rooms = JsonConvert.DeserializeObject<ObservableCollection<Room>>(jsonResult);

                httpClient1.Dispose();
                RoomSelectionVm.TempRooms = Rooms;
                return Rooms;
            }
        }

        public static async Task<ObservableCollection<City>> GetCities(int regionID)
        {
            using (HttpClient httpClient1 = new HttpClient())
            {
                ObservableCollection<City> Cities = new ObservableCollection<City>();
                httpClient1.Timeout = new TimeSpan(0,0,5);
                httpClient1.DefaultRequestHeaders.Accept.Clear();
                httpClient1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var jsonResult = await httpClient1.GetStringAsync(WebServiceUrl + "cities/" + regionID);

                Cities = JsonConvert.DeserializeObject<ObservableCollection<City>>(jsonResult);

                httpClient1.Dispose();
                return Cities;
            }
        }
        public static async Task<ObservableCollection<Regions>> GetRegions(int regionID)
        {
            using (HttpClient httpClient1 = new HttpClient())
            {
                ObservableCollection<Regions> Regions = new ObservableCollection<Regions>();
                httpClient1.Timeout = new TimeSpan(0, 0, 5);
                httpClient1.DefaultRequestHeaders.Accept.Clear();
                httpClient1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var jsonResult = await httpClient1.GetStringAsync(WebServiceUrl + "regions/" + regionID);

                Regions = JsonConvert.DeserializeObject<ObservableCollection<Regions>>(jsonResult);

                httpClient1.Dispose();
                return Regions;
            }
        }

        public async Task<ObservableCollection<Room>> GetAllRoomsAsync()
        {
            using (HttpClient httpClient1 = new HttpClient())
            {
                var jsonRooms = await httpClient1.GetStringAsync(roomURL);

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.MissingMemberHandling = MissingMemberHandling.Error;

                var rooms = JsonConvert.DeserializeObject<ObservableCollection<Room>>(jsonRooms, settings);

                return rooms;
            }
        }

        public static async Task<ObservableCollection<Regions>> GetAllRegionsAsync()
        {
            using (HttpClient httpClient1 = new HttpClient())
            {
                var jsonRegions = await httpClient1.GetStringAsync(regionURL);

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.MissingMemberHandling = MissingMemberHandling.Error;

                var regions = JsonConvert.DeserializeObject<ObservableCollection<Regions>>(jsonRegions, settings);

                return regions;
            }
        }

        public static async Task<ObservableCollection<City>> GetCities()
        {
            using (HttpClient httpClient1 = new HttpClient())
            {
                ObservableCollection<City> Cities = new ObservableCollection<City>();
                httpClient1.Timeout = new TimeSpan(0, 0, 5);
                httpClient1.DefaultRequestHeaders.Accept.Clear();
                httpClient1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var jsonResult = await httpClient1.GetStringAsync(WebServiceUrl + "Cities/");

                Cities = JsonConvert.DeserializeObject<ObservableCollection<City>>(jsonResult);

                httpClient1.Dispose();
                return Cities;
            }
        }

        public async Task<ObservableCollection<User>> GetAllUsersAsync()
        {
            using (HttpClient httpClient1 = new HttpClient())
            {
                var jsonUsers = await httpClient1.GetStringAsync(userURL);

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.MissingMemberHandling = MissingMemberHandling.Error;

                var users = JsonConvert.DeserializeObject<ObservableCollection<User>>(userURL, settings);

                return users;
            }
            
        }

        public static async Task<User> AddUsersAsync(User user)
        {
            using (HttpClient httpClient1 = new HttpClient())
            {
                var users = JsonConvert.SerializeObject(user);
                HttpContent httpContent = new StringContent(users);

                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await httpClient1.PostAsync(userURL, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<User>(content);

                    return user;
                }
                else if (response.StatusCode == HttpStatusCode.Conflict)
                {
                    //TODO decide how to handle this issue
                }

                throw new Exception($"Failed to post {userURL} with {await httpContent.ReadAsStringAsync()}. Got statuscode {response.StatusCode} with message: {await response.Content.ReadAsStringAsync()}");
            }
        }



        //public  ObservableCollection<Regions> GetRegions()
        //{
        //    ObservableCollection<Regions> Regions = FrontPageSearchViewModel.Regions;
        //    // todo fix the list below so it's accessible.
        //    ObservableCollection<Hotel> hotels = GetHotels();
        //    var cities = new List<City>
        //    {
        //        new City { NameOfCity = "Malmö", CityID = 1, RegionID = 1, Hotels = hotels},
        //        new City {NameOfCity = "Lund", CityID = 2, RegionID = 1, Hotels = hotels},
        //        new City {NameOfCity = "Kristianstad", CityID = 3, RegionID = 1, Hotels = hotels}
        //    };
        //    Regions region1 = new Regions
        //    {
        //        NameOfRegion = "Skåne",
        //        RegionID = 1,
        //        Cities = cities
        //    };

        //    Regions.Add(region1);

        //    return Regions;
        //}
public static async Task<User> GetUser(string email, string password)
        {
            using (HttpClient httpClient1 = new HttpClient())
            {
                User user = new User();
                httpClient1.Timeout = new TimeSpan(0, 0, 5);
                httpClient1.DefaultRequestHeaders.Accept.Clear();
                httpClient1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var jsonResult = await httpClient1.GetStringAsync(WebServiceUrl + "users/" + email + "/" + password);

                user = JsonConvert.DeserializeObject<User>(jsonResult);

                httpClient1.Dispose();
                return user;
            }
        }
        public static async Task PostBooking(ObservableCollection<Room> rooms, DateTime startDate, DateTime endDate)
        {            
            using (HttpClient httpClient1 = new HttpClient())
            {
                Booking booking = new Booking()
                {
                    BookingRooms = rooms,
                    StartDate = startDate,
                    EndDate = endDate,
                    UserID = LogInViewModel.User.ID
                };
                var json = JsonConvert.SerializeObject(booking);
                HttpContent httpContent = new StringContent(json);

                httpClient1.Timeout = new TimeSpan(0, 0, 5);
                httpContent.Headers.Clear();
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");               
                                                                                             
                await httpClient1.PostAsync(WebServiceUrl + "Bookings", httpContent);

                httpClient1.Dispose();                
            }            
        }
    }

}
