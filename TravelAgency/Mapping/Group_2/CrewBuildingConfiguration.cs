using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelAgency.Models.Group_2;

namespace TravelAgency.Mapping.Group_2
{
    public class CrewBuildingConfiguration : IEntityTypeConfiguration<Crew>
    {
        public void Configure(EntityTypeBuilder<Crew> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasIndex(x => x.LastName);  
        }
    }
}
