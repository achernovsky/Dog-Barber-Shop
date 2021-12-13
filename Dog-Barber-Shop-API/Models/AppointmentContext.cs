using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Dog_Barber_Shop_API.Models;

namespace Dog_Barber_Shop_API.Utils
{
    public class AppointmentContext : IdentityDbContext
    {
        public AppointmentContext(DbContextOptions<AppointmentContext> options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Dog> Dogs { get; set; }
    }
}
