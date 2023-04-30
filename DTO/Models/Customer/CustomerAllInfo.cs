using DTO.Models.Crew;

namespace DTO.Models.Customer
{
    public class CustomerAllInfo
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public IReadOnlyList<CrewBasicInfo> CrewMembers { get; set; }

    }
}
