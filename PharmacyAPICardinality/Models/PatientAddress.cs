using System.Text.Json.Serialization;

namespace PharmacyAPICardinality.Models
{
    public class PatientAddress
    {
        public int Id { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;

        public ICollection<Patient> Patients { get; set; } = new List<Patient>();
    }
}
