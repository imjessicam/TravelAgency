using AutoMapper;
using DTO.Models.Group_2.Offer;
using TravelAgency.Models.Group_2;
using TravelAgency.Repositories.Group_1;
using TravelAgency.Repositories.Group_2;
using TravelAgency.Validators.Interfaces;

namespace DAO.Group_1
{
    public class OfferDao
    {
        private readonly OfferRepository _offerRepository;
        private readonly CruiseRepository _cruiseRepository;
        private readonly FleetRepository _fleetRepository;
        private readonly SkipperRepository _skipperRepository;
        private readonly IMapper _mapper;
        private readonly IOfferExist _offerExist;

        // Validators
        private readonly ICruiseExist _cruiseExist;
        private readonly IFleetExist _fleetExist;
        private readonly ISkipperExist _skipperExist;
        private readonly INoDuplicates _offerNoDuplicates;

        public OfferDao(OfferRepository offerRepository, CruiseRepository cruiseRepository, FleetRepository fleetRepository, SkipperRepository skipperRepository, IMapper mapper, IOfferExist offerExist, ICruiseExist cruiseExist, IFleetExist fleetExist, ISkipperExist skipperExist, INoDuplicates offerNoDuplicates)
        {
            _offerRepository = offerRepository;
            _cruiseRepository = cruiseRepository;
            _fleetRepository = fleetRepository;
            _skipperRepository = skipperRepository;

            _mapper = mapper;

            // Validators
            _offerExist = offerExist;
            _cruiseExist = cruiseExist;
            _fleetExist = fleetExist;
            _skipperExist = skipperExist;
            _offerNoDuplicates = offerNoDuplicates;            
        }

        // Dekorator

        // Post
        public Guid Create(CreateOfferModel offer)
        {
            // Find Cruise
            var cruise = _cruiseRepository.Find(offer.CruiseExternalId);

            var cruiseIsExist = _cruiseExist.IsExist(offer.CruiseExternalId);
            if (!cruiseIsExist)
            {
                throw new ArgumentOutOfRangeException("Cruise does not exist, please create first or find another customer.", innerException: null);
            }

            // Find Fleet
            var fleet = _fleetRepository.Find(offer.FleetExternalId);

            var fleetIsExist = _fleetExist.IsExist(offer.FleetExternalId);
            if (!fleetIsExist)
            {
                throw new ArgumentOutOfRangeException("Fleet does not exist, please create first or find another customer.", innerException: null);
            }

            // Find Skipper
            var skipper = _skipperRepository.Find(offer.SkipperExternalId);

            var skipperIsExist = _skipperExist.IsExist(offer.SkipperExternalId);
            if (!skipperIsExist)
            {
                throw new ArgumentOutOfRangeException("Skipper does not exist, please create first or find another customer.", innerException: null);
            }

            // Create new Offer
            var newOffer = _mapper.Map<TravelAgency.Models.Group_2.Offer>(offer);
            newOffer.CruiseId = cruise.Id;
            newOffer.FleetId = fleet.Id;
            newOffer.SkipperId = skipper.Id;

            // Check if offer already exists
            var noDuplicates = _offerNoDuplicates.IsValid(offer);
            if (!noDuplicates)
            {
                throw new ArgumentOutOfRangeException("The offer already exists, please enter valid data.", innerException: null);
            }


            return _offerRepository.Create(newOffer);
        }

        // Get

        public OfferDetails Find(Guid offerExternalId)
        {
            var foundOffer = _offerRepository.Find(offerExternalId);

            var offerIsExist = _offerExist.IsExist(offerExternalId);
            if (!offerIsExist)
            {
                throw new ArgumentOutOfRangeException("The offer does not exist, please create.", innerException: null);
            }

            return _mapper.Map<OfferDetails>(foundOffer);
        }

        public IReadOnlyList<OfferDetails> GetAll()
        {
            var offers = _offerRepository.GetAll();

            return _mapper.Map<IReadOnlyList<OfferDetails>>(offers);
        }        

        public OfferAllInfo GetAllInfo (Guid offerExternalId)
        {
            var offer = _offerRepository.GettAllInfo(offerExternalId);

            var offerIsExist = _offerExist.IsExist(offerExternalId);
            if (!offerIsExist)
            {
                throw new ArgumentOutOfRangeException("The offer does not exist.", innerException: null);
            }

            return _mapper.Map<OfferAllInfo>(offer);
        }

        // Put
        public Guid Update(UpdateOfferModel offerToUpdate)
        {
            // Find cruise
            var cruise = _cruiseRepository.Find(offerToUpdate.CruiseExternalId);

            var cruiseIsExist = _cruiseExist.IsExist(offerToUpdate.CruiseExternalId);
            if (!cruiseIsExist)
            {
                throw new ArgumentOutOfRangeException("Cruise does not exist, please create first or find another customer.", innerException: null);
            }

            // Find fleet
            var fleet = _fleetRepository.Find(offerToUpdate.FleetExternalId);

            var fleetIsExist = _fleetExist.IsExist(offerToUpdate.FleetExternalId);
            if (!fleetIsExist)
            {
                throw new ArgumentOutOfRangeException("Fleet does not exist, please create first or find another customer.", innerException: null);
            }

            // Find skipper
            var skipper = _skipperRepository.Find(offerToUpdate.SkipperExternalId);

            var skipperIsExist = _skipperExist.IsExist(offerToUpdate.SkipperExternalId);
            if (!skipperIsExist)
            {
                throw new ArgumentOutOfRangeException("Skipper does not exist, please create first or find another customer.", innerException: null);
            }

            // Mapping
            var offer = _mapper.Map<TravelAgency.Models.Group_2.Offer>(offerToUpdate);
            offer.CruiseId = cruise.Id;
            offer.FleetId = fleet.Id;
            offer.SkipperId = skipper.Id;

            return _offerRepository.Update(offer);
        }

        // Delete

        public void Delete(Guid offerExternalId)
        {
            var offerToDelete = _offerRepository.Find(offerExternalId);

            // Check if offer exists
            var isExist = _offerExist.IsExist(offerExternalId);
            if (!isExist)
            {
                throw new ArgumentOutOfRangeException("The offer you want to remove does not exist.", innerException: null);
            }

            _offerRepository.Delete(offerToDelete.ExternalId);
        }

    }
}
