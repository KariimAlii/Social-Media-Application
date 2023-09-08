using API.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Models.User;

namespace API.Controllers
{

    public class UsersController : BaseApiController
    {
        IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        // api/Users
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>>  GetUsers()
        {
            var users = await _userService.GetAllUsers();
            //return Ok(users);
            return users.ToList();
            // https://www.tutorialsteacher.com/webapi/action-method-return-type-in-web-api
        }


        // api/Users/{id}
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUser(int id)
        {
            var user = await _userService.GetUserById(id);
            return user;
        }
    }
}
