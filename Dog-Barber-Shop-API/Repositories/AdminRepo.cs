using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Dog_Barber_Shop_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dog_Barber_Shop_API.Repositories
{
    public class AdminRepo : IAdminRepo
    {
        private readonly AppointmentContext _context;

        public AdminRepo(AppointmentContext context)
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

            var newAppointment = new Appointment
            {
                DogName = appointment.DogName,
                Time = appointment.Time
            };
            await _context.Appointments.AddAsync(newAppointment);
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
