namespace HotelReservationSystem.api.Entities
{
    public class CustomerFeedback : BaseModel
    {
        public int Rating { get; set; }

        public string Comment { get; set; } = string.Empty;


        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = default!;

        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; } = default!;

        public string StaffResponse { get; set; } = string.Empty;
        public DateTime? ResponseDate { get; set; }

        public int RespondingStaffId { get; set; }
        public HotelStaff RespondingStaff { get; set; } = default!;
    }
}
