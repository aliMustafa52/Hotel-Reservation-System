using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservationSystem.api.Data.ModelsConfigurations
{
    public class FacilityConfiguration : IEntityTypeConfiguration<Facility>
    {
        public void Configure(EntityTypeBuilder<Facility> builder)
        {
            builder.Property(f => f.Name)
                .HasMaxLength(100);

            builder.HasIndex(f => f.Name)
                .IsUnique();
        }
    }
}
