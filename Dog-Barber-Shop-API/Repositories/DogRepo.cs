using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dog_Barber_Shop_API.Models;
using Dog_Barber_Shop_API.Utils;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Dog_Barber_Shop_API.Repositories
{
    public class DogRepo : IDogRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContext;
        private string userId;

        public DogRepo(ApplicationDbContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
            userId = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
        public async Task<IEnumerable<Dog>> GetUserDogs()
        {
            var dogs = await _context.Dogs.ToListAsync();
            return dogs.FindAll(d => d.ApplicationUserId == userId);
        }
    }
}
