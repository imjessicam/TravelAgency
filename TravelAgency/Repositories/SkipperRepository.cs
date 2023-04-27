using Microsoft.EntityFrameworkCore;
using TravelAgency.Data;
using TravelAgency.Models;

namespace TravelAgency.Repositories
{
    public class SkipperRepository
    {
        // Create connection with DB
        private readonly IDbContextFactory<DatabaseContext> _factory;

        // Create constructor
        public SkipperRepository(IDbContextFactory<DatabaseContext> factory)
        {
            _factory = factory;
        }

        // Post
        public Guid Create(Skipper skipper)
        {
            using var context = _factory.CreateDbContext();

            var externalId = Guid.NewGuid();
            skipper.ExternalId = externalId;
            context.Skippers.Add(skipper);

            context.SaveChanges();

            return externalId;
        }

        // Get
        public Skipper Find(Guid externalId)
        {
            using var context = _factory.CreateDbContext();

            var database = context.Skippers;
            var foundItem = database.FirstOrDefault(x => x.ExternalId == externalId);

            return foundItem;
        }

        // Get | List of all skippers
        public IReadOnlyList<Skipper> GetAll()
        {
            using var context = _factory.CreateDbContext();

            var skippersList = context.Skippers.ToList();

            return skippersList;
        }

        // Put
        public Guid Update(Skipper skipper)
        {
            using var context = _factory.CreateDbContext();

            // find item
            var currentItem = Find(skipper.ExternalId);

            // new data
            currentItem.LastName = skipper.LastName;
            currentItem.FirstName = skipper.FirstName;
            currentItem.Email = skipper.Email;
            currentItem.Phone = skipper.Phone;
            currentItem.Info = skipper.Info;

            // update and save changes
            context.Update(currentItem);
            context.SaveChanges();

            return currentItem.ExternalId;
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
