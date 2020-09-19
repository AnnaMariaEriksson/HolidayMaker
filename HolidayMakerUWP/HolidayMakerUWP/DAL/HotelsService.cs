﻿using HolidayMakerUWP.Model;
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

namespace HolidayMakerUWP.DAL
{
    public class HotelsService
    {
        private string roomURL = "https://localhost:44368/api/rooms";
        private static string regionURL = "https://localhost:44368/api/regions";
        private static string cityURL = "https://localhost:44368/api/cities";
        private static string userURL = "";
        
        public static Hotel SelectedHotel { get; set; }

        private const string WebServiceUrl = "https://localhost:44368/api/";
        private static string TempOrderId = null;
        public static async Task<ObservableCollection<Hotel>> GetHotels()
        {
                using (HttpClient httpClient1 = new HttpClient())
                {
                    ObservableCollection<Hotel> Hotels = new ObservableCollection<Hotel>();
                    httpClient1.Timeout = new TimeSpan(0, 0, 5);
                    httpClient1.DefaultRequestHeaders.Accept.Clear();
                    httpClient1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var jsonResult = await httpClient1.GetStringAsync(WebServiceUrl + "hotels");

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

                var jsonResult = await httpClient1.GetStringAsync(WebServiceUrl + "Rooms/" + HotelId);

                Rooms = JsonConvert.DeserializeObject<ObservableCollection<Room>>(jsonResult);

                httpClient1.Dispose();
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

        public static async Task<ObservableCollection<City>> GetAllCitiesAsync()
        {
            using (HttpClient httpClient1 = new HttpClient())
            {
                var jsonCities = await httpClient1.GetStringAsync(cityURL);

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.MissingMemberHandling = MissingMemberHandling.Error;

                var cities = JsonConvert.DeserializeObject<ObservableCollection<City>>(jsonCities, settings);

                return cities;
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
                var content = await response.Content.ReadAsStringAsync();
                user = JsonConvert.DeserializeObject<User>(content);

                return user;
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
    }

}
