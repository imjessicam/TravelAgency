using AutoMapper;
using DTO.Models.Order;
using TravelAgency.Models;

namespace DAO.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            // Defining of mapping
            CreateMap<Order, OrderDetails>();
            CreateMap<Order, OrderAllInfo>();


            // Create
            CreateMap<CreateOrderModel, Order>();

            // Update
            CreateMap<UpdateOrderModel, Order>().ForMember(destination => destination.ExternalId, options => options.MapFrom(source => source.OrderExternalId));
        }
    }
}
