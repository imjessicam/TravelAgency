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
using TravelAgency.Validators.Interfaces;

namespace DAO.Group_1
{
    public class OrderDao
    {
        private readonly OrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly CustomerRepository _customerRepository;
        private readonly OfferRepository _offerRepository;

        // Validators
        private readonly IOrderExist _orderExist;
        private readonly ICustomerExist _customerExist;
        private readonly IOfferExist _offerExist;
        private readonly INoDuplicates _orderNoDuplicates;

        public OrderDao(OrderRepository orderRepository, IMapper mapper, CustomerRepository customerRepository, OfferRepository offerRepository, IOrderExist orderExist, ICustomerExist customerExist, IOfferExist offerExist, INoDuplicates orderNoDuplicates)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;

            _customerRepository = customerRepository;
            _offerRepository = offerRepository;

            // Validators
            _orderExist = orderExist;
            _customerExist = customerExist;
            _offerExist = offerExist;
            _orderNoDuplicates = orderNoDuplicates;
        }

        // Post
        public Guid Create(CreateOrderModel order)
        {
            // Find Customer
            var customer = _customerRepository.Find(order.CustomerExternalId);

            // Check if customer exists
            var customerIsExist = _customerExist.IsExist(order.CustomerExternalId);
            if (!customerIsExist)
            {
                throw new ArgumentOutOfRangeException("Customer does not exist, please create or find another customer.", innerException: null);
            }

            // Find Offer
            var offer = _offerRepository.Find(order.OfferExternalId);

            // Check if offer exists
            var offerIsExist = _offerExist.IsExist(order.OfferExternalId);
            if (!offerIsExist)
            {
                throw new ArgumentOutOfRangeException("Offer does not exist, please create or find another customer.", innerException: null);
            }

            // Create new order
            var newOrder = _mapper.Map<TravelAgency.Models.Group_2.Order>(order);
            newOrder.OfferId = offer.Id;
            newOrder.CustomerId = customer.Id;

            // Check if order already exists
            var noDuplicates = _orderNoDuplicates.IsValid(order);
            if (!noDuplicates)
            {
                throw new ArgumentOutOfRangeException("The order already exists, please enter valid data.", innerException: null);
            }

            return _orderRepository.Create(newOrder);
        }

        // Get
        public OrderDetails Find(Guid orderExternalId)
        {
            var foundOrder = _orderRepository.Find(orderExternalId);

            // Check if order exists
            var isExist = _orderExist.IsExist(orderExternalId);
            if (!isExist)
            {
                throw new ArgumentOutOfRangeException("The order does not exist, please create.", innerException: null);
            }

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

            // Check if order exists
            var isExist = (_orderExist.IsExist(orderExternalId));
            if (!isExist)
            {
                throw new ArgumentOutOfRangeException("Order does not exist.", innerException: null);
            }

            return _mapper.Map<OrderAllInfo>(order);
        }

        // Put

        public Guid Update(UpdateOrderModel orderToUpdate)
        {
            // Find new customer
            var customer = _customerRepository.Find(orderToUpdate.CustomerExternalId);

            // Check if customer exists
            var customerIsExist = _customerExist.IsExist(orderToUpdate.CustomerExternalId);
            if (!customerIsExist)
            {
                throw new ArgumentOutOfRangeException("Customer does not exist, please create first or find another customer.", innerException: null);
            }

            // Find new offer
            var offer = _offerRepository.Find(orderToUpdate.OfferExternalId);

            // Check if offer exists
            var offerIsExist = _offerExist.IsExist(orderToUpdate.OfferExternalId);
            if (!offerIsExist)
            {
                throw new ArgumentOutOfRangeException("Offer does not exist, please create first or find another customer.", innerException: null);
            }

            // Find order to update
            var order = _mapper.Map<TravelAgency.Models.Group_2.Order>(orderToUpdate);
            order.CustomerId = customer.Id;
            order.OfferId = offer.Id;
                
            return _orderRepository.Update(order);

        }

        // Delete

        public void Delete(Guid orderExternalId)
        {
            // Find order to delete
            var orderToDelete = _orderRepository.Find(orderExternalId);

            // Check if order exists
            var isExist = _orderExist.IsExist(orderExternalId);
            if (!isExist)
            {
                throw new ArgumentOutOfRangeException("The order you want to remove does not exist.", innerException: null);
            }

            // Delete order
            _orderRepository.Delete(orderToDelete.ExternalId);
        }
    }
}
