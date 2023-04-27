using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelAgency.Models;

namespace TravelAgency.Mapping
{
    public class FleetBuildingConfiguration : IEntityTypeConfiguration<Fleet>
    {
        public void Configure(EntityTypeBuilder<Fleet> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasIndex(x => x.Name)
                .IsUnique();

            // Offers
            builder
                .HasMany(x => x.Offers)
                .WithOne(x => x.Fleet)
                .HasForeignKey(x => x.FleetId);
        }
    }
}
