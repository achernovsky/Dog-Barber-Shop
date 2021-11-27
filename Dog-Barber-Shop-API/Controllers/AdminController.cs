using Dog_Barber_Shop_API.Utils;
using Dog_Barber_Shop_API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dog_Barber_Shop_API.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    [Route("admin/appointments")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepo _repository;
        public AdminController(IAdminRepo reposotory)
        {
            _repository = reposotory;
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
                return Created("appointments/:{appointment.id}", appointment);
            else
                return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAppointment(int id)
        {
            await _repository.DeleteAppointment(id);
            return Ok("Deleted successfully");
        }

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
