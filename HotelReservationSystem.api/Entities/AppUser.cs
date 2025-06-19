namespace HotelReservationSystem.api.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public bool IsActive { get; set; }
        public UserType UserType { get; set; }

        public List<RefreshToken> RefreshTokens { get; set; } = [];

        public HotelStaff? HotelStaff { get; set; }
        public Customer? Customer { get; set; }
    }
}
