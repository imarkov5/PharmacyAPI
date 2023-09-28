using System.ComponentModel.DataAnnotations;

namespace PharmacyAPICardinality.DTOs
{
    public class PrescriptionRequestDTO
    {
        [MinLength(1), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First Name must consist of letters only.")]
        public required string PatientFirstName { get; set; }
        [MinLength(1), RegularExpression(@"^[a-zA-Z,.\s-]+$", ErrorMessage = "Last Name must consist of letters and can include commas, periods and hyphens.")]
        public required string PatientLastName { get; set; }
        [MinLength(2)]
        public required string DrugName { get; set; }
        [MinLength(2)]
        public required string DrugStrength { get; set; }
        [MinLength(2)]
        public required string Dosage { get; set;}
        [MinLength(2)]
        public required string Quantity { get; set;}
        [Range(0, 1, ErrorMessage = "Enter 0 if prescription is not filled, 1 if it's filled")]
        public required int IsDispensed { get; set; } = 0;
        public required int PharmacyId  {get; set;}
        public int? PharmacistId { get; set; }
    }

}
