using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dog_Barber_Shop_API.Models;

namespace Dog_Barber_Shop_API.Repositories
{
    public interface IAppointmentRepo
    {
        IEnumerable<Appointment> GetAppointments();
        Appointment GetAppointment(int id);
        void CreateAppointment();
        void EditAppointment();
    }
}
