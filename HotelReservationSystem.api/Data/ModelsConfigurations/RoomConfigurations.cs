using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservationSystem.api.Data.ModelsConfigurations
{
    public class RoomConfigurations : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder
                .Property(x => x.RoomNumber)
                .HasMaxLength(20);

            builder
                .Property(x => x.Description)
                .HasMaxLength(1000);

            builder
                .Property(r => r.Status)
                .HasConversion<string>()
                .HasMaxLength(20);

            builder.Property(r => r.PricePerNight)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");
        }
    }
}
