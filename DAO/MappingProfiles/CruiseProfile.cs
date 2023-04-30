using AutoMapper;
using DTO.Models.Cruise;
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
