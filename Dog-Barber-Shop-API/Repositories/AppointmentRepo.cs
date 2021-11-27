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
    public class AppointmentRepo : IAppointmentRepo
    {
        private readonly AppointmentContext _context;
        private readonly IUserService _userService;
        private string dogName;

        public AppointmentRepo(AppointmentContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
            dogName = _userService.getDogName();
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

            var newAppointment = new Appointment
            {
                DogName = dogName,
                Time = appointment.Time
            };
            await _context.Appointments.AddAsync(newAppointment);
        }

        public async Task<bool> DeleteAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment.DogName == dogName)
            {
                _context.Appointments.Remove(appointment);
                await SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<Appointment> PatchAppointment(int id, JsonPatchDocument<Appointment> patchData)
        { 
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null || appointment.DogName != dogName)
                return null;
            patchData.ApplyTo(appointment);
            return appointment;
        }


    }
}
