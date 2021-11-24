using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dog_Barber_Shop_API.Models;

namespace Dog_Barber_Shop_API.Models
{
    public class AppointmentContext : DbContext
    {
        public AppointmentContext(DbContextOptions<AppointmentContext> options) : base(options)
        {
                
        }

        public DbSet<Appointment> Appointments { get; set; }
    }
}
