using DAO.Group_1;
using DTO.Models.Group_1.Fleet;
using Microsoft.AspNetCore.Mvc;

namespace WebAPITravelAgency.Controllers
{
    [ApiController]
    [Route("Fleet")]
    public class FleetController : ControllerBase
    {
        private readonly FleetDao _fleetDao;

        public FleetController(FleetDao fleetDao)
        {
            _fleetDao = fleetDao;
        }

        // Post
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] CreateFleetModel fleet)
        {
            return Ok(_fleetDao.Create(fleet));
        }

        // Get
        [HttpGet]
        [Route("list")]
        public IActionResult List()
        {
            return Ok(_fleetDao.GetAll());
        }

        [HttpGet]
        [Route("find")]
        public IActionResult Find(Guid externalId)
        {
            var foundItem = _fleetDao.Find(externalId);

            return Ok(foundItem);
        }

        // Put
        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] UpdateFleetModel fleetToUpdate)
        {
            return Ok(_fleetDao.Update(fleetToUpdate));
        }

        // Delete
        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(Guid externalId)
        {
            _fleetDao.Delete(externalId);
            return Ok();
        }
    }


}
