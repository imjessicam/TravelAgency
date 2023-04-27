namespace DTO.Models.Group_1.Cruise
{
    public class UpdateCruiseModel
    {
        public Guid ExternalId { get; set; }
        public string Title { get; set; } // Baleary / CaribbeanNorth
        public string Info { get; set; } // {"Mallorca", "Minorca", "Formentera"}
    }
}
