namespace HotelReservationSystem.api.Errors
{
    public static class RoomErrors
    {
        public static readonly Error NotFound = new(
            "Room.NotFound",
            "The Room could not be found.",
            StatusCodes.Status404NotFound
        );
        public static readonly Error AlreadyExists = new("Room.AlreadyExists", "A room with this number already exists.", StatusCodes.Status409Conflict);
        public static readonly Error InUse = new("Room.InUse", "This room cannot be deleted because it has existing reservations.", StatusCodes.Status409Conflict);
    }
}
