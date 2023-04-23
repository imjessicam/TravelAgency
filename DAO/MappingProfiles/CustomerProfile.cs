using AutoMapper;
using DTO.Models.Group_1.Customer;

namespace DAO.MappingProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            // Defining of mapping
            CreateMap<TravelAgency.Models.Group_1.Customer, CustomerDetails>();
            CreateMap<TravelAgency.Models.Group_1.Customer, CustomerAllInfo>();


            // Create
            CreateMap<CreateCustomerModel, TravelAgency.Models.Group_1.Customer>();

            // Update
            CreateMap<UpdateCustomerModel, TravelAgency.Models.Group_1.Customer>();

        }

    }
}
