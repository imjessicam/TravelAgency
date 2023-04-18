using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelAgency.Models.Group_1;

namespace TravelAgency.Mapping.Group_1
{
    public class CustomerBuildingConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasIndex(x => x.LastName);

            // Crew
            builder
                .HasMany(x => x.Crews)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerId);
        }
    }
}
