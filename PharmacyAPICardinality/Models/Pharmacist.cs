
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PharmacyAPICardinality.Models
{
    public class Pharmacist
    {
        public int Id { get; set; }
        [MinLength(1), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First Name must consist of letters only.")]
        public string FirstName { get; set; } = string.Empty;

        [MinLength(1), RegularExpression(@"^[a-zA-Z,.\s-]+$", ErrorMessage = "Last Name must consist of letters and can include commas, periods and hyphens.")]
        public string LastName { get; set; } = string.Empty;

        public IList<Prescription>? Prescriptions { get; } = new List<Prescription>();

    }
}
