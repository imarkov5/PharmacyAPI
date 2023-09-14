﻿namespace PharmacyAPICardinality.DTOs
{
    public record struct PharmacyDTO(
        string Name, 
        int NumberOfFilledPrescriptions, 
        DateTime CreatedDate, 
        DateTime UpdatedDate, 
        PharmacyAddressDTO Address, 
        List<PrescriptionDTO> Prescriptions);
}
