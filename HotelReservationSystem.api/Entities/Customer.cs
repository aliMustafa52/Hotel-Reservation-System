namespace HotelReservationSystem.api.Entities
{
    public class Customer : BaseModel
    {
        public ICollection<Reservation> Reservations { get; set; } = [];

        public ICollection<CustomerFeedback> Feedbacks { get; set; } = [];

        public string AppUserId { get; set; } = string.Empty;
        public AppUser AppUser { get; set; } = default!;
    }
}
