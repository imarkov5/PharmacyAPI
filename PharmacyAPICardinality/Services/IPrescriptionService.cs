namespace PharmacyAPICardinality.Services
{
    public interface IPrescriptionService
    {
        Task<List<Prescription>> GetAllPrescriptions();
        Task<Prescription>? GetPrescriptionById(int prescriptionId);
        Task<List<Prescription>> AddPrescription(PrescriptionDTO request);
        Task<List<Prescription>?> UpdatePrescription(int prescriptionId, PrescriptionDTO request);
        Task<List<Prescription>?> DeletePrescriptionById(int prescriptionId);
    }
}
