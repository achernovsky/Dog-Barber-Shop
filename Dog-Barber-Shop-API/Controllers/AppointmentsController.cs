using Dog_Barber_Shop_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dog_Barber_Shop_API.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;

namespace Dog_Barber_Shop_API.Controllers
{
    [Authorize(Roles = UserRoles.Client)]
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
        public async Task<ActionResult> GetAppointments()
        {
            var appointments = await _repository.GetAppointments();
            return Ok(appointments);
        }

        [HttpGet("{id}", Name = "GetAppointment")]
        public async Task<ActionResult> GetAppointment(int id)
        {
            var appointment = await _repository.GetAppointment(id);
            if (appointment == null)
                return NotFound();
            return Ok(appointment);
        }

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

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAppointment(int id)
        {
            await _repository.DeleteAppointment(id);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchAppointment(int id, [FromBody] JsonPatchDocument<Appointment> patchData)
        {
            var updatedAppointment = await _repository.PatchAppointment(id, patchData);
            if (updatedAppointment == null)
                return NotFound();

            var created = await _repository.SaveChanges();
            if (created)
                return Ok(updatedAppointment);
            else
                return BadRequest();
        }
    }
}
