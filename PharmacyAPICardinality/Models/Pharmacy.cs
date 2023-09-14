using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PharmacyAPICardinality.Models
{
    public class Pharmacy
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int NumberOfFilledPrescriptions { get; set; }

        public DateTime CreatedDate {  get; set; } = DateTime.Now;

        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        [JsonIgnore]
        public PharmacyAddress PharmacyAddress{ get; set; } = new PharmacyAddress();
        [JsonIgnore]
        public IList<Prescription>? Prescriptions { get; set; } = new List<Prescription>();
    }
}
