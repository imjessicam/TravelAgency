namespace DTO.Models.Order { 
    public class CreateOrderModel
    {
        
        // Offer
        public Guid OfferExternalId { get; set; }

        // Customer
        public Guid CustomerExternalId { get; set; }


    }
}
