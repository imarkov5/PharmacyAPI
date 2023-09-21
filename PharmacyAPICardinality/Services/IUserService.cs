using PharmacyAPICardinality.DTOs;

namespace PharmacyAPICardinality.Services
{
    public interface IUserService
    {
        Task<User> Register(UserDTO userDTO);
        Task<User> Login(UserDTO userDTO);
        Task<Boolean> ValidateUsername(string UsernameRequest);
    }
}
