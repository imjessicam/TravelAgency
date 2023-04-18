using AutoMapper;
using DTO.Models.Group_1.Fleet;
using DTO.Models.Group_2.Crew;
using TravelAgency.Repositories.Group_1;
using TravelAgency.Repositories.Group_2;
using TravelAgency.Validators.Interfaces;

namespace DAO.Group_1
{
    public class CrewDao
    {
        private readonly CrewRepository _crewRepository;
        private readonly IMapper _mapper;
        private readonly CustomerRepository _customerRepository;

        // Constructor
        public CrewDao(CrewRepository crewRepository, IMapper mapper, CustomerRepository customerRepository)
        {
            _crewRepository = crewRepository;
            _mapper = mapper;

            _customerRepository = customerRepository;
        }

        // List of all members

        public IReadOnlyList<CrewDetails> GetAll()
        {
            var crewMembers = _crewRepository.GetAll();

            return _mapper.Map<IReadOnlyList<CrewDetails>>(crewMembers);
        }
        

        // Post
        public Guid Create(CreateCrewModel crewMember)
        {
            var customer = _customerRepository.Find(crewMember.CustomerExternalId);

            var newCrewMember = _mapper.Map<TravelAgency.Models.Group_2.Crew>(crewMember);
            newCrewMember.CustomerId = customer.Id;

            return _crewRepository.Create(newCrewMember);
        }

        // Get
        public CrewDetails Find(Guid externalId)
        {
            var foundCustomer = _crewRepository.GetCustomer(externalId);

            var foundCrewMmeber = _crewRepository.Find(externalId);
            foundCrewMmeber.CustomerId = foundCustomer.Id;

            return _mapper.Map<CrewDetails>(foundCrewMmeber);
        }

        // Put
        public Guid Update(UpdateCrewModel crewToUpdate)
        {
            // Mapping
            var crewMember = _mapper.Map<TravelAgency.Models.Group_2.Crew>(crewToUpdate);

            //// Check if item exists
            //var isExist = _fleetExist.IsExist(fleetToUpdate.ExternalId);
            //if (!isExist)
            //{
            //    throw new ArgumentOutOfRangeException("The entity does not exist, please create.", innerException: null);
            //}

            return _crewRepository.Update(crewMember);
        }

        // Delete
        public void Delete(Guid externalId)
        {
            // Find item
            var crewToDelete = _crewRepository.Find(externalId);

            //// Check if item exists
            //var isExist = _fleetExist.IsExist(externalId);
            //if (!isExist)
            //{
            //    throw new ArgumentOutOfRangeException("The customer you want to remove does not exist.", innerException: null);
            //}

            _crewRepository.Delete(crewToDelete.ExternalId);
        }
    }
}
