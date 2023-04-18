using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelAgency.Models.Group_1;

namespace TravelAgency.Mapping.Group_1
{
    public class CruiseBuildingConfiguration : IEntityTypeConfiguration<Cruise>
    {
        public void Configure(EntityTypeBuilder<Cruise> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasIndex(x => x.Title)
                .IsUnique();

            // Offers
            builder
                .HasMany(x => x.Offers)
                .WithOne(x => x.Cruise)
                .HasForeignKey(x => x.CruiseId);


        }
    }
}
