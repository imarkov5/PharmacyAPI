
using System.Text.Json.Serialization;

namespace PharmacyAPICardinality.Models
{
    public class Prescription
    {
        public int Id { get; set; }

        public string PatientName { get; set; } = string.Empty;
        public string DrugName { get; set; } = string.Empty;
        public string DrugStrength { get; set; } = string.Empty;
        public string Dosage { get; set; } = string.Empty;
        public string Quantity { get; set; } = string.Empty; //string because it can be mL or quantity of capsuls

        public int IsDispensed { get; set; } = 0; // 0 - False; 1 - True

        public DateTime? DispensedDate { get; set; }


        public int PharmacyId { get; set; }
        [JsonIgnore]
        public Pharmacy Pharmacy { get; set; }

        public int? PharmacistId { get; set; }
        [JsonIgnore]
        public Pharmacist Pharmacist { get; set; }

        /*public int? PatientId { get; set; }
        [JsonIgnore]
        public Patient Patient { get; set; }*/



    }
}
