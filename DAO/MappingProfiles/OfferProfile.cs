using AutoMapper;
using DTO.Models.Group_1.Fleet;
using DTO.Models.Group_2.Offer;
using TravelAgency.Models;

namespace DAO.MappingProfiles
{
    public class OfferProfile : Profile
    {
        public OfferProfile()
        {
            // Defining of mapping
            CreateMap<Offer, OfferDetails>();
            CreateMap<Offer, OfferAllInfo>();


            // Create
            CreateMap<CreateOfferModel, Offer>();

            // Update
            CreateMap<UpdateOfferModel, Offer>().ForMember(destination => destination.ExternalId, options => options.MapFrom(source => source.OfferExternalId));

        }
    }
}
