namespace TravelAgency.Models
{
    public class Fleet
    {
        public int Id { get; set; }
        public Guid ExternalId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }

        // Offer
        public virtual List<Offer> Offers { get; set; }
    }
}
