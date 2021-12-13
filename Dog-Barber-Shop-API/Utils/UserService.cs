using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Dog_Barber_Shop_API.Utils
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly ApplicationDbContext _context;

        public UserService(IHttpContextAccessor httpContext, ApplicationDbContext context)
        {
            _httpContext = httpContext;
            _context = context;
        }

        public string GetUserName()
        {
            var userName = _httpContext.HttpContext.User.Identity.Name;
            return userName;
        }

        public string getDogName()
        {
            var userName = GetUserName();
            var user = _context.ApplicationUsers.SingleOrDefault(u => u.UserName == userName);
            var dogName = user.DogName;
            return dogName;
        }
    }
}
