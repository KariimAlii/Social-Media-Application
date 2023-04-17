
using API.Data;
using API.DTOs;
using API.Models;
using API.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IUser db;
        private readonly ITokenService tokenService;

        public AccountController(IUser _db , ITokenService _tokenService)
        {
            db = _db;
            tokenService = _tokenService;
        }


        // api/Account/register
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var isUserExist = await db.isUserExists(registerDto.UserName,registerDto.Email);
            if (isUserExist) return BadRequest("UserName is taken");

            using var hmac = new HMACSHA512();

            var user = new User()
            {
                UserName = registerDto.UserName.ToLower(),
                Email = registerDto.Email.ToLower() ,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.password)),
                PasswordSalt = hmac.Key,
                Age = registerDto.Age
            };
            db.AddUser(user);

            return new UserDto
            {
                Username = user.UserName,
                Email = user.Email,
                Token = tokenService.CreateToken(user)
            };
        }


        // api/Account/login
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await db.getUserByUserName(loginDto.UserName);
            if (user == null) return Unauthorized("Invalid Username");

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password");
            }

            return new UserDto
            {
                Username = user.UserName,
                Email = user.Email,
                Token = tokenService.CreateToken(user)
            };
        }
    }
}
