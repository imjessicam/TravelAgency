using TravelAgency.Models.Group_2;

namespace TravelAgency.Models.Group_1
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
