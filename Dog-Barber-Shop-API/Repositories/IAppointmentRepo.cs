using System.Collections.Generic;
using System.Threading.Tasks;
using Dog_Barber_Shop_API.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace Dog_Barber_Shop_API.Repositories
{
    public interface IAppointmentRepo
    {
        Task<bool> SaveChanges();
        Task <IEnumerable<Appointment>> GetAppointments();
        Task<Appointment> GetAppointment(int id);
        Task CreateAppointment(Appointment appointment);
        Task<bool> DeleteAppointment(int id);
        Task<Appointment> PatchAppointment(int id, JsonPatchDocument<Appointment> patchData);
    }
}
