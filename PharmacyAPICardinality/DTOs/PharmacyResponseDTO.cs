namespace PharmacyAPICardinality.DTOs
{
    public class PharmacyResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfFilledPrescriptions { get; set; }
        public AddressRequestDTO Address { get; set; }
    }
}
