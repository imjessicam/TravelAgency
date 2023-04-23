using DTO.Models.Group_2.Offer;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Data;
using TravelAgency.Models.Group_1;
using TravelAgency.Models.Group_2;

namespace TravelAgency.Repositories.Group_2
{
    public class OfferRepository
    {
        private readonly IDbContextFactory<DatabaseContext> _factory;

        public OfferRepository(IDbContextFactory<DatabaseContext> factory)
        {
            _factory = factory;
        }

        // Post
        public Guid Create(Offer offer)
        {
            using var context = _factory.CreateDbContext();

            var externalId = Guid.NewGuid();
            offer.ExternalId = externalId;
            context.Offers.Add(offer);

            context.SaveChanges();

            return externalId;
        }

        // Get
        public Offer Find(Guid offerExternalId)
        {
            using var context = _factory.CreateDbContext();

            var foundOffer = context.Offers.FirstOrDefault(o => o.ExternalId == offerExternalId);

            return foundOffer;
        }

        // Get | List of all offers
        public IReadOnlyList<Offer> GetAll()
        {
            using var context = _factory.CreateDbContext();

            var offersList = context.Offers.ToList();

            return offersList;
        }

        // Get | All info
        public Offer GettAllInfo(Guid offerExternalId)
        {
            using var context = _factory.CreateDbContext();

            // find offer
            var offerInfo = context.Offers
                .Include(x => x.Cruise)
                .Include(x => x.Fleet)
                .Include(x => x.Skipper)
                .FirstOrDefault(o => o.ExternalId == offerExternalId);

            return offerInfo;
        }

        // Put
        public Guid Update(Offer offer)
        {
            using var context = _factory.CreateDbContext();

            var currentOffer = Find(offer.ExternalId);

            // new data
            currentOffer.Title = offer.Title;
            currentOffer.Start = offer.Start;
            currentOffer.End = offer.End;
            currentOffer.NumberOfDays = offer.NumberOfDays;
            currentOffer.Price = offer.Price;
            currentOffer.Availability = offer.Availability;
            currentOffer.CruiseId = offer.CruiseId;
            currentOffer.FleetId = offer.FleetId;
            currentOffer.SkipperId = offer.SkipperId;

            context.Update(currentOffer);
            context.SaveChanges();

            return currentOffer.ExternalId;
        }

        // Delete
        public void Delete(Guid offerExternalId)
        {
            using var context = _factory.CreateDbContext();

            var offerToDelete = Find(offerExternalId);
            context.Offers.Remove(offerToDelete);
            context.SaveChanges();
        }

        // GET FROM ANOTHER TABLE        

        public Cruise GetCruise(Guid offerExternalId)
        {
            using var context = _factory.CreateDbContext();

            var offer = context
                .Offers
                .Include(x => x.Cruise)
                .FirstOrDefault(x => x.ExternalId == offerExternalId);

            return offer.Cruise;
        }

        public Fleet GetFleet(Guid offerExternalId)
        {
            using var context = _factory.CreateDbContext();

            var offer = context
                .Offers
                .Include(x => x.Fleet)
                .FirstOrDefault(x => x.ExternalId == offerExternalId);

            return offer.Fleet;
        }

        public Skipper GetSkipper(Guid offerExternalId)
        {
            using var context = _factory.CreateDbContext();

            var offer = context
                .Offers
                .Include(x => x.Skipper)
                .FirstOrDefault(x => x.ExternalId == offerExternalId);

            return offer.Skipper;
        }
    }
}
