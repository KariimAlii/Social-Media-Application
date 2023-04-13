using API.Models;

namespace API.Services
{
    public interface IUser
    {
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<User> GetUserById(int id);
    }
}
