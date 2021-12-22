using LibAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibAPI.Contexts
{
    public class CityInfoContext : DbContext
    {
      public DbSet<City> Cities { get; set; }

      public DbSet<PointOfInterest> PointsOfInterest { get; set; }

        public CityInfoContext(DbContextOptions<CityInfoContext> options) : base(options)

        {
            Database.EnsureCreated();
        }
    }
}
