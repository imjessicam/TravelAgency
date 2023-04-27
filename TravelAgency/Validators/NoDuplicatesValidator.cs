using System;
using DTO.Models.Group_1.Cruise;
using DTO.Models.Group_1.Customer;
using DTO.Models.Group_1.Fleet;
using DTO.Models.Group_1.Skipper;
using DTO.Models.Group_2.Crew;
using DTO.Models.Group_2.Offer;
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

            var customerData = context.Customers
                .Where(c => c.LastName == customer.LastName && c.FirstName == customer.FirstName)
                .SingleOrDefault();

            var email = context.Customers.FirstOrDefault(x => x.Email == customer.Email);
            var phone = context.Customers.FirstOrDefault(x => x.Phone == customer.Phone);

            if (customerData != null || email != null || phone != null)
            {
                return false;
            }
            return true;
        }

        public bool IsValid(UpdateCustomerModel customer)
        {
            using var context = _factory.CreateDbContext();

            var customerData = context.Customers
                .Where(c => c.LastName == customer.LastName && c.FirstName == customer.FirstName)
                .SingleOrDefault();

            var email = context.Customers.FirstOrDefault(x => x.Email == customer.Email);
            var phone = context.Customers.FirstOrDefault(x => x.Phone == customer.Phone);

            if (customerData != null || email != null || phone != null)
            {
                return false;
            }
            return true;
        }

        // Fleet
        public bool IsValid(CreateFleetModel fleet)
        {
            using var context = _factory.CreateDbContext();

            var name = context.Fleets.FirstOrDefault(x => x.Name == fleet.Name);
            
            if(name != null)
            {
                return false;
            }
            return true;
        }

        public bool IsValid(UpdateFleetModel fleet)
        {
            using var context = _factory.CreateDbContext();

            var name = context.Fleets.FirstOrDefault(x => x.Name == fleet.Name);

            if (name != null)
            {
                return false;
            }
            return true;
        }

        // Skipper
        public bool IsValid(CreateSkipperModel skipper)
        {
            using var context = _factory.CreateDbContext();

            var skipperData = context.Skippers
                .Where(s => s.LastName == skipper.LastName && s.FirstName == skipper.FirstName)
                .SingleOrDefault();

            var email = context.Skippers.FirstOrDefault(x => x.Email == skipper.Email);
            var phone = context.Skippers.FirstOrDefault(x => x.Phone == skipper.Phone);            

            if (skipperData != null || email != null || phone != null)
            {
                return false;
            }
            return true;
        }

        public bool IsValid(UpdateSkipperModel skipper)
        {
            using var context = _factory.CreateDbContext();

            var skipperData = context.Skippers
                .Where(s => s.LastName == skipper.LastName && s.FirstName == skipper.FirstName)
                .SingleOrDefault();

            var email = context.Skippers.FirstOrDefault(x => x.Email == skipper.Email);
            var phone = context.Skippers.FirstOrDefault(x => x.Phone == skipper.Phone);

            if (skipperData != null || email != null || phone != null)
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

            var crewMemberData = context.Crews
                .Where(cm => cm.LastName == crewMember.LastName && cm.FirstName == crewMember.FirstName)
                .SingleOrDefault();

            if (crewMemberData != null)
            {
                return false;
            }
            return true;
        }

        public bool IsValid(UpdateCrewModel crewMember)
        {
            using var context = _factory.CreateDbContext();

            var crewMemberData = context.Crews
                .Where(cm => cm.LastName == crewMember.LastName && cm.FirstName == crewMember.FirstName)
                .SingleOrDefault();

            if (crewMemberData != null)
            {
                return false;
            }
            return true;
        }

        // Offer
        public bool IsValid(CreateOfferModel offer)
        {
            using var context = _factory.CreateDbContext();

            // Title
            var offerTitle = context.Offers
                .Where(o => o.Title == offer.Title)
                .SingleOrDefault();

            // Skipper 
            var skipper = context.Skippers.FirstOrDefault(s => s.ExternalId == offer.SkipperExternalId);

            var offerStartEndSkipper = context.Offers
                .Where(o => o.Start == offer.Start && o.End == offer.End && o.SkipperId == skipper.Id)
                .SingleOrDefault();

            // Fleet
            var fleet = context.Fleets.FirstOrDefault(f => f.ExternalId == offer.FleetExternalId);

            var offerStartEndFleet = context.Offers
                .Where(o => o.Start == offer.Start && o.End == offer.End && o.FleetId == fleet.Id)
                .SingleOrDefault();

            if (offerTitle != null || offerStartEndSkipper != null || offerStartEndFleet != null)
            {
                return false;
            }
            return true;
        }

        public bool IsValid(UpdateOfferModel offer)
        {
            using var context = _factory.CreateDbContext();

            // Title
            var offerTitle = context.Offers
                .Where(o => o.Title == offer.Title)
                .SingleOrDefault();

            // Skipper 
            var skipper = context.Skippers.FirstOrDefault(s => s.ExternalId == offer.SkipperExternalId);

            var offerStartEndSkipper = context.Offers
                .Where(o => o.Start == offer.Start && o.End == offer.End && o.SkipperId == skipper.Id)
                .SingleOrDefault();

            // Fleet
            var fleet = context.Fleets.FirstOrDefault(f => f.ExternalId == offer.FleetExternalId);

            var offerStartEndFleet = context.Offers
                .Where(o => o.Start == offer.Start && o.End == offer.End && o.FleetId == fleet.Id)
                .SingleOrDefault();

            if (offerTitle != null || offerStartEndSkipper != null || offerStartEndFleet != null)
            {
                return false;
            }
            return true;
        }

        // Order
        public bool IsValid(CreateOrderModel order)
        {
            using var context = _factory.CreateDbContext();

            // Offer
            var foundOffer = context.Offers.FirstOrDefault(x => x.ExternalId == order.OfferExternalId);
            //var offerId = context.Orders.FirstOrDefault(x => x.OfferId == foundOffer.Id);           

            // Customer
            var foundCustomer = context.Customers.FirstOrDefault(x => x.ExternalId == order.CustomerExternalId);
            //var customerId = context.Orders.FirstOrDefault(x => x.CustomerId == foundCustomer.Id);

            var orderData = context.Orders
                .Where(o => o.OfferId == foundOffer.Id && o.CustomerId == foundCustomer.Id)
                .SingleOrDefault();

            if (orderData != null)
            {
                return false;
            }
            return true;
        }

        public bool IsValid(UpdateOrderModel order)
        {
            using var context = _factory.CreateDbContext();

            // Offer
            var foundOffer = context.Offers.FirstOrDefault(x => x.ExternalId == order.OfferExternalId);

            // Customer
            var foundCustomer = context.Customers.FirstOrDefault(x => x.ExternalId == order.CustomerExternalId);

            var orderData = context.Orders
                .Where(o => o.OfferId == foundOffer.Id && o.CustomerId == foundCustomer.Id)
                .SingleOrDefault();

            if (orderData != null)
            {
                return false;
            }
            return true;
        }
    }
}
