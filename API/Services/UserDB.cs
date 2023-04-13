using API.Data;
using API.Models;
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

    }
}
