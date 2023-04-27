﻿using System;
using System.Collections.Generic;

namespace TravelAgency.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Guid ExternalId { get; set; }

        // Offer
        public int OfferId { get; set; }
        public virtual Offer Offer { get; set; }

        // Customer
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }


    }
}