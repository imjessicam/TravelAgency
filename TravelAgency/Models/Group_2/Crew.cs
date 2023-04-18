using TravelAgency.Models.Group_1;

namespace TravelAgency.Models.Group_2
{
    public class Crew
    {
        public int Id { get; set; }
        public Guid ExternalId { get; set; }

        // Customer
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        // Details of Crew Member
        //public bool IsBooker { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        //public DateTime DateOfBirth { get; set; }
        //public string Info { get; set; }


    }
}
