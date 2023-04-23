using DAO.Group_1;
using DTO.Models.Group_2.OfferCustomer;
using DTO.Models.Group_2.Order;
using Microsoft.AspNetCore.Mvc;

namespace WebAPITravelAgency.Controllers.Group_2
{
    [ApiController]
    [Route("Order")]
    public class OrderController : ControllerBase
    {
        private readonly OrderDao _orderDao;

        public OrderController(OrderDao orderDao)
        {
            _orderDao = orderDao;
        }

        //


        // Post

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromQuery] CreateOrderModel order)
        {
            return Ok(_orderDao.Create(order));
        }

        // Get
        [HttpGet]
        [Route("list")]
        public IActionResult List()
        {
            return Ok(_orderDao.GetAll());
        }

        [HttpGet]
        [Route("find")]
        public IActionResult Find(Guid orderExternalId)
        {
            var foundItem = _orderDao.Find(orderExternalId);
            return Ok(foundItem);
        }

        [HttpGet]
        [Route("getAllInfo")]
        public IActionResult GetAllInfo(Guid orderExternalId)
        {
            var foundItem = _orderDao.GetAllInfo(orderExternalId);
            return Ok(foundItem);
        }

        // Put
        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] UpdateOrderModel orderToUpdate)
        {
            return Ok(_orderDao.Update(orderToUpdate));
        }

        //// Delete
        //[HttpDelete]
        //[Route("delete")]
        //public IActionResult Delete(Guid orderExternalId)
        //{
        //    _orderDao.Delete(orderExternalId);
        //    return Ok();
        //}
    }
}
