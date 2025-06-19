namespace HotelReservationSystem.api.Entities
{
    public class BaseModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }
    }
}
