using Dog_Barber_Shop_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dog_Barber_Shop_API.Repositories;

namespace Dog_Barber_Shop_API.Controllers
{
    [Route("appointments")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentRepo _repository;
        public AppointmentsController(IAppointmentRepo reposotory)
        {
            _repository = reposotory;
        }

        [HttpGet]
        public ActionResult <IEnumerable<Appointment>> GetAppointments()
        {
            return Ok(_repository.GetAppointments());
        }

        [HttpGet("{id}")]
        public ActionResult<Appointment> GetAppointment(int id)
        {
            return Ok(_repository.GetAppointment(id));
        }
    }
}
