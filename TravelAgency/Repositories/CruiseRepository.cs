using Microsoft.EntityFrameworkCore;
using TravelAgency.Data;
using TravelAgency.Models;

namespace TravelAgency.Repositories
{
    public class CruiseRepository
    {
        // Create connection with DB
        private readonly IDbContextFactory<DatabaseContext> _factory;

        // Create constructor
        public CruiseRepository(IDbContextFactory<DatabaseContext> factory)
        {
            _factory = factory;
        }

        // Post
        public Guid Create(Cruise cruise)
        {
            using var context = _factory.CreateDbContext();

            var externalId = Guid.NewGuid();
            cruise.ExternalId = externalId;
            context.Cruises.Add(cruise);

            context.SaveChanges();

            return externalId;
        }

        // Get
        public Cruise Find(Guid externalId)
        {
            using var context = _factory.CreateDbContext();

            var database = context.Cruises;
            var foundItem = database.FirstOrDefault(x => x.ExternalId == externalId);

            return foundItem;
        }

        // Get | List of all cruisers
        public IReadOnlyList<Cruise> GetAll()
        {
            using var context = _factory.CreateDbContext();

            var cruisesList = context.Cruises.ToList();

            return cruisesList;
        }

        // Put
        public Guid Update(Cruise cruise)
        {
            using var context = _factory.CreateDbContext();

            // find item
            var currentCruise = Find(cruise.ExternalId);

            // new data
            currentCruise.Title = cruise.Title;
            currentCruise.Info = cruise.Info;

            // update and save changes
            context.Update(currentCruise);
            context.SaveChanges();

            return currentCruise.ExternalId;
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
