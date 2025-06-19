namespace HotelReservationSystem.api.Entities
{
    public class HotelStaff : BaseModel
    {
        public ICollection<CustomerFeedback> FeedbackResponses { get; set; } = [];

        public string AppUserId { get; set; } = string.Empty;
        public AppUser AppUser { get; set; } = default!;
    }
}
