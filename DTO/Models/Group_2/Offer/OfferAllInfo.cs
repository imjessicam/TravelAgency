using DTO.Models.Group_1.Cruise;
using DTO.Models.Group_1.Fleet;
using DTO.Models.Group_1.Skipper;

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
        public CruiseDetails Cruise { get; set; }

        // Fleet
        public FleetDetails Fleet { get; set; }

        // Skipper
        public SkipperDetails Skipper { get; set; }

        // Availability of places
        public bool Availability { get; set; }
    }
}
