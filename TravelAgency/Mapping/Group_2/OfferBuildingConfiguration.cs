using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelAgency.Models.Group_2;

namespace TravelAgency.Mapping.Group_2
{
    public class OfferBuildingConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasIndex(x => x.Title).IsUnique();
            
        }
    }
}
