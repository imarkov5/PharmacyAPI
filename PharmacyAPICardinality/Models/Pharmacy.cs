using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PharmacyAPICardinality.Models
{
    public class Pharmacy
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int NumberOfFilledPrescriptions { get; set; } = 0;
        public DateTime CreatedDate {  get; set; } = DateTime.Now;

        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        [JsonIgnore]
        public Address PharmacyAddress{ get; set; } = new Address();
        [JsonIgnore]
        public IList<Prescription> Prescriptions { get; } = new List<Prescription>();
    }
}
