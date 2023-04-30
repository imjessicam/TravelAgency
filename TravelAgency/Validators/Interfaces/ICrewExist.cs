using DTO.Models.Crew;

namespace TravelAgency.Validators.Interfaces
{
    public interface ICrewExist
    {
        bool IsExist(Guid externalId);

        bool IsExist(CrewFindByLastName crewMember);

    }
}
