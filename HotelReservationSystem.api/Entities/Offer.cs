namespace HotelReservationSystem.api.Entities
{
    public class Offer : BaseModel
    {
        public string OfferName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal? DiscountPercentage { get; set; }

        public ICollection<Room> Rooms { get; set; } = [];
    }
}
