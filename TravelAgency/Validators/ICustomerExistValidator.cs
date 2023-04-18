using Microsoft.EntityFrameworkCore;
using TravelAgency.Data;
using TravelAgency.Validators.Interfaces;

namespace TravelAgency.Validators
{
    public class ICustomerExistValidator : ICustomerExist
    {
        private readonly IDbContextFactory<DatabaseContext> _factory;

        // Constructor
        public ICustomerExistValidator(IDbContextFactory<DatabaseContext> factory)
        {
            _factory = factory;
        }

        public bool IsExist(Guid externalId)
        {
            using var context = _factory.CreateDbContext();

            var customer = context.Customers.FirstOrDefault(x => x.ExternalId == externalId);
            
            if (customer == null)
            {
                return false;
            }
            return true;
        }

        public bool IsExist(IEnumerable<Guid> externalIds)
        {
            using var context = _factory.CreateDbContext();

            var customer = context.Customers.Where(x => externalIds.Contains(x.ExternalId)).ToList();

            if(customer.Count() == 0)
            {
                return false;
            }
            return true;
        }
        
    }
}
