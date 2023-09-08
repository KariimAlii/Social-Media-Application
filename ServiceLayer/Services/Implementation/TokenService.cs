using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ModelLayer.Models.User;
using ServiceLayer.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ServiceLayer.Services.Implementation
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key; // ==> this key doesn't leave the server

        // **-- Symmetric Encryption is used when only one key is used to both encrypt and decrypt electronic information --** //
        // **-- ASymmetric Encryption is used when a pair of keys (one public , one private ) are used to encrypt and decrypt electronic information ==> (used in Https and SSL) --** //
        
        public TokenService(IConfiguration config)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }
        // https://galdin.dev/blog/you-dont-need-iconfiguration-outside-startup/
        public string CreateToken(UserModel user)
        {
            var claims = new List<Claim>
            {
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.NameId,user.UserName),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email,user.Email)
            };
            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token); // Check using jwt.io

        }
    }
}
