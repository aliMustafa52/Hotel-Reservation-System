namespace HotelReservationSystem.api.Errors
{
    public static class FacilityErrors
    {
        public static readonly Error NotFound = new(
            "Facility.NotFound",
            "The Facility could not be found.",
            StatusCodes.Status404NotFound
        );
        public static readonly Error AlreadyExists = new("Facility.AlreadyExists", "A facility with this name already exists.", StatusCodes.Status409Conflict);
        public static readonly Error InUse = new("Facility.InUse", "This facility cannot be deleted because it is assigned to one or more rooms.", StatusCodes.Status409Conflict);
    }
}
