namespace TravelAgency.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public Guid ExternalId { get; set; }
        public string Title { get; set; }

        public string Start { get; set; }
        public string End { get; set; }
        public int NumberOfDays { get; set; }
        public int Price { get; set; }

        // Cruise
        public int CruiseId { get; set; }
        public virtual Cruise Cruise { get; set; }
        // Fleet
        public int FleetId { get; set; }
        public virtual Fleet Fleet { get; set; }
        // Skipper
        public int SkipperId { get; set; }
        public virtual Skipper Skipper { get; set; }

        // Availability of places
        public bool Availability { get; set; }

        // OfferCustomer
        public virtual List<Order> OffersCustomers { get; set; }
    }
}
