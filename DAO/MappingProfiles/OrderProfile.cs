using AutoMapper;
using DTO.Models.Group_2.Offer;
using DTO.Models.Group_2.OfferCustomer;
using DTO.Models.Group_2.Order;

namespace DAO.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            // Defining of mapping
            CreateMap<TravelAgency.Models.Group_2.Order, OrderDetails>();
            CreateMap<TravelAgency.Models.Group_2.Order, OrderAllInfo>();


            // Create
            CreateMap<CreateOrderModel, TravelAgency.Models.Group_2.Order>();

            // Update
            CreateMap<UpdateOrderModel, TravelAgency.Models.Group_2.Order>().ForMember(destination => destination.ExternalId, options => options.MapFrom(source => source.OrderExternalId));
        }
    }
}
