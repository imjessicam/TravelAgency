using DTO.Models.Customer;
using DTO.Models.Crew;
using DTO.Models.Offer;

namespace DTO.Models.Order
{
    public class OrderAllInfo
    {
        public Guid ExternalId { get; set; }
        public int Id { get; set; }
        
        public CustomerDetails Customer { get; set; }

        public OfferAllInfo Offer { get; set; }


        
    }
}
