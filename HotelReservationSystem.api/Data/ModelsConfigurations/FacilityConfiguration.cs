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

            // --- SEED DATA ---
            builder.HasData(
                new Facility { Id = 1, Name = "Free Wi-Fi" },
                new Facility { Id = 2, Name = "Air Conditioning" },
                new Facility { Id = 3, Name = "Flat-screen TV" },
                new Facility { Id = 4, Name = "Mini-bar" },
                new Facility { Id = 5, Name = "In-room Safe" },
                new Facility { Id = 6, Name = "Coffee & Tea Maker" },
                new Facility { Id = 7, Name = "Pool Access" },
                new Facility { Id = 8, Name = "Gym Access" },
                new Facility { Id = 9, Name = "Room Service" },
                new Facility { Id = 10, Name = "Balcony" }
            );
        }
    }
}
