using Dog_Barber_Shop_API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace Dog_Barber_Shop_API.Repositories
{
    public interface IAuthenticationRepo
    {
        Task RegisterClient(RegisterClientModel model);
        Task RegisterAdmin(RegisterAdminModel model);
        Task<JwtSecurityToken> Login(LoginModel model);
        Task ChangePassword(ChangePasswordModel model);
    }
}
