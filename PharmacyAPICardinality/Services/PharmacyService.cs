
namespace PharmacyAPICardinality.Services
{
    public class PharmacyService : IPharmacyService
    {
        private readonly DataContext _dataContext;
        public PharmacyService(DataContext context)
        {
            _dataContext = context;
        }
        public async Task<List<Pharmacy>> AddPharmacy(PharmacyDTO request)
        {
            var newPharmacy = new Pharmacy
            {
                Name = request.Name,
                NumberOfFilledPrescriptions = request.NumberOfFilledPrescriptions,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
            };
            var address = new Address
            {
                Street = request.Address.Street,
                City = request.Address.City,
                State = request.Address.State,
                Zip = request.Address.Zip,
                Pharmacy = newPharmacy
            };

            newPharmacy.PharmacyAddress = address;


            _dataContext.Pharmacy.Add(newPharmacy);
            await _dataContext.SaveChangesAsync();

            return await _dataContext.Pharmacy.Include(p => p.PharmacyAddress).ToListAsync();
        }

        public async Task<List<Pharmacy>?> DeletePharmacyById(int pharmacyId)
        {
            var pharmacy = await _dataContext.Pharmacy
                .Include(p => p.PharmacyAddress)
                .FirstOrDefaultAsync(p => p.Id == pharmacyId);

            if(pharmacy == null) { return null; }

            _dataContext.Pharmacy.Remove(pharmacy);

            await _dataContext.SaveChangesAsync();
            return await _dataContext.Pharmacy.ToListAsync();
        }

        public async Task<List<Pharmacy>> GetAllPharmacies()
        {
            return await _dataContext.Pharmacy
                .Include(p => p.PharmacyAddress)
                .Include(p => p.Prescriptions)
                .ToListAsync();
        }

        public async Task<Pharmacy>? GetPharmacyById(int pharmacyId)
        {
            var pharmacy = await _dataContext.Pharmacy
                .Include(p => p.PharmacyAddress)
                .Include(p => p.Prescriptions)
                .FirstOrDefaultAsync(p => p.Id == pharmacyId);
            if (pharmacy == null)
            {
                return null;
            }
            return pharmacy;
        }

        public async Task<List<Pharmacy>?> UpdatePharmacy(int pharmacyId, PharmacyDTO request)
        {
            var pharmacy = await _dataContext.Pharmacy.FindAsync(pharmacyId);

            if(pharmacy is null)
            {
                return null;
            }
            pharmacy.Name = request.Name;
            pharmacy.UpdatedDate = DateTime.UtcNow;

            await _dataContext.SaveChangesAsync();
            return await _dataContext.Pharmacy.Include(p => p.PharmacyAddress).ToListAsync();
        }
        public async Task<List<Pharmacy>?> UpdatePharmacyAddress(int pharmacyId, PharmacyDTO request)
        {
            var pharmacy = await _dataContext.Pharmacy
                .Include(p => p.PharmacyAddress)
                .FirstOrDefaultAsync(p => p.Id == pharmacyId);

            if (pharmacy is null)
            {
                return null;
            }
            pharmacy.UpdatedDate = DateTime.UtcNow;
            pharmacy.PharmacyAddress.Street = request.Address.Street;
            pharmacy.PharmacyAddress.City = request.Address.City;
            pharmacy.PharmacyAddress.State = request.Address.State;
            pharmacy.PharmacyAddress.Zip = request.Address.Zip;

            await _dataContext.SaveChangesAsync();
            return await _dataContext.Pharmacy.Include(p => p.PharmacyAddress).ToListAsync();
        }
    }
}
