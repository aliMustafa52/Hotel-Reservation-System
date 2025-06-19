using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservationSystem.api.Data.ModelsConfigurations
{
    public class CustomerFeedbackConfiguration : IEntityTypeConfiguration<CustomerFeedback>
    {
        public void Configure(EntityTypeBuilder<CustomerFeedback> builder)
        {
            builder.Property(f => f.Comment)
                .HasMaxLength(2000);

            builder.Property(f => f.StaffResponse)
                .HasMaxLength(2000);

            //builder.HasOne(f => f.RespondingStaff)
            //    .WithMany(s => s.FeedbackResponses)
            //    .HasForeignKey(f => f.RespondingStaffId)
            //    .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
