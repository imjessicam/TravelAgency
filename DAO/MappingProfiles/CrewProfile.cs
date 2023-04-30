using AutoMapper;
using DTO.Models.Crew;
using TravelAgency.Models;

namespace DAO.MappingProfiles
{
    public class CrewProfile : Profile
    {
        public CrewProfile()
        {
            // Defining of mapping
            CreateMap<Crew, CrewDetails>();
            CreateMap<Crew, CrewBasicInfo>();

            // Create
            CreateMap<CreateCrewModel, Crew>();

            // Update
            CreateMap<UpdateCrewModel, Crew>().ForMember(destination => destination.ExternalId, options => options.MapFrom(source => source.CrewExternalId));
        }

    }
}
