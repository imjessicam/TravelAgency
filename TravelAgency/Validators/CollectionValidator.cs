using TravelAgency.Validators.Interfaces;

namespace TravelAgency.Validators
{
    public class CollectionValidator : ICollectionValidator
    {
        public bool IsValid<TWantedItemType, TFoundItemType>(IEnumerable<TWantedItemType> wantedItems, IEnumerable<TFoundItemType> foundItems)
        {
            return wantedItems.Count() == foundItems.Count();
        }
    }
}
