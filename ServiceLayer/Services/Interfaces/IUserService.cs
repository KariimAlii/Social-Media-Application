using ModelLayer.Models;

namespace API.Services.Contracts
{
    public interface IUserService
    {
        public Task<List<UserModel>> GetAllUsers();
        public Task<UserModel> GetUserById(int id);
        public Task<int> AddUser(UserModel newUser);
        public Task<bool> isUserExists(string UserName, string Email);
        public Task<UserModel> getUserByUserName(string UserName);
    }
}
