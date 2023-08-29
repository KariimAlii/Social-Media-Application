
using ModelLayer.Models;

namespace ServiceLayer.Services.Interfaces
{
    public interface ITokenService
    {
        public string CreateToken(UserModel user);
    }
}
