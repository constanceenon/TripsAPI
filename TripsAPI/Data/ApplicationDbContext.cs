using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripsAPI.Entities;

namespace TripsAPI.Data
{
    public class ApplicationDbContext:IdentityDbContext<TripUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base (options)
        {

        }
        public DbSet<Trip> Trips { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            base.OnModelCreating(builder);

            builder.Entity<AppRole>().HasData(
                 new { Id = 1, Name = "SuperAdmin", NormalizedName = "SUPERADMIN" },
                 new { Id = 6, Name = "Super-Administrator", NormalizedName = "SUPER-ADMINISTRATOR" },
                 new { Id = 7, Name = "Administrator", NormalizedName = "ADMINISTRATOR" },
                 new { Id = 8, Name = "Technical-Support", NormalizedName = "TECHNICAL-SUPPORT" },
                 new { Id = 9, Name = "Analyst", NormalizedName = "ANALYST" }
            );

            builder.Entity<ClassOrRole>().HasData(
               new { Id = 1, Name = "SuperAdmin" },
               new { Id = 6, Name = "Super-Administrator" },
               new { Id = 7, Name = "Administrator" },
               new { Id = 8, Name = "Technical-Support" },
               new { Id = 9, Name = "Analyst" }
           );
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
