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
        }
    }
}
