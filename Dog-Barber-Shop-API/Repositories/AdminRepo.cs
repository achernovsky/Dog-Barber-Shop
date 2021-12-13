using System;
using System.Threading.Tasks;
using Dog_Barber_Shop_API.Models;
using Dog_Barber_Shop_API.Utils;
using Microsoft.AspNetCore.JsonPatch;

namespace Dog_Barber_Shop_API.Repositories
{
    public class AdminRepo : IAdminRepo
    {
        private readonly ApplicationDbContext _context;

        public AdminRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveChanges()
        {
            var created = await _context.SaveChangesAsync();
            return created > 0;
        }

        public async Task CreateAppointment(Appointment appointment)
        {
            if (appointment == null)
                throw new ArgumentNullException(nameof(appointment));

            if (appointment.DogName == null)
                throw new Exception("Dog name cannot be empty");

            var newAppointment = new Appointment(appointment.DogName, appointment.Time);
            await _context.Appointments.AddAsync(newAppointment);
        }

        public async Task DeleteAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
                throw new Exception("Appointment doesn't exist");
            _context.Appointments.Remove(appointment);
            await SaveChanges();
        }

        public async Task<Appointment> PatchAppointment(int id, JsonPatchDocument<Appointment> patchData)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
                return null;
            patchData.ApplyTo(appointment);
            return appointment;
        }
    }
}
