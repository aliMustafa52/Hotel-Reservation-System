using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservationSystem.api.Data.ModelsConfigurations
{
    public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
    {
        public void Configure(EntityTypeBuilder<RoomType> builder)
        {
            builder.Property(rt => rt.Name)
                .HasMaxLength(100);

            builder.HasIndex(rt => rt.Name)
                .IsUnique();

            builder.Property(rt => rt.Description)
                .HasMaxLength(1000);

            // --- SEED DATA ---
            // This data will be inserted into the database when migrations are applied.
            builder.HasData(
                new RoomType { Id = 1, Name = "Standard Single", Description = "A cozy room perfect for a single traveler." },
                new RoomType { Id = 2, Name = "Standard Double", Description = "A comfortable room with two single beds." },
                new RoomType { Id = 3, Name = "Deluxe Queen", Description = "A spacious room with a queen-sized bed and premium amenities." },
                new RoomType { Id = 4, Name = "Deluxe King", Description = "An elegant room featuring a king-sized bed and enhanced space." },
                new RoomType { Id = 5, Name = "Junior Suite", Description = "A large room with a separate living area and king-sized bed." },
                new RoomType { Id = 6, Name = "Presidential Suite", Description = "Our most luxurious suite with multiple rooms and exclusive services." }
            );
        }
    }
}
