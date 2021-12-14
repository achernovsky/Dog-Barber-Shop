using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dog_Barber_Shop_API.Models;
using Dog_Barber_Shop_API.Utils;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Dog_Barber_Shop_API.Repositories
{
    public class AppointmentRepo : IAppointmentRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContext;
        private string userId;

        public AppointmentRepo(ApplicationDbContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
            userId = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
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

            var dog = _context.Dogs.Find(appointment.DogId);

            if (dog == null || dog.ApplicationUserId != userId)
                throw new Exception("This is not your dog!");

            DateTime appTime = appointment.Time;
            DateTime now = DateTime.Now;
            DayOfWeek day = appTime.DayOfWeek;
            int hour = appTime.Hour;
            int minutes = appTime.Minute;

            if (appTime < now || day == DayOfWeek.Sunday || day == DayOfWeek.Saturday)
                throw new Exception("Invalid date");

            if (hour < 9 || hour >= 18)
                throw new Exception("Invalid time");

            if (minutes != 0 && minutes != 30)
                throw new Exception("Invalid time");

            bool isTimeTaken = false;
            var appointments = _context.Appointments;

            foreach (Appointment app in appointments) {
                if (app.Time == appTime)
                    isTimeTaken = true;
            }

            if (isTimeTaken)
                throw new Exception("Sorry, This time slot is already taken.");

            var newAppointment = new Appointment(appointment.DogId, userId, appointment.Time);
            await _context.Appointments.AddAsync(newAppointment);
        }

        public async Task<bool> DeleteAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment.ApplicationUserId == userId)
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
            if (appointment == null || appointment.ApplicationUserId != userId)
                return null;
            patchData.ApplyTo(appointment);
            return appointment;
        }
    }
}
