using Amaggi.Blogger.Data;
using Amaggi.Blogger.Entities;
using Amaggi.Blogger.Notifications;
using Microsoft.EntityFrameworkCore;

namespace Amaggi.Blogger.Services
{
    public class PostService
    {
        private readonly BlogContext _context;
        private readonly NotificationService _notificationService;

        public PostService(BlogContext context, NotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<Post> CreatePostAsync(string title, string content, int userId)
        {
            var post = new Post { Title = title, Content = content, CreatedAt = DateTime.UtcNow, UserId = userId };
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            await _notificationService.NotifyAllAsync($"New post created: {title}");
            return post;
        }

        public async Task<Post> EditPostAsync(int postId, string title, string content)
        {
            var post = await _context.Posts.FindAsync(postId);
            if (post != null)
            {
                post.Title = title;
                post.Content = content;
                await _context.SaveChangesAsync();
            }
            return post;
        }

        public async Task DeletePostAsync(int postId)
        {
            var post = await _context.Posts.FindAsync(postId);
            if (post != null)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Post>> GetAllPostsAsync()
        {
            return await _context.Posts.Include(p => p.User).ToListAsync();
        }
    }
}
