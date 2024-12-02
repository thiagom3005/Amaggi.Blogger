using Amaggi.Blogger.Services;
using Microsoft.AspNetCore.Mvc;

namespace Amaggi.Blogger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;

        public AuthController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string password, string email)
        {
            var user = await _userService.RegisterAsync(username, password, email);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _userService.LoginAsync(username, password);
            if (user == null)
            {
                return Unauthorized();
            }
            return Ok(user);
        }
    }
}