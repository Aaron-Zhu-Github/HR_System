namespace AuthService.Controllers
{
    using AuthService.DAO;
    using AuthService.Model;
    using AuthService.Util;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly AuthDbContext _authDbContext;
        private readonly IJwtUtils _jwtUtils;

        public AuthController(IConfiguration configuration, AuthDbContext authDbContext, IJwtUtils jwtUtils)
        {
            _configuration = configuration;
            _authDbContext = authDbContext;
            _jwtUtils = jwtUtils;
        }

        [HttpPost("/Login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Unauthorized();
            }

            User? user = _authDbContext.User.Include(u => u.UserRole)
                                            .ThenInclude(ur => ur.Role)
                                            .ThenInclude(r => r.RolePermission)
                                            .ThenInclude(rp => rp.Permission)
                                            .FirstOrDefault(u => u.Username == request.Username && u.Password == request.Password);

            // Validate the username and password
            if (user is not null)
            {
                string accessToken = _jwtUtils.GenerateToken(user);
                if (accessToken is null or "")
                { return BadRequest(); }
                // Return the access token
                return Ok(new { Message = "Successfully Authenticated", AccessToken = accessToken });
            }

            // Return an error if the username and password are invalid
            return Unauthorized();
        }
    }
}
