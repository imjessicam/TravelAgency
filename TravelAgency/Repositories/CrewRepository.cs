using DTO.Models.Group_2.Crew;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Data;
using TravelAgency.Models;
using TravelAgency.Validators.Interfaces;

namespace TravelAgency.Repositories
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

        // Get | Find by surname
        public IReadOnlyList<Crew> FindByLastName(CrewFindByLastName crewMember)
        {
            using var context = _factory.CreateDbContext();

            var foundCrewMembers = context.Crews.Where(x => x.LastName.Contains(crewMember.LastName)).ToList();

            return foundCrewMembers;
        }

        // Get | List of all crew members

        public IReadOnlyList<Crew> GetAll()
        {
            using var context = _factory.CreateDbContext();

            var crewList = context.Crews.ToList();

            return crewList;
        }

        // Get | List of all crew members by customer
        public IReadOnlyList<Crew> GetAllByCustomer(Guid customerExternalId)
        {
            using var context = _factory.CreateDbContext();

            var crewList = context.Customers.Include(x => x.Crews).FirstOrDefault(x => x.ExternalId == customerExternalId);

            return crewList.Crews.ToList();
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


        // GET FROM ANOTHER TABLE

        // Get Customer

        public Customer GetCustomer(Guid crewMemberExternalId)
        {
            using var context = _factory.CreateDbContext();

            var crew = context
                .Crews
                .Include(x => x.Customer)
                .FirstOrDefault(x => x.ExternalId == crewMemberExternalId);

            var customer = crew.Customer;

            return customer;
        }


    }
}
