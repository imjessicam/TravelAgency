using AutoMapper;
using DTO.Models.Group_1.Cruise;
using DTO.Models.Group_1.Customer;

namespace DAO.MappingProfiles
{
    public class CruiseProfile : Profile
    {
        public CruiseProfile()
        {
            // Defining of mapping
            CreateMap<TravelAgency.Models.Group_1.Cruise, CruiseDetails>();

            // Create
            CreateMap<CreateCruiseModel, TravelAgency.Models.Group_1.Cruise>();

            // Update
            CreateMap<UpdateCruiseModel, TravelAgency.Models.Group_1.Cruise>();

        }
    }
}
