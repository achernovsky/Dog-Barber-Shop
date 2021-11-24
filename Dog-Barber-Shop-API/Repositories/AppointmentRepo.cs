using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dog_Barber_Shop_API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dog_Barber_Shop_API.Repositories
{
    public class AppointmentRepo : IAppointmentRepo
    {
        private readonly AppointmentContext _context;

        public AppointmentRepo(AppointmentContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveChanges()
        {
            var created = await _context.SaveChangesAsync();
            return created > 0;
        }
        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _context.Appointments.ToListAsync();
        }
        public async Task<Appointment> GetAppointment(int id)
        {
            return await _context.Appointments.FindAsync(id);
        }
        public async Task CreateAppointment(Appointment appointment)
        {
            if (appointment == null)
                throw new ArgumentNullException(nameof(appointment));
            await _context.Appointments.AddAsync(appointment);
        }

        public async Task DeleteAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
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
