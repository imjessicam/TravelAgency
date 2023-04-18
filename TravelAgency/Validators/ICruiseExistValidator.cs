using Microsoft.EntityFrameworkCore;
using TravelAgency.Data;
using TravelAgency.Validators.Interfaces;

namespace TravelAgency.Validators
{
    public class ICruiseExistValidator : ICruiseExist
    {
        private readonly IDbContextFactory<DatabaseContext> _factory;

        // Constructor
        public ICruiseExistValidator(IDbContextFactory<DatabaseContext> factory)
        {
            _factory = factory;
        }

        public bool IsExist(Guid externalId)
        {
            using var context = _factory.CreateDbContext();

            var cruise = context.Cruises.FirstOrDefault(x => x.ExternalId == externalId);

            if (cruise == null)
            {
                return false;
            }
            return true;
        }
    }
}
