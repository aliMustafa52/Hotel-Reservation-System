using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystem.api.Authentication
{
    public class JwtOptions
    {
        public static readonly string SectionName = "Jwt";

        [Required]
        public string Key { get; init; } = string.Empty;

        [Required]
        public string Issuer { get; init; } = string.Empty;

        [Required]
        public string Audience { get; init; } = string.Empty;

        [Range(1, 180)]
        public int ExpiryMinutes { get; init; }
    }
}
