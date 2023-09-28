using System.ComponentModel.DataAnnotations;

namespace PharmacyAPICardinality.DTOs
{
    public class AddressRequestDTO
    {
        [MinLength(5), MaxLength(50)]
        public required string Street {  get; set; }

        [RegularExpression(@"^[A-Za-z',.\s-]{1,50}$", ErrorMessage ="City can include commas, periods and hyphens with max lengths of 50")]
        public required string City { get; set; }
        
        [RegularExpression(@"^[A-Za-z]{2}$", ErrorMessage = "Please enter 2-letter state abbreviation")]
        public required string State { get; set; }

        [RegularExpression(@"^[0-9]{5}(?:-[0-9]{4})?$", ErrorMessage = "Please enter a valid US zip code.")]
        public required string Zip {  get; set; }
    }

}
