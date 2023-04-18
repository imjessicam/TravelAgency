using TravelAgency.Models.Group_2;

namespace TravelAgency.Models.Group_1
{
    public class Cruise
    {
        public int Id { get; set; }
        public Guid ExternalId { get; set; }
        public string Title { get; set; } // Baleary / CaribbeanNorth
        public string Info { get; set; } // {"Mallorca", "Minorca", "Formentera"}

        // Offer
        public virtual List<Offer> Offers { get; set; }
    }
}
