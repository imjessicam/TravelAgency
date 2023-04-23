using DTO.Models.Group_1.Customer;
using DTO.Models.Group_2.Crew;
using DTO.Models.Group_2.Offer;

namespace DTO.Models.Group_2.Order
{
    public class OrderAllInfo
    {
        public Guid ExternalId { get; set; }
        public int Id { get; set; }
        
        public CustomerDetails Customer { get; set; }

        public OfferAllInfo Offer { get; set; }


        
    }
}
