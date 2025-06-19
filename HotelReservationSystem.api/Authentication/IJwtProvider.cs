namespace HotelReservationSystem.api.Authentication
{
    public interface IJwtProvider
    {
        (string token, int expiresIn) GenerateToken(AppUser user);

        string? ValidateToken(string token);
    }
}
