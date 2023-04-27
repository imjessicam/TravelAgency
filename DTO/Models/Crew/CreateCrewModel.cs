namespace DTO.Models.Group_2.Crew
{
    public class CreateCrewModel
    {
        // Customer
        public Guid CustomerExternalId { get; set; }

        // Details of Crew Member
        //public bool IsBooker { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        //public DateTime DateOfBirth { get; set; }
        //public string PhoneNo { get; set; }
        //public string Info { get; set; }
    }
}
