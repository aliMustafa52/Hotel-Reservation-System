namespace HotelReservationSystem.api.Errors
{
    public static class UserErrors
    {
        public static readonly Error UserNotFound =
            new("User.NotFound", "No User was found with the given ID", StatusCodes.Status404NotFound);

        public static readonly Error UserInvalidCredentials =
            new("User.InvalidCredentials", "Email or password is not correct", StatusCodes.Status401Unauthorized);

        public static readonly Error UserInvalidAccessToken =
            new("User.InvalidAccessToken", "Jwt Access Token is not valid", StatusCodes.Status401Unauthorized);

        public static readonly Error UserInvalidResreshToken =
            new("User.InvalidResreshToken", "Resresh Token is not valid", StatusCodes.Status401Unauthorized);

        public static readonly Error DisabledUser =
            new("User.DisabledUser", "DisabledUser, Pleases contact your admin", StatusCodes.Status401Unauthorized);

        public static readonly Error LockedOutUser =
            new("User.LockedOutUser", "LockedOutUser, Pleases try again after 5 mins", StatusCodes.Status401Unauthorized);

        public static readonly Error UserDublicatedEmail =
            new("User.DublicatedEmail", "This email is already exists", StatusCodes.Status409Conflict);

        public static readonly Error UserIsNotAnInstructor =
            new("User.IsNotAnInstructor", "This User Is Not An Instructor", StatusCodes.Status400BadRequest);
    }
}
