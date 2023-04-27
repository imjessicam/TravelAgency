using AutoMapper;
using DTO.Models.Group_2.Crew;
using TravelAgency.Models;
using TravelAgency.Repositories;
using TravelAgency.Validators.Interfaces;

namespace DAO.Group_1
{
    public class CrewDao
    {
        private readonly CrewRepository _crewRepository;
        private readonly IMapper _mapper;
        private readonly CustomerRepository _customerRepository;

        // Validators
        private readonly INoDuplicates _crewNoDuplicates;
        private readonly ICustomerExist _customerExist;
        private readonly ICrewExist _crewExist;


        // Constructor
        public CrewDao(CrewRepository crewRepository, IMapper mapper, CustomerRepository customerRepository, INoDuplicates crewNoDuplicates, ICrewExist crewExist, ICustomerExist customerExist)
        {
            _crewRepository = crewRepository;
            _mapper = mapper;

            _customerRepository = customerRepository;

            // Validators
            _crewExist = crewExist;
            _crewNoDuplicates = crewNoDuplicates;
            _customerExist = customerExist;
        }      
        
        // Post
        public Guid Create(CreateCrewModel crewMember)
        {
            // Find customer for CustomerId
            var newCustomer = _customerRepository.Find(crewMember.CustomerExternalId);

            // Check if customer exists
            var customerIsExist = _customerExist.IsExist(newCustomer.ExternalId);
            if (!customerIsExist)
            {
                throw new ArgumentOutOfRangeException("Customer does not exist, please create or find another customer.", innerException: null);
            }

            // Mapping - create crewMember
            var newCrewMember = _mapper.Map<Crew>(crewMember);
            newCrewMember.CustomerId = newCustomer.Id;

            // Check if crewMember already exists
            var noDuplicates = _crewNoDuplicates.IsValid(crewMember);
            if (!noDuplicates)
            {
                throw new ArgumentOutOfRangeException("The entity already exists, please enter valid data.", innerException: null);
            }

            return _crewRepository.Create(newCrewMember);
        }

        // Get
        public CrewDetails Find(Guid externalId)
        {
            var foundCrewMemeber = _crewRepository.Find(externalId);

            // Check if item exists
            var isExist = _crewExist.IsExist(externalId);
            if (!isExist)
            {
                throw new ArgumentOutOfRangeException("The entity does not exist, please create.", innerException: null);
            }

            return _mapper.Map<CrewDetails>(foundCrewMemeber);
        }

        public IReadOnlyList<CrewDetails> FindByLastName(CrewFindByLastName crewMember)
        {
            var foundCrewMembers = _crewRepository.FindByLastName(crewMember).ToList();

            // Check if LastName exists
            var isExist = _crewExist.IsExist(crewMember);
            if(!isExist)
            {
                throw new ArgumentOutOfRangeException("The crew member does not exist, please check if Last Name is correct.", innerException: null);
            }

            return _mapper.Map<IReadOnlyList<CrewDetails>>(foundCrewMembers);
        }

        public IReadOnlyList<CrewDetails> GetAll()
        {
            var crewMembers = _crewRepository.GetAll();

            return _mapper.Map<IReadOnlyList<CrewDetails>>(crewMembers);
        }

        // Put
        public Guid Update(UpdateCrewModel crewToUpdate)
        {
            // Check if crewMember exists
            var isExist = _crewExist.IsExist(crewToUpdate.CrewExternalId);
            if (!isExist)
            {
                throw new ArgumentOutOfRangeException("The entity does not exist, please create.", innerException: null);
            }

            // Mapping
            var crewMember = _mapper.Map<Crew>(crewToUpdate);

            // Find new customer
            var customer = _customerRepository.Find(crewToUpdate.CustomerExternalId);

            // Check if customer exists
            var customerIsExist = _customerExist.IsExist(crewToUpdate.CustomerExternalId);
            if (!customerIsExist)
            {
                throw new ArgumentOutOfRangeException("Customer does not exist, please create first or find another customer.", innerException: null);
            }

            // Update customer
            crewMember.CustomerId = customer.Id;            

            return _crewRepository.Update(crewMember);
        }

        // Delete
        public void Delete(Guid externalId)
        {
            // Find item
            var crewToDelete = _crewRepository.Find(externalId);

            // Check if item exists
            var isExist = _crewExist.IsExist(externalId);
            if (!isExist)
            {
                throw new ArgumentOutOfRangeException("The crew you want to remove does not exist.", innerException: null);
            }

            // Delete crew member
            _crewRepository.Delete(crewToDelete.ExternalId);
        }
    }
}
