using Hotel.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Data
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Room> Rooms { get; set; }

        public DbSet<ParkingSlot> ParkingSlots { get; set; }

        public DbSet<Taxi> Taxis { get; set; }

        public DbSet<Review> Reviews { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    }
}
