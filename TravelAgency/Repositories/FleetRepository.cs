using Microsoft.EntityFrameworkCore;
using TravelAgency.Data;
using TravelAgency.Models;

namespace TravelAgency.Repositories
{
    public class FleetRepository
    {
        // Create connection with DB
        private readonly IDbContextFactory<DatabaseContext> _factory;

        // Create constructor
        public FleetRepository(IDbContextFactory<DatabaseContext> factory)
        {
            _factory = factory;
        }


        // Post
        public Guid Create(Fleet fleet)
        {
            using var context = _factory.CreateDbContext();

            var externalId = Guid.NewGuid();
            fleet.ExternalId = externalId;
            context.Fleets.Add(fleet);

            context.SaveChanges();

            return externalId;
        }

        // Get
        public Fleet Find(Guid externalId)
        {
            using var context = _factory.CreateDbContext();

            var database = context.Fleets;
            var foundItem = database.FirstOrDefault(x => x.ExternalId == externalId);

            return foundItem;
        }

        // Get | List of all fleet
        public IReadOnlyList<Fleet> GetAll()
        {
            using var context = _factory.CreateDbContext();

            var fleetList = context.Fleets.ToList();

            return fleetList;
        }

        // Put
        public Guid Update(Fleet fleet)
        {
            using var context = _factory.CreateDbContext();

            // find item
            var currentFleet = Find(fleet.ExternalId);

            // new data
            currentFleet.Type = fleet.Type;
            currentFleet.Name = fleet.Name;

            // update and save changes
            context.Update(currentFleet);
            context.SaveChanges();

            return currentFleet.ExternalId;
        }

        // Delete
        public void Delete(Guid externalId)
        {
            using var context = _factory.CreateDbContext();

            // find item
            var itemToDelete = Find(externalId);

            // remove item and save changes
            context.Remove(itemToDelete);
            context.SaveChanges();
        }
    }
}
