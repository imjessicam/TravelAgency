using DTO.Models.Group_1.Fleet;

namespace DTO.Models.Group_2.Offer
{
    public class OfferAllInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public int NumberOfDays { get; set; }
        public int Price { get; set; }

        // Cruise

        // Fleet
        public FleetDetails Fleet { get; set; }

        // Skipper

        // Availability of places
        public bool Availability { get; set; }
    }
}
