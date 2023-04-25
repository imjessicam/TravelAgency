using DTO.Models.Group_2.Crew;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Data;
using TravelAgency.Validators.Interfaces;

namespace TravelAgency.Validators
{
    public class ICrewExistValidator : ICrewExist
    {
        private readonly IDbContextFactory<DatabaseContext> _factory;

        // Constructor
        public ICrewExistValidator(IDbContextFactory<DatabaseContext> factory)
        {
            _factory = factory;
        }

        public bool IsExist(Guid externalId)
        {
            using var context = _factory.CreateDbContext();

            var crewMember = context.Crews.FirstOrDefault(x => x.ExternalId == externalId);

            if (crewMember == null)
            {
                return false;
            }
            return true;
        }

        public bool IsExist(CrewFindByLastName crewMember)
        {
            using var context = _factory.CreateDbContext();

            var foundCrewMembers = context.Crews.FirstOrDefault(x => x.LastName == crewMember.LastName);

            if (foundCrewMembers == null)
            {
                return false;
            }
            return true;
        }
    }
}
