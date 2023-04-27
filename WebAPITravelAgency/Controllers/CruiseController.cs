using DAO.Group_1;
using DTO.Models.Group_1.Cruise;
using DTO.Models.Group_1.Fleet;
using Microsoft.AspNetCore.Mvc;

namespace WebAPITravelAgency.Controllers
{
    [ApiController]
    [Route("Cruise")]

    public class CruiseController : ControllerBase
    {
        private readonly CruiseDao _cruiseDao;

        // Controller
        public CruiseController(CruiseDao cruiseDao)
        {
            _cruiseDao = cruiseDao;
        }

        // Post
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] CreateCruiseModel cruise)
        {
            return Ok(_cruiseDao.Create(cruise));
        }

        // Get
        [HttpGet]
        [Route("list")]
        public IActionResult List()
        {
            return Ok(_cruiseDao.GetAll());
        }

        [HttpGet]
        [Route("find")]
        public IActionResult Find(Guid externalId)
        {
            var foundItem = _cruiseDao.Find(externalId);

            return Ok(foundItem);
        }

        // Put
        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] UpdateCruiseModel cruiseToUpdate)
        {
            return Ok(_cruiseDao.Update(cruiseToUpdate));
        }

        // Delete
        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(Guid externalId)
        {
            _cruiseDao.Delete(externalId);
            return Ok();
        }
    }
}
