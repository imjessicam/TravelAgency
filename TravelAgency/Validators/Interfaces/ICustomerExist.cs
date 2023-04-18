namespace TravelAgency.Validators.Interfaces
{
    public interface ICustomerExist
    {
        bool IsExist(Guid externalId);
        bool IsExist(IEnumerable<Guid> externalId);
        
    }
}
