using Microsoft.EntityFrameworkCore;

namespace TurfBooking.Models
{
    public class TurfBookingContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Turf> Turfs { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Slot> Slots { get; set; }

       
        public TurfBookingContext(DbContextOptions<TurfBookingContext> options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Bookings)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<Turf>()
                .HasMany(t => t.Bookings)
                .WithOne(b => b.Turf)
                .HasForeignKey(b => b.TurfId);

            modelBuilder.Entity<User>()
                .Property(t => t.Role)
                .HasDefaultValue("Customer");



        }
    }
}
