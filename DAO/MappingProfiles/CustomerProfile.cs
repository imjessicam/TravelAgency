using AutoMapper;
using DTO.Models.Group_1.Customer;
using TravelAgency.Models;

namespace DAO.MappingProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            // Defining of mapping
            CreateMap<Customer, CustomerDetails>();
            CreateMap<Customer, CustomerAllInfo>();


            // Create
            CreateMap<CreateCustomerModel, Customer>();

            // Update
            CreateMap<UpdateCustomerModel, Customer>();

        }

    }
}
