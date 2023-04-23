using DTO.Models.Group_1.Cruise;
using DTO.Models.Group_1.Customer;
using DTO.Models.Group_1.Fleet;
using DTO.Models.Group_1.Skipper;
using DTO.Models.Group_2.Crew;
using DTO.Models.Group_2.OfferCustomer;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Data;
using TravelAgency.Models.Group_1;
using TravelAgency.Validators.Interfaces;

namespace TravelAgency.Validators
{
    public class NoDuplicatesValidator : INoDuplicates
    {
        private readonly IDbContextFactory<DatabaseContext> _factory;

        public NoDuplicatesValidator(IDbContextFactory<DatabaseContext> factory)
        {
            _factory = factory;
        }    
        
        // Customer
        public bool IsValid(CreateCustomerModel customer)
        {
            using var context = _factory.CreateDbContext();

            var lastName = context.Customers.FirstOrDefault(x => x.LastName == customer.LastName);
            var firstName = context.Customers.FirstOrDefault(x => x.FirstName == customer.FirstName);
            var email = context.Customers.FirstOrDefault(x => x.Email == customer.Email);
            var phone = context.Customers.FirstOrDefault(x => x.Phone == customer.Phone);

            if (lastName != null && firstName != null || email != null || phone != null)
            {
                return false;
            }
            return true;
        }

        public bool IsValid(UpdateCustomerModel customer)
        {
            using var context = _factory.CreateDbContext();

            var lastName = context.Customers.FirstOrDefault(x => x.LastName == customer.LastName);
            var firstName = context.Customers.FirstOrDefault(x => x.FirstName == customer.FirstName);
            var email = context.Customers.FirstOrDefault(x => x.Email == customer.Email);
            var phone = context.Customers.FirstOrDefault(x => x.Phone == customer.Phone);

            if (lastName != null && firstName != null || email != null || phone != null)
            {
                return false;
            }
            return true;
        }

        // Fleet
        public bool IsValid(CreateFleetModel fleet)
        {
            using var context = _factory.CreateDbContext();

            var type = context.Fleets.FirstOrDefault(x => x.Type == fleet.Type);
            var name = context.Fleets.FirstOrDefault(x => x.Name == fleet.Name);
            
            if(type != null && name != null || name != null)
            {
                return false;
            }
            return true;
        }

        public bool IsValid(UpdateFleetModel fleet)
        {
            using var context = _factory.CreateDbContext();

            var type = context.Fleets.FirstOrDefault(x => x.Type == fleet.Type);
            var name = context.Fleets.FirstOrDefault(x => x.Name == fleet.Name);

            if (type != null && name != null || name != null)
            {
                return false;
            }
            return true;
        }

        // Skipper
        public bool IsValid(CreateSkipperModel skipper)
        {
            using var context = _factory.CreateDbContext();

            var lastName = context.Skippers.FirstOrDefault(x => x.LastName == skipper.LastName);
            var firstName = context.Skippers.FirstOrDefault(x => x.FirstName == skipper.FirstName);
            var email = context.Skippers.FirstOrDefault(x => x.Email == skipper.Email);
            var phone = context.Skippers.FirstOrDefault(x => x.Phone == skipper.Phone);            

            if (lastName != null && firstName != null || email != null || phone != null)
            {
                return false;
            }
            return true;
        }

        public bool IsValid(UpdateSkipperModel skipper)
        {
            using var context = _factory.CreateDbContext();

            var lastName = context.Skippers.FirstOrDefault(x => x.LastName == skipper.LastName);
            var firstName = context.Skippers.FirstOrDefault(x => x.FirstName == skipper.FirstName);
            var email = context.Skippers.FirstOrDefault(x => x.Email == skipper.Email);
            var phone = context.Skippers.FirstOrDefault(x => x.Phone == skipper.Phone);

            if (lastName != null && firstName != null || email != null || phone != null)
            {
                return false;
            }
            return true;
        }

        // Cruise
        public bool IsValid(CreateCruiseModel cruise)
        {
            using var context = _factory.CreateDbContext();

            var title = context.Cruises.FirstOrDefault(x => x.Title == cruise.Title);

            if(title != null)
            {
                return false;
            }
            return true;
        }

        public bool IsValid(UpdateCruiseModel cruise)
        {
            using var context = _factory.CreateDbContext();

            var title = context.Cruises.FirstOrDefault(x => x.Title == cruise.Title);

            if (title != null)
            {
                return false;
            }
            return true;
        }

        // Crew
        public bool IsValid(CreateCrewModel crewMember)
        {
            using var context = _factory.CreateDbContext();

            var lastName = context.Crews.FirstOrDefault(x => x.LastName == crewMember.LastName);
            var firstName = context.Crews.FirstOrDefault(x => x.FirstName == crewMember.FirstName);

            if (lastName != null && firstName != null)
            {
                return false;
            }
            return true;
        }

        public bool IsValid(UpdateCrewModel crewMember)
        {
            using var context = _factory.CreateDbContext();

            var lastName = context.Crews.FirstOrDefault(x => x.LastName == crewMember.LastName);
            var firstName = context.Crews.FirstOrDefault(x => x.FirstName == crewMember.FirstName);

            if (lastName != null && firstName != null)
            {
                return false;
            }
            return true;
        }

        // Order
        public bool IsValid(CreateOrderModel order)
        {
            using var context = _factory.CreateDbContext();

            // OfferId
            var foundOffer = context.Offers.FirstOrDefault(x => x.ExternalId == order.OfferExternalId);
            var offerId = context.Orders.FirstOrDefault(x => x.OfferId == foundOffer.Id);

            // CustomerId
            var foundCustomer = context.Customers.FirstOrDefault(x => x.ExternalId == order.CustomerExternalId);
            var customerId = context.Orders.FirstOrDefault(x => x.CustomerId == foundCustomer.Id);

            if (offerId != null && customerId != null)
            {
                return false;
            }
            return true;
        }

        public bool IsValid(UpdateOrderModel order)
        {
            using var context = _factory.CreateDbContext();

            // OfferId
            var foundOffer = context.Offers.FirstOrDefault(x => x.ExternalId == order.OfferExternalId);
            var offerId = context.Orders.FirstOrDefault(x => x.OfferId == foundOffer.Id);

            // CustomerId
            var foundCustomer = context.Customers.FirstOrDefault(x => x.ExternalId == order.CustomerExternalId);
            var customerId = context.Orders.FirstOrDefault(x => x.CustomerId == foundCustomer.Id);

            if (offerId != null && customerId != null)
            {
                return false;
            }
            return true;
        }
    }
}
