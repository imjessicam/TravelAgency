using DAO.AllDAO;
using DTO.Models.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using TravelAgency.Validators;
using TravelAgency.Validators.Interfaces;

namespace WebAPITravelAgency.Controllers
{
    [ApiController]
    [Route("Customer")]
    public class CustomerController : ControllerBase
    {
        //private readonly CustomerRepository _customerRepository;
        private readonly CustomerDao _customerDao;

        // Validators
        private readonly ICustomerExist _customerExist;
        private readonly INoDuplicates _customerNoDuplicates;
        private readonly ICollectionValidator _collectionValidator;

        public CustomerController(/*CustomerRepository customerRepository,*/ CustomerDao customerDao, ICustomerExist customerExist, INoDuplicates customerNoDuplicates, ICollectionValidator collectionValidator)
        {
            //_customerRepository = customerRepository;
            _customerDao = customerDao;

            // Validators
            _customerExist = customerExist;
            _customerNoDuplicates = customerNoDuplicates;
            _collectionValidator = collectionValidator;

        }

        // Post
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] CreateCustomerModel customer)
        {
            // Check if item already exists
            var noDuplicates = _customerNoDuplicates.IsValid(customer);
            if (!noDuplicates)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable);
            }

            return Ok(_customerDao.Create(customer));
        }

        // Get
        [HttpGet]
        [Route("list")]
        public IActionResult List()
        {
            return Ok(_customerDao.GetAll());
        }

        [HttpGet]
        [Route("find")]
        public IActionResult Find(Guid externalId)
        {
            var foundItem = _customerDao.Find(externalId);

            // Check if item exists
            var isExist = _customerExist.IsExist(externalId);
            if (!isExist)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            return Ok(foundItem);
        }

        [HttpGet]
        [Route("findMany")]
        public IActionResult FindMany([FromQuery] IEnumerable<Guid> externalIds)
        {
            var foundCustomers = _customerDao.FindMany(externalIds);

            // Check collection
            var isAllExist = _collectionValidator.IsValid(externalIds, foundCustomers);
            if (!isAllExist)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable);
            }

            var mappedElements = new List<object>();
            foreach (var customer in foundCustomers)
            {
                mappedElements.Add(customer);
            }
            return Ok(mappedElements);
        }

        [HttpGet]
        [Route("listOfCrewMembersOfCustomer")]
        public IActionResult ListOfCrewMembers(Guid externalId)
        {
            return Ok(_customerDao.GetAllCrewMembers(externalId));
        }

        // Update
        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] UpdateCustomerModel customerToUpdate)
        {
            // Check if item exists
            var isExist = _customerExist.IsExist(customerToUpdate.ExternalId);
            if (!isExist)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            // Check if new item already exists
            var noDuplicates = _customerNoDuplicates.IsValid(customerToUpdate);
            if (!noDuplicates)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable);
            }

            return Ok(_customerDao.Update(customerToUpdate));
        }

        // Delete
        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(Guid externalId)
        {
            // Check if item exists
            var isExist = _customerExist.IsExist(externalId);
            if (!isExist)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            _customerDao.Delete(externalId);
            return Ok();
        }

        [HttpDelete]
        [Route("deleteMany")]
        public IActionResult DeleteMany(List<Guid> externalIds)
        {
            var customersToDelete = _customerDao.FindMany(externalIds);

            // Check collection
            var isAllExist = _collectionValidator.IsValid(externalIds, customersToDelete);
            if (!isAllExist)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable);
            }

            _customerDao.DeleteMany(externalIds);
            return Ok();
        }
    }
}
