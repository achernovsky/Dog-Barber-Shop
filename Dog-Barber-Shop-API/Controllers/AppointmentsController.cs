using Dog_Barber_Shop_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Dog_Barber_Shop_API.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;

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

        [Authorize(Roles = UserRoles.ClientOrAdmin)]
        [HttpGet]
        public async Task<ActionResult> GetAppointments()
        {
            var appointments = await _repository.GetAppointments();
            return Ok(appointments);
        }

        [Authorize(Roles = UserRoles.ClientOrAdmin)]
        [HttpGet("{id}", Name = "GetAppointment")]
        public async Task<ActionResult> GetAppointment(int id)
        {
            var appointment = await _repository.GetAppointment(id);
            if (appointment == null)
                return NotFound();
            return Ok(appointment);
        }

        [Authorize(Roles = UserRoles.Client)]
        [HttpPost]
        public async Task<ActionResult<Appointment>> CreateAppointment(Appointment appointment)
        {
            if (ModelState.IsValid)
                await _repository.CreateAppointment(appointment);
            else
                return BadRequest();

            var created = await _repository.SaveChanges();
            if (created)
                return CreatedAtRoute(nameof(GetAppointment), new { Id = appointment.Id }, appointment);
            else
                return BadRequest();
        }

        [Authorize(Roles = UserRoles.Client)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAppointment(int id)
        {
            var deleted = await _repository.DeleteAppointment(id);
            if (deleted)
                return Ok();
            return BadRequest();
        }

        [Authorize(Roles = UserRoles.Client)]
        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchAppointment(int id, [FromBody] JsonPatchDocument<Appointment> patchData)
        {
            var updatedAppointment = await _repository.PatchAppointment(id, patchData);
            if (updatedAppointment == null)
                return NotFound();

            var patched = await _repository.SaveChanges();
            if (patched)
                return Ok(updatedAppointment);
            else
                return BadRequest();
        }
    }
}
