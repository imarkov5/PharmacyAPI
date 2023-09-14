namespace PharmacyAPICardinality.DTOs
{
    public record struct PrescriptionDTO(string DrugName, string DrugStrength, string Dosage, string Quantity, int IsDispensed);
}
