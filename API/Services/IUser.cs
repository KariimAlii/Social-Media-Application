using API.Models;

namespace API.Services
{
    public interface IUser
    {
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<User> GetUserById(int id);
        public void AddUser(User newUser);
        public Task<bool> isUserExists(string UserName, string Email);
        public Task<User> getUserByUserName(string UserName);
    }
}
