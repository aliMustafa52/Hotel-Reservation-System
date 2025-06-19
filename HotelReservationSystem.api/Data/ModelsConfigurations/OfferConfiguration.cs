using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservationSystem.api.Data.ModelsConfigurations
{
    public class OfferConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.Property(o => o.OfferName)
                .HasMaxLength(150);

            builder.Property(o => o.DiscountPercentage)
                .HasColumnType("decimal(5, 2)");
        }
    }
}
