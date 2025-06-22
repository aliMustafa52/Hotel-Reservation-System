namespace HotelReservationSystem.api.Errors
{
    public static class RoomTypeErrors
    {
        public static readonly Error NotFound = new(
            "RoomType.NotFound",
            "The specified room type could not be found.",
            StatusCodes.Status404NotFound
        );

        public static readonly Error AlreadyExists = new(
            "RoomType.AlreadyExists",
            "A room type with the same name already exists.",
            StatusCodes.Status409Conflict
        );

        public static readonly Error CannotDeleteBecauseInUse = new(
            "RoomType.CannotDelete",
            "The room type cannot be deleted as it is currently in use by one or more rooms.",
            StatusCodes.Status409Conflict
        );
    }
}
