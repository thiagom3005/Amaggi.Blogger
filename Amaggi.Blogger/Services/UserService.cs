using Amaggi.Blogger.Data;
using Amaggi.Blogger.Entities;
using Amaggi.Blogger.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Amaggi.Blogger.Services
{
    public class UserService : IUserService
    {
        private readonly BlogContext _context;

        public UserService(BlogContext context)
        {
            _context = context;
        }

        public async Task<User> RegisterAsync(string username, string password, string email)
        {
            var user = new User { Username = username, Password = password, Email = email };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }
    }
}