
using System.ComponentModel.DataAnnotations;

namespace PharmacyAPICardinality.DTOs
{
    public class PharmacyRequestDTO
    {
        [MinLength(1, ErrorMessage ="Name field can't be empty")]
        public required string Name { get; set; }
        public required AddressRequestDTO Address { get; set; }
    }
        
}
