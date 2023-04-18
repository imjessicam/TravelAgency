using AutoMapper;
using DTO.Models.Group_1.Skipper;

namespace DAO.MappingProfiles
{
    public class SkipperProfile : Profile
    {
        public SkipperProfile()
        {
            // Defining of mapping
            CreateMap<TravelAgency.Models.Group_1.Skipper, SkipperDetails>();

            // Create
            CreateMap<CreateSkipperModel, TravelAgency.Models.Group_1.Skipper>();

            // Update
            CreateMap<UpdateSkipperModel, TravelAgency.Models.Group_1.Skipper>();
        }
    }
}
