namespace DTO.Models.Fleet
{
    public class UpdateFleetModel
    {
        public Guid ExternalId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
    }
}
