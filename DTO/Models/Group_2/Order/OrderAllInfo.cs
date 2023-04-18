namespace DTO.Models.Group_2.Order
{
    public class OrderAllInfo
    {
        public int Id { get; set; }
        public string OfferTitle { get; set; }
        public string CruiseTitle { get; set; }
        public int Price { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public IReadOnlyList<string> CrewMembers { get; set; }
        
    }
}
