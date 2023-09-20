
namespace PharmacyAPICardinality.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        /*public int AddressId { get; set; }
        public Address Address { get; set; }
        public IList<Prescription> Prescriptions { get; } = new List<Prescription>();*/
    }
}
