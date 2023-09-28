using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace PharmacyAPICardinality.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    

    public class AuthController : ControllerBase
    {
        private IUserService _userService;
        private readonly IMapper _mapper;
        public AuthController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserRequestDTO request)
        {
            if (!await _userService.IsUniqueUsername(request.Username))
            {
                return BadRequest($"Username {request.Username} already exists. Try again");
            }
            
            var result = await _userService.Register(request);
            
            return Ok(_mapper.Map<UserResponseDTO>(result));
        }
        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(UserRequestDTO request)
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
            return Ok(_mapper.Map<UserResponseDTO>(result));
        }
        
    }
}
