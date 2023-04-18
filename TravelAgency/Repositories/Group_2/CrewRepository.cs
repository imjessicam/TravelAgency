using Microsoft.EntityFrameworkCore;
using TravelAgency.Data;
using TravelAgency.Models.Group_1;
using TravelAgency.Models.Group_2;
using TravelAgency.Repositories.Group_1;
using TravelAgency.Validators.Interfaces;

namespace TravelAgency.Repositories.Group_2
{
    public class CrewRepository
    {
        // Create connection with DB
        private readonly IDbContextFactory<DatabaseContext> _factory;

        // Additional Repositories
        private readonly CustomerRepository _customerRepository;

        // Validators
        private readonly ICustomerExist _customerExist;
        private readonly INoDuplicates _noDuplicates;

        // Create constructor
        public CrewRepository(IDbContextFactory<DatabaseContext> factory, CustomerRepository customerRepository, ICustomerExist customerExist, INoDuplicates noDuplicates)
        {
            _factory = factory;
            _customerRepository = customerRepository;

            // Validators
            _customerExist = customerExist;
            _noDuplicates = noDuplicates;
        }

        // List of all crew members

        public IReadOnlyList<Crew> GetAll()
        {
            using var context = _factory.CreateDbContext();

            var crewList = context.Crews.ToList();

            return crewList;
        }

        // Post

        public Guid Create(Crew crewMember)
        {
            using var context = _factory.CreateDbContext();

            var externalId = Guid.NewGuid();
            crewMember.ExternalId = externalId;
            context.Crews.Add(crewMember);

            context.SaveChanges();

            return externalId;
        }

        // Get
        public Crew Find(Guid externalId)
        {
            using var context = _factory.CreateDbContext();

            var foundCrewMember = context.Crews.FirstOrDefault(crew => crew.ExternalId == externalId);

            return foundCrewMember;
        }

        // Put
        public Guid Update(Crew crewMember)
        {
            using var context = _factory.CreateDbContext();

            var currentCrewMember = Find(crewMember.ExternalId);

            // new data
            currentCrewMember.CustomerId = crewMember.CustomerId;
            currentCrewMember.LastName = crewMember.LastName;
            currentCrewMember.FirstName = crewMember.FirstName;

            context.Update(currentCrewMember);
            context.SaveChanges();

            return currentCrewMember.ExternalId;

        }

        // Delete
        public void Delete(Guid externalID)
        {
            using var context = _factory.CreateDbContext();

            var itemToDelete = Find(externalID);
            context.Crews.Remove(itemToDelete);
            context.SaveChanges();
        }

        


        // Get Customer

        public Customer GetCustomer(Guid crewMemberExternalId)
        {
            using var context = _factory.CreateDbContext();

            var crew = context
                .Crews
                .Include(x => x.Customer)
                .FirstOrDefault(x => x.ExternalId == crewMemberExternalId);

            return crew.Customer;
        }


    }
}
