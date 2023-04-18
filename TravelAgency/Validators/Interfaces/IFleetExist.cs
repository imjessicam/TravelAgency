namespace TravelAgency.Validators.Interfaces
{
    public interface IFleetExist
    {
        bool IsExist(Guid externalId);
    }
}
