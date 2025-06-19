namespace HotelReservationSystem.api.Entities
{
    public class RoomType : BaseModel
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
