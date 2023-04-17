using API.Data;
using API.Models;
using API.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class UserDB : IUser
    {
        DataContext context;
        public UserDB(DataContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<User>>  GetAllUsers()
        {
            //return context.Users.ToListAsync().Result;
            return await context.Users.ToListAsync();
        }
        public async Task<User> GetUserById (int id)
        {
            return await context.Users.FindAsync(id);
        }
        public async void AddUser(User newUser)
        {
            await context.Users.AddAsync(newUser);
            await context.SaveChangesAsync();
        }
        public async Task<bool> isUserExists(string UserName,string Email)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.UserName == UserName.ToLower() || u.Email == Email.ToLower());
            if (user == null) return false;
            else return true;
        }
        public async Task<User> getUserByUserName(string UserName)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.UserName == UserName);
            return user;
        }
    }
}
