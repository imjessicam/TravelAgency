using AutoMapper;
using DTO.Models.Group_1.Customer;
using DTO.Models.Group_1.Fleet;
using TravelAgency.Models;

namespace DAO.MappingProfiles
{
    public class FleetProfile : Profile
    {
        public FleetProfile()
        {
            // Defining of mapping
            CreateMap<Fleet, FleetDetails>();

            // Create
            CreateMap<CreateFleetModel, Fleet>();

            // Update
            CreateMap<UpdateFleetModel, Fleet>();

        }
    }
}
