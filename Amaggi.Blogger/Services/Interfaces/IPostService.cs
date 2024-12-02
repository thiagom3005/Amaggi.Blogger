using Amaggi.Blogger.Entities;

namespace Amaggi.Blogger.Services.Interfaces
{
    public interface IPostService
    {
        Task<Post> CreatePostAsync(string title, string content, int userId);
        Task<Post> EditPostAsync(int postId, string title, string content);
        Task DeletePostAsync(int postId);
        Task<List<Post>> GetAllPostsAsync();
    }
}
