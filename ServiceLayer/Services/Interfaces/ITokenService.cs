using ModelLayer.Models.User;

namespace ServiceLayer.Services.Interfaces
{
    public interface ITokenService
    {
        public string CreateToken(UserModel user);
    }
}
