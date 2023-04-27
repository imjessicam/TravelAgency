using AutoMapper;
using DTO.Models.Group_1.Cruise;
using TravelAgency.Models;
using TravelAgency.Repositories;
using TravelAgency.Validators.Interfaces;

namespace DAO.Group_1
{
    public class CruiseDao
    {
        private readonly CruiseRepository _cruiseRepository;
        private readonly IMapper _mapper;

        // Validators
        private readonly ICruiseExist _cruiseExist;
        private readonly INoDuplicates _cruiseNoDuplicates;

        // Constructor
        public CruiseDao(CruiseRepository cruiseRepository, IMapper mapper, ICruiseExist cruiseExist, INoDuplicates cruiseNoDuplicates)
        {
            _cruiseRepository = cruiseRepository;
            _mapper = mapper;

            // Validators
            _cruiseExist = cruiseExist;
            _cruiseNoDuplicates = cruiseNoDuplicates;
        }

        // Post
        public Guid Create(CreateCruiseModel cruise)
        {
            // Mapping
            var newCruise = _mapper.Map<Cruise>(cruise);

            // Check if item already exists
            var noDuplicates = _cruiseNoDuplicates.IsValid(cruise);
            if (!noDuplicates)
            {
                throw new ArgumentOutOfRangeException("The entity already exists, please enter valid data.", innerException: null);
            }
            return _cruiseRepository.Create(newCruise);
        }

        // Get
        public CruiseDetails Find(Guid externalId)
        {
            // Find item                       
            var foundCruise = _cruiseRepository.Find(externalId);

            // Check if item exists
            var isExist = _cruiseExist.IsExist(externalId);
            if (!isExist)
            {
                throw new ArgumentOutOfRangeException("The entity does not exist, please create.", innerException: null);
            }

            return _mapper.Map<CruiseDetails>(foundCruise);
        }

        public IReadOnlyList<CruiseDetails> GetAll()
        {
            var cruises = _cruiseRepository.GetAll();

            return _mapper.Map<IReadOnlyList<CruiseDetails>>(cruises);
        }

        // Put
        public Guid Update(UpdateCruiseModel cruiseToUpdate)
        {
            // Mapping
            var cruise = _mapper.Map<Cruise>(cruiseToUpdate);

            // Check if item exists
            var isExist = _cruiseExist.IsExist(cruiseToUpdate.ExternalId);
            if (!isExist)
            {
                throw new ArgumentOutOfRangeException("The entity does not exist, please create.", innerException: null);
            }

            return _cruiseRepository.Update(cruise);
        }

        // Delete
        public void Delete(Guid externalId)
        {
            // Find item
            var cruiseToDelete = _cruiseRepository.Find(externalId);

            // Check if item exists
            var isExist = _cruiseExist.IsExist(externalId);
            if (!isExist)
            {
                throw new ArgumentOutOfRangeException("The customer you want to remove does not exist.", innerException: null);
            }

            _cruiseRepository.Delete(cruiseToDelete.ExternalId);
        }
    }
}
