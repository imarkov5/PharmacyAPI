
namespace PharmacyAPICardinality.Models
{
    public class Pharmacist
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        //[MaxLength(5)]
        public string LastName { get; set; } = string.Empty;

        public IList<Prescription>? Prescriptions { get; } = new List<Prescription>();

    }
}
