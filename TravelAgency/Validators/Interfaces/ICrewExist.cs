using DTO.Models.Group_2.Crew;

namespace TravelAgency.Validators.Interfaces
{
    public interface ICrewExist
    {
        bool IsExist(Guid externalId);

        bool IsExist(CrewFindByLastName crewMember);

    }
}
