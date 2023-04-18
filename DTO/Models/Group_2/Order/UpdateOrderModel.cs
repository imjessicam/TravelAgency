namespace DTO.Models.Group_2.OfferCustomer
{
    public class UpdateOrderModel
    {
        public Guid OrderExternalId { get; set; }

        // Offer
        public Guid OfferExternalId { get; set; }

        // Customer
        public Guid CustomerExternalId { get; set; }

        
    }
}
