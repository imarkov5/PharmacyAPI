using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.ObjectPool;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PharmacyAPICardinality.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _config;
        public UserService(DataContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<User> Login(UserDTO request)
        {
            var result = await _context.Users.FirstOrDefaultAsync(u => u.Username.Equals(request.Username));
            if (result == null)
            {
                return null;
            }
            return result;

            //string token = CreateToken(result);
            //return token;


        }
        

        public async Task<User> Register(UserDTO request)
        {
            User newUser = new User();

            string PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            newUser.Username = request.Username;
            newUser.PasswordHash = PasswordHash;
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }
        public async Task<Boolean> ValidateUsername(string UsernameRequest)
        {
            var result = await _context.Users.FirstOrDefaultAsync(u => u.Username.Equals(UsernameRequest));
            if(result != null)
            {
                return false;
            }
            return true;
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>

            {
                new Claim(ClaimTypes.Name, user.Username)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _config.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
