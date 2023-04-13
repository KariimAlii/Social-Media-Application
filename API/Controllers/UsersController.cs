using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // [controller] is a placeholder ===> Users
    public class UsersController : ControllerBase
    {
        IUser db;
        public UsersController(IUser _db)
        {
            db = _db;
        }


        // api/Users
        [HttpGet]
        public async Task<IEnumerable<User>>  GetUsers()
        {
            var users = await db.GetAllUsers();
            return users;
        }


        // api/Users/{id}
        [HttpGet("{id}")]
        public async Task<User> GetUser(int id)
        {
            var user = await db.GetUserById(id);
            return user;
        }
    }
}
