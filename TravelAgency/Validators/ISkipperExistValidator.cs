using Microsoft.EntityFrameworkCore;
using TravelAgency.Data;
using TravelAgency.Validators.Interfaces;

namespace TravelAgency.Validators
{
    public class ISkipperExistValidator : ISkipperExist
    {
        private readonly IDbContextFactory<DatabaseContext> _factory;

        // Constructor
        public ISkipperExistValidator(IDbContextFactory<DatabaseContext> factory)
        {
            _factory = factory;
        }

        public bool IsExist(Guid externalId)
        {
            using var context = _factory.CreateDbContext();

            var fleet = context.Skippers.FirstOrDefault(x => x.ExternalId == externalId);

            if (fleet == null)
            {
                return false;
            }
            return true;
        }
    }
}
