using HotelReservationSystem.api.Contracts.RoomTypes;

namespace HotelReservationSystem.api.Contracts.Rooms
{
    public record RoomResponse(
        int Id,
        string RoomNumber,
        string Description,
        string Status,
        decimal PricePerNight,
        int MaxOccupancy,
        RoomTypeResponse RoomType,
        IEnumerable<FacilityResponse> Facilities
    );
}
