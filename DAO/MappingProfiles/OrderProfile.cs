using AutoMapper;
using DTO.Models.Group_2.Offer;
using DTO.Models.Group_2.OfferCustomer;

namespace DAO.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            // Defining of mapping
            CreateMap<TravelAgency.Models.Group_2.Order, OrderDetails>();

            // Create
            CreateMap<CreateOrderModel, TravelAgency.Models.Group_2.Order>();

            // Update
            CreateMap<UpdateOrderModel, TravelAgency.Models.Group_2.Order>();
        }
    }
}
