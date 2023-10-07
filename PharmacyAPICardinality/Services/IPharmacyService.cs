
namespace PharmacyAPICardinality.Services
{
    public interface IPharmacyService
    {
        Task<List<Pharmacy>> GetAllPharmacies();
        Task<Pharmacy>? GetPharmacyById(int pharmacyId);
        Task<Pharmacy> AddPharmacy(PharmacyRequestDTO request);
        Task<Pharmacy>? UpdatePharmacy(int pharmacyId, PharmacyRequestDTO request);
        Task<List<Pharmacy>?> DeletePharmacyById(int pharmacyId);
    }
}
