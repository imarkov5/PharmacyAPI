using System.ComponentModel.DataAnnotations;

namespace PharmacyAPICardinality.DTOs
{
    public record struct PrescriptionDTO(
        string PatientName,
        string DrugName, 
        string DrugStrength, 
        string Dosage, 
        string Quantity, 
        int IsDispensed,
        int PharmacyId,
        int PharmacistId);
}
