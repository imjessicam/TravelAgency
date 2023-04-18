using AutoMapper;
using DTO.Models.Group_2.Crew;

namespace DAO.MappingProfiles
{
    public class CrewProfile : Profile
    {
        public CrewProfile()
        {
            // Defining of mapping
            CreateMap<TravelAgency.Models.Group_2.Crew, CrewDetails>();
            CreateMap<TravelAgency.Models.Group_2.Crew, CrewBasicInfo>();


            // Create
            CreateMap<CreateCrewModel, TravelAgency.Models.Group_2.Crew>();

            // Update
            CreateMap<UpdateCrewModel, TravelAgency.Models.Group_2.Crew>();
        }

    }
}
