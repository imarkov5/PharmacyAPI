
namespace PharmacyAPICardinality.Services
{
    public interface IPharmacyService
    {
        Task<List<Pharmacy>> GetAllPharmacies();
        Task<Pharmacy>? GetPharmacyById(int pharmacyId);
        Task<List<Pharmacy>> AddPharmacy(PharmacyDTO request);
        Task<List<Pharmacy>?> UpdatePharmacy(int pharmacyId, PharmacyDTO request);
        Task<List<Pharmacy>?> UpdatePharmacyAddress(int pharmacyId, PharmacyDTO request);
        Task<List<Pharmacy>?> DeletePharmacyById(int pharmacyId);
    }
}
