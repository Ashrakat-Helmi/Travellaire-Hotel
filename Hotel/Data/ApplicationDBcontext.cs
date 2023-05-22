using Hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Data
{
    public class ApplicationDBcontext : DbContext
    {
        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options) : base(options) { }
        public DbSet<UserLogin>userLogin { get; set; }
        public DbSet<RegisterModel>registerModels { get; set; }
        public DbSet<Room> rooms { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Booking> bookings { get; set; }
    }
}
