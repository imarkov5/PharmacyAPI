using PharmacyAPICardinality.DTOs;

namespace PharmacyAPICardinality.Services
{
    public interface IUserService
    {
        Task<User> Register(UserRequestDTO userDTO);
        Task<User> Login(UserRequestDTO userDTO);
        Task<Boolean> IsUniqueUsername(string UsernameRequest);
    }
}
