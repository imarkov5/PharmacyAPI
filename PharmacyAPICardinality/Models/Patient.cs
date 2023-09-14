using System.Text.Json.Serialization;

namespace PharmacyAPICardinality.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public int? PatientAddressId { get; set; }
        public PatientAddress Address { get; set; } = null!;
        public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    }
}
