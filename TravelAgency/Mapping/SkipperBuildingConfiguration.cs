using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelAgency.Models;

namespace TravelAgency.Mapping
{
    public class SkipperBuildingConfiguration : IEntityTypeConfiguration<Skipper>
    {
        public void Configure(EntityTypeBuilder<Skipper> builder)
        {

            builder
                .HasKey(x => x.Id);

            builder
                .HasIndex(x => x.LastName);

            // Offers
            builder
                .HasMany(x => x.Offers)
                .WithOne(x => x.Skipper)
                .HasForeignKey(x => x.SkipperId);
        }
    }
}
