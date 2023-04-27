using Microsoft.EntityFrameworkCore;
using TravelAgency.Mapping;
using TravelAgency.Models;

namespace TravelAgency.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Cruise> Cruises { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Fleet> Fleets { get; set; }
        public DbSet<Skipper> Skippers { get; set; }

        public DbSet<Crew> Crews { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DatabaseContext(DbContextOptions databaseContextOptions) : base(databaseContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CruiseBuildingConfiguration());
            builder.ApplyConfiguration(new CustomerBuildingConfiguration());
            builder.ApplyConfiguration(new FleetBuildingConfiguration());
            builder.ApplyConfiguration(new SkipperBuildingConfiguration());

            builder.ApplyConfiguration(new CrewBuildingConfiguration());
            builder.ApplyConfiguration(new OfferBuildingConfiguration());
            builder.ApplyConfiguration(new OrderBuildingConfiguration());

        }
    }



}
