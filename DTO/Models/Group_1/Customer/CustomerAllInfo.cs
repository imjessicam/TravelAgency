using DTO.Models.Group_2.Crew;

namespace DTO.Models.Group_1.Customer
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
