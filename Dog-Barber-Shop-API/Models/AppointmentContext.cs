using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dog_Barber_Shop_API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Dog_Barber_Shop_API.Models
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
    }
}
