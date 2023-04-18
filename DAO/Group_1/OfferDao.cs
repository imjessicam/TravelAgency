﻿using AutoMapper;
using DTO.Models.Group_2.Offer;
using TravelAgency.Repositories.Group_1;
using TravelAgency.Repositories.Group_2;

namespace DAO.Group_1
{
    public class OfferDao
    {
        private readonly OfferRepository _offerRepository;
        private readonly CruiseRepository _cruiseRepository;
        private readonly FleetRepository _fleetRepository;
        private readonly SkipperRepository _skipperRepository;
        private readonly IMapper _mapper;

        public OfferDao(OfferRepository offerRepository, CruiseRepository cruiseRepository, FleetRepository fleetRepository, SkipperRepository skipperRepository, IMapper mapper)
        {
            _offerRepository = offerRepository;
            _cruiseRepository = cruiseRepository;
            _fleetRepository = fleetRepository;
            _skipperRepository = skipperRepository;

            _mapper = mapper;
        }

        // Dekorator

        // Post
        public Guid Create(CreateOfferModel offer)
        {
            // Find Cruise
            var cruise = _cruiseRepository.Find(offer.CruiseExternalId);

            // Find Fleet
            var fleet = _fleetRepository.Find(offer.FleetExternalId);

            // Find Skipper
            var skipper = _skipperRepository.Find(offer.SkipperExternalId);

            // Create new Offer
            var newOffer = _mapper.Map<TravelAgency.Models.Group_2.Offer>(offer);

            // Chose Ids of Cruise / Fleet / Skipper
            newOffer.CruiseId = cruise.Id;
            newOffer.FleetId = fleet.Id;
            newOffer.SkipperId = skipper.Id;

            return _offerRepository.Create(newOffer);
        }

        // Get

        public OfferDetails Find(Guid offerExternalId)
        {
            var foundCruise = _offerRepository.GetCruise(offerExternalId);
            var foundFleet = _offerRepository.GetFleet(offerExternalId);
            var foundSkipper = _offerRepository.GetSkipper(offerExternalId);

            var foundOffer = _offerRepository.Find(offerExternalId);
            foundOffer.CruiseId = foundCruise.Id;
            foundOffer.FleetId = foundFleet.Id;
            foundOffer.SkipperId = foundSkipper.Id;

            return _mapper.Map<OfferDetails>(foundOffer);
        }

        public IReadOnlyList<OfferDetails> GetAll()
        {
            var offers = _offerRepository.GetAll();

            return _mapper.Map<IReadOnlyList<OfferDetails>>(offers);
        }

        

        // Put
        public Guid Update(UpdateOfferModel offerToUpdate)
        {
            // Mapping
            var offer = _mapper.Map<TravelAgency.Models.Group_2.Offer>(offerToUpdate);

            return _offerRepository.Update(offer);
        }

        // Delete

        public void Delete(Guid offerExternalId)
        {
            var offerToDelete = _offerRepository.Find(offerExternalId);

            _offerRepository.Delete(offerToDelete.ExternalId);
        }

    }
}