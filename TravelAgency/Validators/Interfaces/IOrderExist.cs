namespace TravelAgency.Validators.Interfaces
{
    public interface IOrderExist
    {
        bool IsExist(Guid externalId);

    }
}
