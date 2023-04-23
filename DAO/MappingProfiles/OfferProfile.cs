using AutoMapper;
using DTO.Models.Group_1.Fleet;
using DTO.Models.Group_2.Offer;

namespace DAO.MappingProfiles
{
    public class OfferProfile : Profile
    {
        public OfferProfile()
        {
            // Defining of mapping
            CreateMap<TravelAgency.Models.Group_2.Offer, OfferDetails>();
            CreateMap<TravelAgency.Models.Group_2.Offer, OfferAllInfo>();


            // Create
            CreateMap<CreateOfferModel, TravelAgency.Models.Group_2.Offer>();

            // Update
            CreateMap<UpdateOfferModel, TravelAgency.Models.Group_2.Offer>().ForMember(destination => destination.ExternalId, options => options.MapFrom(source => source.OfferExternalId));

        }
    }
}
