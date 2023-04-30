using DAO.AllDAO;
using DTO.Models.Fleet;
using DTO.Models.Skipper;
using Microsoft.AspNetCore.Mvc;

namespace WebAPITravelAgency.Controllers
{
    [ApiController]
    [Route("Skipper")]
    public class SkipperController : ControllerBase
    {
        private readonly SkipperDao _skipperDao;

        public SkipperController(SkipperDao skipperDao)
        {
            _skipperDao = skipperDao;
        }

        // Post
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] CreateSkipperModel skipper)
        {
            return Ok(_skipperDao.Create(skipper));
        }

        // Get
        [HttpGet]
        [Route("list")]
        public IActionResult List()
        {
            return Ok(_skipperDao.GetAll());
        }


        [HttpGet]
        [Route("find")]
        public IActionResult Find(Guid externalId)
        {
            var foundItem = _skipperDao.Find(externalId);

            return Ok(foundItem);
        }

        // Put
        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] UpdateSkipperModel skipperToUpdate)
        {
            return Ok(_skipperDao.Update(skipperToUpdate));
        }

        // Delete
        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(Guid externalId)
        {
            _skipperDao.Delete(externalId);
            return Ok();
        }
    }
}
