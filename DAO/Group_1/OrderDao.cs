using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DTO.Models.Group_2.OfferCustomer;
using DTO.Models.Group_2.Order;
using TravelAgency.Models.Group_2;
using TravelAgency.Repositories.Group_1;
using TravelAgency.Repositories.Group_2;

namespace DAO.Group_1
{
    public class OrderDao
    {
        private readonly OrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly CustomerRepository _customerRepository;
        private readonly OfferRepository _offerRepository;

        public OrderDao(OrderRepository orderRepository, IMapper mapper, CustomerRepository customerRepository, OfferRepository offerRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;

            _customerRepository = customerRepository;
            _offerRepository = offerRepository;
        }

        // Post
        public Guid Create(CreateOrderModel order)
        {
            // Find Customer
            var customer = _customerRepository.Find(order.CustomerExternalId);

            // Find Offer
            var offer = _offerRepository.Find(order.OfferExternalId);

            // Create new order
            var newOrder = _mapper.Map<TravelAgency.Models.Group_2.Order>(order);
            newOrder.OfferId = offer.Id;
            newOrder.CustomerId = customer.Id;

            return _orderRepository.Create(newOrder);

        }

        // Get
        public OrderDetails Find(Guid orderExternalId)
        {        
            var foundCustomer = _orderRepository.GetCustomer(orderExternalId);
            var foundOffer = _orderRepository.GetOffer(orderExternalId);

            var foundOrder = _orderRepository.Find(orderExternalId);

            foundOrder.CustomerId = foundCustomer.Id;
            foundOrder.OfferId= foundOffer.Id;

            return _mapper.Map<OrderDetails>(foundOrder);
        }

        public IReadOnlyList<OrderDetails> GetAll()
        {
            var orders = _orderRepository.GetAll();

            return _mapper.Map<IReadOnlyList<OrderDetails>>(orders);
        }

        public OrderAllInfo GetAllInfo (Guid orderExternalId)
        {
            var order = _orderRepository.GetAllInfo(orderExternalId);

            return _mapper.Map<OrderAllInfo>(order);
        }

        // Put

        public Guid Update(UpdateOrderModel orderToUpdate)
        {
            var customer = _customerRepository.Find(orderToUpdate.CustomerExternalId);
            var offer = _offerRepository.Find(orderToUpdate.OfferExternalId);

            var order = _mapper.Map<TravelAgency.Models.Group_2.Order>(orderToUpdate);
            order.CustomerId = customer.Id;
            order.OfferId = offer.Id;
                
            return _orderRepository.Update(order);

        }

        // Delete

        public void Delete(Guid orderExternalId)
        {
            var orderToDelete = _orderRepository.Find(orderExternalId);

            _orderRepository.Delete(orderToDelete.ExternalId);
        }
    }
}
