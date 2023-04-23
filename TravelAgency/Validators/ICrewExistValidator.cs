using Microsoft.EntityFrameworkCore;
using TravelAgency.Data;
using TravelAgency.Validators.Interfaces;

namespace TravelAgency.Validators
{
    public class ICrewExistValidator : ICrewExist
    {
        private readonly IDbContextFactory<DatabaseContext> _factory;

        // Constructor
        public ICrewExistValidator(IDbContextFactory<DatabaseContext> factory)
        {
            _factory = factory;
        }

        public bool IsExist(Guid externalId)
        {
            using var context = _factory.CreateDbContext();

            var crewMember = context.Cruises.FirstOrDefault(x => x.ExternalId == externalId);

            if (crewMember == null)
            {
                return false;
            }
            return true;
        }
    }
}
