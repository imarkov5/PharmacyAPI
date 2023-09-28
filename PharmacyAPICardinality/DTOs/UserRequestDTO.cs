using System.ComponentModel.DataAnnotations;

namespace PharmacyAPICardinality.DTOs
{
    public class UserRequestDTO
    {
        [MinLength(3, ErrorMessage = "Minimum length is 3 charachters")]
        public required string Username { get; set; }
        [MinLength(5, ErrorMessage = "Minimum length is 5 charachters")]
        public required string Password { get; set; }
    }
}
