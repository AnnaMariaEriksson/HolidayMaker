using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HolidayMakerBackend.Model;

namespace HolidayMakerBackend.Data
{
    public class HolidayMakerBackendContext : DbContext
    {
        public HolidayMakerBackendContext (DbContextOptions<HolidayMakerBackendContext> options)
            : base(options)
        {
        }

        public DbSet<HolidayMakerBackend.Model.Region> Region { get; set; }

        public DbSet<HolidayMakerBackend.Model.City> City { get; set; }
    }
}
