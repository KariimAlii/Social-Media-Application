using API.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Models;
using ServiceLayer.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AccountController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }


        // api/Account/register
        //[HttpPost("register")]
        //public async Task<ActionResult<UserModel>> Register(RegisterModel registerModel)
        //{
        //    var isUserExist = await _userService.isUserExists(registerModel.UserName, registerModel.Email);
        //    if (isUserExist) return BadRequest("UserName is taken");

        //    using var hmac = new HMACSHA512();

        //    var user = new UserModel()
        //    {
        //        UserName = registerModel.UserName.ToLower(),
        //        Email = registerModel.Email.ToLower(),
        //        PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerModel.password)),
        //        PasswordSalt = hmac.Key,
        //        Age = registerModel.Age
        //    };
        //    _userService.AddUser(user);

        //    return new UserModel
        //    {
        //        Username = user.UserName,
        //        Email = user.Email,
        //        Token = _tokenService.CreateToken(user)
        //    };
        //}


        // api/Account/login
        //[HttpPost("login")]
        //public async Task<ActionResult<UserModel>> Login(LoginModel loginDto)
        //{
        //    var user = await _userService.getUserByUserName(loginDto.UserName);
        //    if (user == null) return Unauthorized("Invalid Username");

        //    using var hmac = new HMACSHA512(user.PasswordSalt);
        //    var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.password));

        //    for (int i = 0; i < computedHash.Length; i++)
        //    {
        //        if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password");
        //    }

        //    return new UserModel
        //    {
        //        Username = user.UserName,
        //        Email = user.Email,
        //        Token = _tokenService.CreateToken(user)
        //    };
        //}
    }
}
