namespace DTO.Models.Customer
{
    public class UpdateCustomerModel
    {
        public Guid ExternalId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}
