using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelAgency.Models.Group_2;

namespace TravelAgency.Mapping.Group_2
{
    public class OrderBuildingConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Offer
            builder                
                .HasOne(x => x.Offer)
                .WithMany(x => x.OffersCustomers)
                .HasForeignKey(x => x.OfferId);

            // Customer
            builder
                .HasOne(x => x.Customer)
                .WithMany(x => x.OffersCustomers)
                .HasForeignKey(x => x.CustomerId);


        }
    }
}
