namespace TravelAgency.Models
{
    public class Skipper
    {
        public int Id { get; set; }
        public Guid ExternalId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Info { get; set; }

        // Skipper
        public virtual List<Offer> Offers { get; set; }
    }
}
