using AutoMapper;
using DTO.Models.Group_1.Customer;
using DTO.Models.Group_1.Fleet;
using TravelAgency.Repositories.Group_1;
using TravelAgency.Validators.Interfaces;

namespace DAO.Group_1
{
    public class FleetDao
    {
        private readonly FleetRepository _fleetRepository;
        private readonly IMapper _mapper;

        // Validators
        private readonly IFleetExist _fleetExist;
        private readonly INoDuplicates _fleetNoDuplicates;

        // Constructor
        public FleetDao(FleetRepository fleetRepository, IMapper mapper, IFleetExist fleetExist, INoDuplicates fleetNoDuplicates)
        {
            _fleetRepository = fleetRepository;
            _mapper = mapper;

            // Validators
            _fleetExist = fleetExist;
            _fleetNoDuplicates = fleetNoDuplicates;
        }

        // Post
        public Guid Create(CreateFleetModel fleet)
        {
            // Mapping
            var newFleet = _mapper.Map<TravelAgency.Models.Group_1.Fleet>(fleet);

            // Check if item already exists
            var noDuplicates = _fleetNoDuplicates.IsValid(fleet);
            if (!noDuplicates)
            {
                throw new ArgumentOutOfRangeException("The entity already exists, please enter valid data.", innerException: null);
            }
            return _fleetRepository.Create(newFleet);
        }

        // Get
        public FleetDetails Find(Guid externalId)
        {
            // Find item                       
            var foundFleet = _fleetRepository.Find(externalId);

            // Check if item exists
            var isExist = _fleetExist.IsExist(externalId);
            if (!isExist)
            {
                throw new ArgumentOutOfRangeException("The entity does not exist, please create.", innerException: null);
            }

            return _mapper.Map<FleetDetails>(foundFleet);
        }

        public IReadOnlyList<FleetDetails> GetAll()
        {
            var fleet = _fleetRepository.GetAll();

            return _mapper.Map<IReadOnlyList<FleetDetails>>(fleet);
        }

        // Put
        public Guid Update(UpdateFleetModel fleetToUpdate)
        {
            // Mapping
            var fleet = _mapper.Map<TravelAgency.Models.Group_1.Fleet>(fleetToUpdate);

            // Check if item exists
            var isExist = _fleetExist.IsExist(fleetToUpdate.ExternalId);
            if (!isExist)
            {
                throw new ArgumentOutOfRangeException("The entity does not exist, please create.", innerException: null);
            }

            return _fleetRepository.Update(fleet);
        }

        // Delete
        public void Delete(Guid externalId)
        {
            // Find item
            var fleetToDelete = _fleetRepository.Find(externalId);

            // Check if item exists
            var isExist = _fleetExist.IsExist(externalId);
            if (!isExist)
            {
                throw new ArgumentOutOfRangeException("The customer you want to remove does not exist.", innerException: null);
            }

            _fleetRepository.Delete(fleetToDelete.ExternalId);
        }

    }
}
