namespace HotelReservationSystem.api.Contracts.Rooms
{
    public record RoomRequest(
        string RoomNumber,
        string Description,
        RoomStatus Status,
        decimal PricePerNight,
        int MaxOccupancy,
        int RoomTypeId,
        List<int> FacilityIds
    );
}
