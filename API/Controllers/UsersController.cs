using API.Models;
using API.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class UsersController : BaseApiController
    {
        IUser db;
        public UsersController(IUser _db)
        {
            db = _db;
        }


        // api/Users
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>>  GetUsers()
        {
            var users = await db.GetAllUsers();
            //return Ok(users);
            return users.ToList();
            // https://www.tutorialsteacher.com/webapi/action-method-return-type-in-web-api
        }


        // api/Users/{id}
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await db.GetUserById(id);
            return user;
        }
    }
}
