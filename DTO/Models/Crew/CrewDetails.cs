namespace DTO.Models.Crew
{
    public class CrewDetails
    {
        // Customer
        public int CustomerId { get; set; }

        // Details of Crew Member
        public int Id { get; set; }
        //public bool IsBooker { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        //public DateTime DateOfBirth { get; set; }
        //public string PhoneNo { get; set; }
        //public string Info { get; set; }
    }
}
