using System.Collections.Generic;
using System.Threading.Tasks;
using Dog_Barber_Shop_API.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace Dog_Barber_Shop_API.Repositories
{
    public interface IDogRepo
    {
        Task<IEnumerable<Dog>> GetUserDogs();
    }
}
