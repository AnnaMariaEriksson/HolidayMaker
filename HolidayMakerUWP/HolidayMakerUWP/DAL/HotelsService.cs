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
            Hotel h1 = new Hotel() { Name = "Hotel 1", Test = true, FilterReset = true, DistansToCenter = 40, DistansToBeach = 10, HasAllInclusive = false, HasFullBoard = true, HasHalfBoard = false, HasRestaurant = true, HasChildrensClub = false, HasEntertainment = true, HasPool = false, HotelID = 1 };
            Hotel h2 = new Hotel() { Name = "Hotel 2", Test = true, FilterReset = true, DistansToCenter = 30, DistansToBeach = 25, HasAllInclusive = true, HasFullBoard = false, HasHalfBoard = true, HasRestaurant = true, HasChildrensClub = false, HasEntertainment = true, HasPool = false, HotelID = 2 };
            Hotel h3 = new Hotel() { Name = "Hotel 3", Test = true, FilterReset = true, DistansToCenter = 49, DistansToBeach = 45, HasAllInclusive = false, HasFullBoard = false, HasHalfBoard = false, HasRestaurant = true, HasChildrensClub = false, HasEntertainment = true, HasPool = false, HotelID = 3 };
            Hotels.Add(h1);
            Hotels.Add(h2);
            Hotels.Add(h3);

            return Hotels;
        }
        public ObservableCollection<Room> GetRooms()
        {
            ObservableCollection<Room> Rooms = new ObservableCollection<Room>();
            Room r1 = new Room() { Price = 1999, ExtraBed = false, HasAllInclusive = true, IsAllInclusive = false, HasFullBoard = true, HasHalfBoard = true, RoomName ="Deluxe rum, utsikt över havet"};
            Room r2 = new Room() { Price = 50, ExtraBed = false, HasAllInclusive = true, IsAllInclusive = false, HasFullBoard = false, HasHalfBoard = true, RoomName ="Basic rum, Källare"};
            Room r3 = new Room() { Price = 3999, ExtraBed = false, HasAllInclusive = false, IsAllInclusive = false, HasFullBoard = true, HasHalfBoard = false, RoomName ="Suite rum"};
            Rooms.Add(r1);
            Rooms.Add(r2);
            Rooms.Add(r3);

            return Rooms;
        }
    }
}
