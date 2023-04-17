using API.Models;

namespace API.Services.Contracts
{
    public interface ITokenService
    {
        public string CreateToken(User user);
    }
}
