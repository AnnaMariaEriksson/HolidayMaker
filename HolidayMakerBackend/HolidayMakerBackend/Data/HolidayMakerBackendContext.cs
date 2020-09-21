using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HolidayMakerBackend.Models;

namespace HolidayMakerBackend.Data
{
    public class HolidayMakerBackendContext : DbContext
    {
        public HolidayMakerBackendContext (DbContextOptions<HolidayMakerBackendContext> options)
            : base(options)
        {
        }

        public DbSet<HolidayMakerBackend.Models.User> User { get; set; }

        public DbSet<HolidayMakerBackend.Models.Booking> Booking { get; set; }

        public DbSet<HolidayMakerBackend.Models.Room> Room { get; set; }

        public DbSet<HolidayMakerBackend.Models.Hotel> Hotel { get; set; }
        public DbSet<HolidayMakerBackend.Models.Region> Region { get; set; }

        public DbSet<HolidayMakerBackend.Models.City> City { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Region>().HasData(new Region
            {
                RegionID = 1, NameOfRegion = "Skåne"
            });

            modelBuilder.Entity<City>().HasData(new City
            {
                CityID = 1,
                NameOfCity = "Malmö",
                RegionID = 1
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                FirstName = "Bosse",
                LastName = "Larsson",
                Email = "bosse@123.se",
                Password = "hejhej",
                ID = 1
            });

            modelBuilder.Entity<Hotel>().HasData(new Hotel
            {
                CityID = 1,
                DistansToBeach = 20,
                DistansToCenter = 1,
                FilterReset = true,
                HasAllInclusive = true,
                HasChildrensClub = false,
                HasEntertainment = true,
                HasFullBoard = false,
                HasHalfBoard = false,
                HasPool = true,
                Test = true,    
                Test2 = true,
                HotelID = 1,
                Name = "Bosses hotell",
                HasRestaurant = true,
                HotelDescription = "Ett fint hotell"
            });

            modelBuilder.Entity<Room>().HasData(new Room
            {
                ExtraBed = true,
                HasAllInclusive = true,
                HasFullBoard = false,
                HasHalfBoard = false,
                HotelID = 1,
                IsAllInclusive = true,
                Price = 300,
                RoomName = "Rum 1",
                ID = 1
            });
        }
    }
}
