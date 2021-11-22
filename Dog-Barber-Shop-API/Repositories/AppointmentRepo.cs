using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dog_Barber_Shop_API.Models;

namespace Dog_Barber_Shop_API.Repositories
{
    public class AppointmentRepo : IAppointmentRepo
    {
        public IEnumerable<Appointment> GetAppointments()
        {
            var appointments = new List<Appointment>
            {
                new Appointment { Id = 1, ClientName = "Name", Time = new DateTime(2021, 12, 21, 16, 00, 00) },
                new Appointment { Id = 1, ClientName = "Name2", Time = new DateTime(2021, 12, 21, 17, 00, 00) }
            };
            return appointments;
        }
        public Appointment GetAppointment(int id)
        {
            return new Appointment { Id = id, ClientName = "Name", Time = new DateTime(2021, 12, 21, 16, 00, 00) };
        }
        public void CreateAppointment()
        {
            throw new NotImplementedException();
        }

        public void EditAppointment()
        {
            throw new NotImplementedException();
        }


    }
}
