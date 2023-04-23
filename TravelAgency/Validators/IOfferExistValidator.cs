using Microsoft.EntityFrameworkCore;
using TravelAgency.Data;
using TravelAgency.Validators.Interfaces;

namespace TravelAgency.Validators
{
    public class IOfferExistValidator : IOfferExist
    {
        private readonly IDbContextFactory<DatabaseContext> _factory;

        // Constructor
        public IOfferExistValidator(IDbContextFactory<DatabaseContext> factory)
        {
            _factory = factory;
        }

        public bool IsExist(Guid externalId)
        {
            using var context = _factory.CreateDbContext();

            var order = context.Offers.FirstOrDefault(o => o.ExternalId == externalId);

            if (order == null)
            {
                return false;
            }
            return true;
        }
    }
}
