namespace DTO.Models.Crew
{
    public class UpdateCrewModel
    {        
        // Details of Crew Member
        public Guid CrewExternalId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        // Customer
        public Guid CustomerExternalId { get; set; }

    }
}
