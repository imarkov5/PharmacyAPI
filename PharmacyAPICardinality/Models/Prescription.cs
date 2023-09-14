using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PharmacyAPICardinality.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public string DrugName { get; set; } = string.Empty;
        public string DrugStrength { get; set; } = string.Empty;

        public string Dosage { get; set; } = string.Empty;
        public string Quantity { get; set; } = string.Empty; //string because it can be mL or quantity of capsuls

        public int IsDispensed { get; set; } = 0; // 0 - False; 1 - True


        public int? PharmacyId { get; set; }
        [JsonIgnore]
        public Pharmacy Pharmacy { get; set; } = null!;

        public int? PatientId { get; set; }
        [JsonIgnore]
        public Patient Patient { get; set; } = null!;

        public int? PharmacistId {  get; set; }
        [JsonIgnore]
        public Pharmacist Pharmacist { get; set; } = null!;

       

    }
}
