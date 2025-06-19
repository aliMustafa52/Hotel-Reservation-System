using System.Reflection;

namespace HotelReservationSystem.api.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options)
        :IdentityDbContext<AppUser>(options)
    {
        public required DbSet<Room> Rooms { get; set; }
        public required DbSet<RoomImage> RoomImages { get; set; }
        public required DbSet<RoomType> RoomTypes { get; set; }
        public required DbSet<Facility> Facilities { get; set; }
        public required DbSet<Reservation> Reservations { get; set; }
        public required DbSet<Offer> Offers { get; set; }
        public required DbSet<CustomerFeedback> CustomerFeedbacks { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
