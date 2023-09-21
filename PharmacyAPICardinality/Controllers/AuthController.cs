using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PharmacyAPICardinality.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDTO request)
        {
            Boolean IsUniqueUsername = await _userService.ValidateUsername(request.Username);
            if (!IsUniqueUsername)
            {
                return BadRequest($"Username {request.Username} already exists. Try again");
            }
            var result = await _userService.Register(request);
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(UserDTO request)
        {
            var result = await _userService.Login(request);
            if (result == null)
            {
                return BadRequest("User not found");
            }
            if (!BCrypt.Net.BCrypt.Verify(request.Password, result.PasswordHash))
            {
                return BadRequest("Wrong password");
            }
            return Ok(result);
            
            //return Ok(token);
        }
    }
}
