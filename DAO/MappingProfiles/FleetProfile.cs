using AutoMapper;
using DTO.Models.Group_1.Customer;
using DTO.Models.Group_1.Fleet;

namespace DAO.MappingProfiles
{
    public class FleetProfile : Profile
    {
        public FleetProfile()
        {
            // Defining of mapping
            CreateMap<TravelAgency.Models.Group_1.Fleet, FleetDetails>();

            // Create
            CreateMap<CreateFleetModel, TravelAgency.Models.Group_1.Fleet>();

            // Update
            CreateMap<UpdateFleetModel, TravelAgency.Models.Group_1.Fleet>();

        }
    }
}
