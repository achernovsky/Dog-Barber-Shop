using Dog_Barber_Shop_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Dog_Barber_Shop_API.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;
namespace Dog_Barber_Shop_API.Controllers
{
    [Route("dogs")]
    [ApiController]
    public class DogsController : ControllerBase
    {

        private readonly IDogRepo _repository;
        public DogsController(IDogRepo reposotory)
        {
            _repository = reposotory;
        }

        [Authorize(Roles = UserRoles.ClientOrAdmin)]
        [HttpGet()]
        public async Task<ActionResult> GetUserDogs()
        {
            var dogs = await _repository.GetUserDogs();
            if (dogs == null)
                return NotFound();
            return Ok(dogs);
        }
    }
}
