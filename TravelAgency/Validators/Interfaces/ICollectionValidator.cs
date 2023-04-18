namespace TravelAgency.Validators.Interfaces
{
    public interface ICollectionValidator
    {
        bool IsValid<TWantedItemType, TFoundItemType>(IEnumerable<TWantedItemType> wantedItems, IEnumerable<TFoundItemType> foundItems);
    }
}
