using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PharmacyAPICardinality.Models
{
    public class Address
    {
        public int Id { get; set; }

        //[Required, MinLength(5), MaxLength(30)]
        public string Street { get; set; } = string.Empty;

        //[RegularExpression(@"[A - Za - z\s\-]")] //Match at least one alpha character and allow spaces and dashes for the city
        public string City { get; set; } = string.Empty;
        
        //[RegularExpression(@"[A-Za-z]{2}")]
        public string State { get; set; } = string.Empty;
        
        //[RegularExpression(@"^[0-9]{5}(?:-[0-9]{4})?$", ErrorMessage = "Please enter a valid US zip code.")]
        public string Zip { get; set; } = string.Empty;
        
        public int PharmacyId { get; set; }
        [JsonIgnore]
        public Pharmacy Pharmacy { get; set; }
        
    }
}
