using Dog_Barber_Shop_API.Utils;
using Dog_Barber_Shop_API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace Dog_Barber_Shop_API.Controllers
{
    [Route("authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationRepo _repository;

        public AuthenticationController(IAuthenticationRepo repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("RegisterClient")]
        public async Task<IActionResult> RegisterClient([FromBody] RegisterClientModel model)
        {
            await _repository.RegisterClient(model);
            return Ok("Client created successfully");
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        [Route("RegisterAdmin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterAdminModel model)
        {
            await _repository.RegisterAdmin(model);
            return Ok("Admin created successfully");
        }

        [HttpPost] 
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var token = await _repository.Login(model);
            if (token != null)
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            else
                return Unauthorized();
        }
        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel model)
        {
            await _repository.ChangePassword(model);
            return Ok("Paasword changed successfully");
        }
    }
}
