using TravelAgency.Models.Group_2;

namespace TravelAgency.Models.Group_1
{
    public class Customer
    {
        public int Id { get; set; }
        public Guid ExternalId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // Crew
        public virtual List<Crew> Crews { get; set; }

        // OfferCustomer
        public virtual List<Order> OffersCustomers { get; set; }
    }
}
