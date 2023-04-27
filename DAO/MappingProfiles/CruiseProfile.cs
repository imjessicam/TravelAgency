using AutoMapper;
using DTO.Models.Group_1.Cruise;
using DTO.Models.Group_1.Customer;
using TravelAgency.Models;

namespace DAO.MappingProfiles
{
    public class CruiseProfile : Profile
    {
        public CruiseProfile()
        {
            // Defining of mapping
            CreateMap<Cruise, CruiseDetails>();

            // Create
            CreateMap<CreateCruiseModel, Cruise>();

            // Update
            CreateMap<UpdateCruiseModel, Cruise>();

        }
    }
}
