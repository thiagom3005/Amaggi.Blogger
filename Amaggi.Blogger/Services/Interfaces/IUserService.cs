using Amaggi.Blogger.Entities;

namespace Amaggi.Blogger.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> RegisterAsync(string username, string password, string email);
        Task<User> LoginAsync(string username, string password);
    }
}
