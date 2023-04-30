namespace DTO.Models.Cruise
{
    public class UpdateCruiseModel
    {
        public Guid ExternalId { get; set; }
        public string Title { get; set; } // Baleary / CaribbeanNorth
        public string Info { get; set; } // {"Mallorca", "Minorca", "Formentera"}
    }
}
