using DAO.Group_1;
using DTO.Models.Group_2.Offer;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.Repositories.Group_2;

namespace WebAPITravelAgency.Controllers.Group_2
{
    [ApiController]
    [Route("Offer")]

    public class OfferController : ControllerBase
    {
        private readonly OfferRepository _offerRepository;
        private readonly OfferDao _offerDao;

        public OfferController(OfferRepository offerRepository, OfferDao offerDao)
        {
            //_offerRepository = offerRepository;
            _offerDao = offerDao;
        }

        // Post
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromQuery] CreateOfferModel offer)
        {
            return Ok(_offerDao.Create(offer));

        }

        // Get
        [HttpGet]
        [Route("list")]
        public IActionResult List()
        {
            return Ok(_offerDao.GetAll());
        }

        [HttpGet]
        [Route("find")]
        public IActionResult Find(Guid externalId)
        {
            var foundItem = _offerDao.Find(externalId);
            return Ok(foundItem);
        }

        [HttpGet]
        [Route("getAllInfo")]
        public IActionResult GetAllInfo(Guid offerExternalId)
        {
            var foundOffer = _offerRepository.GettAllInfo(offerExternalId);

            return Ok(foundOffer);
        }

        // Put
        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] UpdateOfferModel offerToUpdate)
        {
            return Ok(_offerDao.Update(offerToUpdate));
        }

        // Delete
        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(Guid externalId)
        {
            _offerDao.Delete(externalId);
            return Ok();
        }

    }
}
