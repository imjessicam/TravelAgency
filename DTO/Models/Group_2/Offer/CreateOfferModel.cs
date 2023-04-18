﻿namespace DTO.Models.Group_2.Offer
{
    public class CreateOfferModel
    {        
        public string Title { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public int NumberOfDays { get; set; }
        public int Price { get; set; }

        // Cruise
        public Guid CruiseExternalId { get; set; }

        // Fleet
        public Guid FleetExternalId { get; set; }

        // Skipper
        public Guid SkipperExternalId { get; set; }

        // Availability of places
        public bool Availability { get; set; }
    }
}