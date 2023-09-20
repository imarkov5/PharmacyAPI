namespace PharmacyAPICardinality.Services
{
    public interface IPharmacistService
    {
        Task<List<Pharmacist>> GetAllPharmacists();
        Task<Pharmacist>? GetPharmacistById(int PharmacistId);
        Task<List<Pharmacist>> AddPharmacist(PharmacistDTO request);
        Task<List<Pharmacist>?> UpdatePharmacist(int PharmacistId, PharmacistDTO request);
    }
}
