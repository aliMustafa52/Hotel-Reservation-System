namespace HotelReservationSystem.api.Entities
{
    public class Facility : BaseModel
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<Room> Rooms { get; set; } = [];
    }
}
