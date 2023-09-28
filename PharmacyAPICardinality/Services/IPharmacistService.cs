namespace PharmacyAPICardinality.Services
{
    public interface IPharmacistService
    {
        Task<List<Pharmacist>> GetAllPharmacists();
        Task<Pharmacist>? GetPharmacistById(int PharmacistId);
        Task<Pharmacist> AddPharmacist(Pharmacist request);
        Task<Pharmacist>? UpdatePharmacist(int PharmacistId, Pharmacist request);
    }
}
