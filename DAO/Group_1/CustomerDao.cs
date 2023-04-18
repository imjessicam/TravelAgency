using AutoMapper;
using TravelAgency.Repositories.Group_1;
using DTO.Models.Group_1.Customer;
using TravelAgency.Validators.Interfaces;
using DTO.Models.Group_2.Crew;
using TravelAgency.Models.Group_1;

namespace DAO.Group_1
{
    public class CustomerDao
    {
        private readonly CustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        // Validators
        private readonly ICustomerExist _customerExist;
        private readonly INoDuplicates _customerNoDuplicates;
        private readonly ICollectionValidator _collectionValidator;

        // Constructor
        public CustomerDao(CustomerRepository customerRepository, IMapper mapper, ICustomerExist customerExist, INoDuplicates customerNoDuplicates, ICollectionValidator collectionValidator)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;

            // Validators
            _customerExist = customerExist;
            _customerNoDuplicates = customerNoDuplicates;
            _collectionValidator = collectionValidator;
        }

        // Post
        public Guid Create(CreateCustomerModel customer)
        {
            // Mapping
            var newCustomer = _mapper.Map<TravelAgency.Models.Group_1.Customer>(customer);

            // Check if item already exists
            var noDuplicates = _customerNoDuplicates.IsValid(customer);
            if (!noDuplicates)
            {
                throw new ArgumentOutOfRangeException("The customer already exists, please enter valid data.", innerException: null);
            }
            return _customerRepository.Create(newCustomer);
        }

        // Get
        public CustomerDetails Find(Guid externalId)
        {
            // Find item                       
            var foundCustomer = _customerRepository.Find(externalId);

            // Check if item exists
            var isExist = _customerExist.IsExist(externalId);
            if (!isExist)
            {
                throw new ArgumentOutOfRangeException("The customer does not exist, please create.", innerException: null);
            }

            return _mapper.Map<CustomerDetails>(foundCustomer);
        }

        public IEnumerable<CustomerDetails> FindMany(IEnumerable<Guid> externalIds)
        {
            // Find items
            var foundCustomers = _customerRepository.FindMany(externalIds);

            // Check collection
            var isAllExist = _collectionValidator.IsValid(externalIds, foundCustomers);
            if (!isAllExist)
            {
                throw new ArgumentOutOfRangeException("Some customers do not exist.", innerException: null);
            }

            return _mapper.Map<IEnumerable<CustomerDetails>>(foundCustomers);
        }

        public IReadOnlyList<CrewBasicInfo> GetAllCrewMembers(Guid customerExternalId)
        {
            var crewMembers = _customerRepository.GetCrewMembers(customerExternalId).ToList();

            return _mapper.Map<IReadOnlyList<CrewBasicInfo>>(crewMembers);
        }

        public IReadOnlyList<CustomerDetails> GetAll()
        {
            var customers = _customerRepository.GetAll();

            return _mapper.Map<IReadOnlyList<CustomerDetails>>(customers);
        }

        // Put
        public Guid Update(UpdateCustomerModel customerToUpdate)
        {
            // Mapping
            var customer = _mapper.Map<TravelAgency.Models.Group_1.Customer>(customerToUpdate);

            // Check if item exists
            var isExist = _customerExist.IsExist(customerToUpdate.ExternalId);
            if (!isExist)
            {
                throw new ArgumentOutOfRangeException("The customer does not exist, please create.", innerException: null);
            }

            return _customerRepository.Update(customer);
        }

        // Delete
        public void Delete(Guid externalId)
        {
            // Find item
            var customerToDelete = _customerRepository.Find(externalId);

            // Check if item exists
            var isExist = _customerExist.IsExist(externalId);
            if (!isExist)
            {
                throw new ArgumentOutOfRangeException("The customer you want to remove does not exist.", innerException: null);
            }

            _customerRepository.Delete(customerToDelete.ExternalId);
        }

        public void DeleteMany(IEnumerable<Guid> externalIds)
        {
            // Find items
            var customersToDelete = _customerRepository.FindMany(externalIds);

            // Check collection
            var isAllExist = _collectionValidator.IsValid(externalIds, customersToDelete);
            if (!isAllExist)
            {
                throw new ArgumentOutOfRangeException("Some customers you want to remove do not exist.", innerException: null);
            }

            _customerRepository.DeleteMany(externalIds);
        }
    }
}
