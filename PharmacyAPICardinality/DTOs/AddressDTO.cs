namespace PharmacyAPICardinality.DTOs
{
    public record struct AddressDTO(
        string Street, 
        string City, 
        string State, 
        string Zip);
}
