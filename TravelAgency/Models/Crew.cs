﻿namespace TravelAgency.Models
{
    public class Crew
    {
        public int Id { get; set; }
        public Guid ExternalId { get; set; }

        // Customer
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }        

        public string LastName { get; set; }
        public string FirstName { get; set; }

       


    }
}
