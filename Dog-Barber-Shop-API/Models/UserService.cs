using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace Dog_Barber_Shop_API.Models
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly AppointmentContext _context;

        public UserService(IHttpContextAccessor httpContext, AppointmentContext context)
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
