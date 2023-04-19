using Microsoft.EntityFrameworkCore;
using TravelAgency.Data;
using TravelAgency.Models.Group_1;
using TravelAgency.Models.Group_2;

namespace TravelAgency.Repositories.Group_2
{
    public class OrderRepository
    {
        private readonly IDbContextFactory<DatabaseContext> _factory;
        private readonly OfferRepository _offerRepository;

        public OrderRepository(IDbContextFactory<DatabaseContext> factory, OfferRepository offerRepository)
        {
            _factory = factory;
            _offerRepository = offerRepository;
        }

        // List of all orders

        public IReadOnlyList<Order> GetAll()
        {
            using var context = _factory.CreateDbContext();

            var ordersList = context.Orders.ToList();

            return ordersList;
        }

        // Full info about order

        public Order GetAllInfo(Guid orderExternalId)
        {
            using var context = _factory.CreateDbContext();

            var orderInfo = context.Orders.Include(x=> x.Customer).Include(x => x.Offer).ThenInclude(x => x.Fleet).FirstOrDefault(o => o.ExternalId == orderExternalId);

            return orderInfo;
        }

        public Guid Create(Order order)
        {
            using var context = _factory.CreateDbContext();                      

            var externalId = Guid.NewGuid();
            order.ExternalId = externalId;
            
            context.Orders.Add(order);
            context.SaveChanges();

            return externalId;
        }

        public Order Find(Guid orderExternalId)
        {
            using var context = _factory.CreateDbContext();

            return context.Orders.FirstOrDefault(o => o.ExternalId == orderExternalId);
                       
            
        }

        public Guid Update(Order order)
        {
            using var context = _factory.CreateDbContext();

            var currentOrder = Find(order.ExternalId);

            // new data
            currentOrder.CustomerId = order.CustomerId;
            currentOrder.OfferId = order.OfferId;

            context.Update(currentOrder);
            context.SaveChanges();

            return order.ExternalId;
        }

        public void Delete(Guid orderExternalId)
        {
            using var context = _factory.CreateDbContext();

            var orderToDelete = Find(orderExternalId);
            context.Orders.Remove(orderToDelete);
            context.SaveChanges();
        }

        //

        public Customer GetCustomer(Guid orderExternalId)
        {
            using var context = _factory.CreateDbContext();

            var order = context
                .Orders
                .Include(x => x.Customer)
                .FirstOrDefault(x => x.ExternalId == orderExternalId);

            return order.Customer;
        }

        public Offer GetOffer(Guid orderExternalId)
        {
            using var context = _factory.CreateDbContext();

            var order = context
                .Orders
                .Include(x => x.Offer)
                .FirstOrDefault(x => x.ExternalId == orderExternalId);

            return order.Offer;
        }

        public int GetNumberOfCrewMembers(Guid orderExternalId)
        {
            using var context = _factory.CreateDbContext();

            // Firstly find order to count crew members
            var foundOrder = Find(orderExternalId);

            // Count crew members from choosen customer
            var numberOfCrewMembers = context.Crews.Where(x => x.CustomerId == foundOrder.CustomerId).Count();

            return numberOfCrewMembers;
        }

        
    }
}
