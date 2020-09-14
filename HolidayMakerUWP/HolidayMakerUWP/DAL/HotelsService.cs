using HolidayMakerUWP.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayMakerUWP.DAL
{
   public class HotelsService
    {
        public ObservableCollection<Hotel> GetHotels()
        {
            ObservableCollection<Hotel> Hotels = new ObservableCollection<Hotel>();
            Hotel h1 = new Hotel() { Name = "Hotel 1", FilterReset = true, DistansToCenter = 40, DistansToBeach = 10, HasAllInclusive = false, HasFullBoard = true, HasHalfBoard = false, HasRestaurant = true, HasChildrensClub = false, HasEntertainment = true, HasPool = false, HotelID = 1 };
            Hotel h2 = new Hotel() { Name = "Hotel 2", FilterReset = true, DistansToCenter = 30, DistansToBeach = 25, HasAllInclusive = true, HasFullBoard = false, HasHalfBoard = true, HasRestaurant = true, HasChildrensClub = false, HasEntertainment = true, HasPool = false, HotelID = 2 };
            Hotel h3 = new Hotel() { Name = "Hotel 3", FilterReset = true, DistansToCenter = 50, DistansToBeach = 45, HasAllInclusive = false, HasFullBoard = false, HasHalfBoard = false, HasRestaurant = true, HasChildrensClub = false, HasEntertainment = true, HasPool = false, HotelID = 3 };
            Hotels.Add(h1);
            Hotels.Add(h2);
            Hotels.Add(h3);

            return Hotels;
        }

        public ObservableCollection<Regions> GetRegions()
        {
            ObservableCollection<Regions> Regions = new ObservableCollection<Regions>();
            List<Hotel> hotels = GetHotels().ToList();
            var cities = new List<City>
            {
                new City { NameOfCity = "Malmö", CityID = 1, RegionID = 1, Hotels = hotels},
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

            Room room1 = new Room {HotelID = 1, IsAllInclusive = false, NumberOfBeds = 3, RoomID = 1};

            Rooms.Add(room1);

            return Rooms;
        }

    }
}
