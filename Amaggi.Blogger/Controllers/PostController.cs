using Amaggi.Blogger.Services;
using Microsoft.AspNetCore.Mvc;

namespace Amaggi.Blogger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly PostService _postService;

        public PostController(PostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(string title, string content, int userId)
        {
            var post = await _postService.CreatePostAsync(title, content, userId);
            return Ok(post);
        }

        [HttpPut("{postId}")]
        public async Task<IActionResult> EditPost(int postId, string title, string content)
        {
            var post = await _postService.EditPostAsync(postId, title, content);
            return Ok(post);
        }

        [HttpDelete("{postId}")]
        public async Task<IActionResult> DeletePost(int postId)
        {
            await _postService.DeletePostAsync(postId);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _postService.GetAllPostsAsync();
            return Ok(posts);
        }
    }
}
