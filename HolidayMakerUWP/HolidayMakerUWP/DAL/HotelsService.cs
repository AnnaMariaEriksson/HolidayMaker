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
        LogInViewModel lVm;
        private string roomURL = "https://localhost:44368/api/rooms";
        private static string regionURL = "https://localhost:44368/api/regions";
        private static string cityURL = "https://localhost:44368/api/cities";
        private static string userURL = "https://localhost:44368/api/users";

        public static Hotel SelectedHotel { get; set; }
        public static int SortByInt { get; set; } = 1;

        private const string WebServiceUrl = "https://localhost:44368/api/";
        private static string TempOrderId = null;
        //Hotels
        public static async Task<ObservableCollection<Hotel>> GetHotels()
        {
            using (HttpClient httpClient1 = new HttpClient())
            {
                ObservableCollection<Hotel> Hotels = new ObservableCollection<Hotel>();

                httpClient1.DefaultRequestHeaders.Accept.Clear();
                httpClient1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //var test = WebServiceUrl + "hotels/" + FrontPageSearchViewModel.Search.Cities.CityID + "/"
                //        + "2018" + "/" + "2019"

                var jsonResult = await httpClient1.GetStringAsync(WebServiceUrl + "hotels/"
                        + FrontPageSearchViewModel.Search.Cities.CityID + "/"
                        + FrontPageSearchViewModel.Search.StartDate.UtcDateTime.ToString("yyyy-MM-dd") + "/"
                        + FrontPageSearchViewModel.Search.EndDate.UtcDateTime.ToString("yyyy-MM-dd"));

                Hotels = JsonConvert.DeserializeObject<ObservableCollection<Hotel>>(jsonResult);

                httpClient1.Dispose();
                return Hotels;
            }
        }
        //Rooms
        public static async Task<ObservableCollection<Room>> GetRooms(int HotelId)
        {
            using (HttpClient httpClient1 = new HttpClient())
            {
                ObservableCollection<Room> Rooms = new ObservableCollection<Room>();
                httpClient1.Timeout = new TimeSpan(0, 0, 5);
                httpClient1.DefaultRequestHeaders.Accept.Clear();
                httpClient1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var jsonResult = await httpClient1.GetStringAsync(WebServiceUrl + "Rooms/" + HotelId + "/" + SortByInt + "/"
                    + FrontPageSearchViewModel.Search.StartDate.UtcDateTime.ToString("yyyy-MM-dd") + "/"
                    + FrontPageSearchViewModel.Search.EndDate.UtcDateTime.ToString("yyyy-MM-dd"));

                Rooms = JsonConvert.DeserializeObject<ObservableCollection<Room>>(jsonResult);

                httpClient1.Dispose();
                RoomSelectionVm.TempRooms = Rooms;
                return Rooms;
            }
        }
        public static async Task<Room> GetRoom(int RoomId)
        {
            using (HttpClient httpClient1 = new HttpClient())
            {
                Room Room = new Room();
                httpClient1.Timeout = new TimeSpan(0, 0, 5);
                httpClient1.DefaultRequestHeaders.Accept.Clear();
                httpClient1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var jsonResult = await httpClient1.GetStringAsync(WebServiceUrl + "Rooms/" + RoomId);

                Room = JsonConvert.DeserializeObject<Room>(jsonResult);

                httpClient1.Dispose();
                return Room;
            }
        }
        //Regions
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
        //User
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
        //Bookings
        public static async Task PostBooking(ObservableCollection<Room> rooms, DateTimeOffset startDate, DateTimeOffset endDate, string phoneNumber, string adress)
        {
            foreach (Room r in rooms) { 
            using (HttpClient httpClient1 = new HttpClient())
            {
                Booking booking = new Booking()
                {
                    BookedRoom = r,
                    roomID = r.ID,
                    StartDate = startDate,
                    EndDate = endDate,
                    UserID = LogInViewModel.User.ID,
                    PhoneNumber = phoneNumber,
                    Adress = adress
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
        public static async Task<ObservableCollection<Booking>> GetNewBookings(int userId)
        {
            using (HttpClient httpClient1 = new HttpClient())
            {
                ObservableCollection<Booking> newBooking= new ObservableCollection<Booking>();
                httpClient1.Timeout = new TimeSpan(0, 0, 5);
                httpClient1.DefaultRequestHeaders.Accept.Clear();
                httpClient1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var jsonResult = await httpClient1.GetStringAsync(WebServiceUrl + "bookings/" + userId + "/new");

                newBooking = JsonConvert.DeserializeObject<ObservableCollection<Booking>>(jsonResult);

                httpClient1.Dispose();
                return newBooking;
            }
        }
        public static async Task<ObservableCollection<Booking>> GetOldBookings(int userId)
        {
            using (HttpClient httpClient1 = new HttpClient())
            {
               ObservableCollection<Booking> oldBookings = new ObservableCollection<Booking>();
                httpClient1.Timeout = new TimeSpan(0, 0, 5);
                httpClient1.DefaultRequestHeaders.Accept.Clear();
                httpClient1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var jsonResult = await httpClient1.GetStringAsync(WebServiceUrl + "bookings/" + userId + "/old");

                oldBookings = JsonConvert.DeserializeObject<ObservableCollection<Booking>>(jsonResult);

                httpClient1.Dispose();
                return oldBookings;
            }
        }
        public static async Task DeleteBooking(Booking booking)
        {
            using (HttpClient httpClient1 = new HttpClient())
            {                
                var json = JsonConvert.SerializeObject(booking);
                HttpContent httpContent = new StringContent(json);

                httpClient1.Timeout = new TimeSpan(0, 0, 5);
                httpContent.Headers.Clear();
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                await httpClient1.DeleteAsync(WebServiceUrl + "Bookings/" + booking.BookingID);

                httpClient1.Dispose();
            }
        }
    }

}
