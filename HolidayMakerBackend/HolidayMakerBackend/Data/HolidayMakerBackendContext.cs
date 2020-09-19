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

        public DbSet<HolidayMakerBackend.Models.City> City { get; set; }
    }
}
