using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PharmacyAPICardinality.Models
{
    public class Address
    {

        public int Id { get; set; }

        public string Street { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;
        
        public string Zip { get; set; } = string.Empty;
        
        public int PharmacyId { get; set; }
        [JsonIgnore]
        public Pharmacy Pharmacy { get; set; }
        
    }
}
