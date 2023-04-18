using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelAgency.Models.Group_1;

namespace TravelAgency.Mapping.Group_1
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
