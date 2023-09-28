namespace PharmacyAPICardinality.Services
{
    public interface IPrescriptionService
    {
        Task<List<Prescription>> GetAllPrescriptions();
        Task<Prescription>? GetPrescriptionById(int prescriptionId);
        Task<Prescription> AddPrescription(PrescriptionRequestDTO request);
        Task<Prescription>? UpdatePrescription(int prescriptionId, PrescriptionRequestDTO request);
        //Task<List<Prescription>?> DeletePrescriptionById(int prescriptionId);
    }
}
