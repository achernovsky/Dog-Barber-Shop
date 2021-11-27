using Dog_Barber_Shop_API.Utils;
using Microsoft.AspNetCore.JsonPatch;
using System.Threading.Tasks;

namespace Dog_Barber_Shop_API.Repositories
{
    public interface IAdminRepo
    {
        Task CreateAppointment(Appointment appointment);
        Task DeleteAppointment(int id);
        Task<Appointment> PatchAppointment(int id, JsonPatchDocument<Appointment> patchData);
        Task<bool> SaveChanges();
    }
}