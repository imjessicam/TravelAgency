namespace DTO.Models.Offer
{
    public class OfferDetails
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public int NumberOfDays { get; set; }
        public int Price { get; set; }

        // Cruise
        public int CruiseId { get; set; }
        // Fleet
        public int FleetId { get; set; }
        // Skipper
        public int SkipperId { get; set; }

        // Availability of places
        public bool Availability { get; set; }
    }
}
