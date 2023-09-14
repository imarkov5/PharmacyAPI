using Azure.Core;

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
            var address = new PharmacyAddress
            {
                Street = request.Address.Street,
                City = request.Address.City,
                State = request.Address.State,
                Zip = request.Address.Zip,
                Pharmacy = newPharmacy
            };

            var prescriptions = request.Prescriptions.Select(rx => new Prescription
            {
                DrugName = rx.DrugName,
                DrugStrength = rx.DrugStrength,
                Dosage = rx.Dosage,
                Quantity = rx.Quantity,
                IsDispensed = rx.IsDispensed,
                Pharmacy = newPharmacy

            }).ToList();

            newPharmacy.PharmacyAddress = address;
            newPharmacy.Prescriptions = prescriptions;

            _dataContext.Pharmacies.Add(newPharmacy);
            await _dataContext.SaveChangesAsync();

            return await _dataContext.Pharmacies.Include(p => p.PharmacyAddress).Include(p => p.Prescriptions).ToListAsync();
        }

        public async Task<List<Pharmacy>?> DeletePharmacyById(int pharmacyId)
        {
            var pharmacy = await _dataContext.Pharmacies
                .Include(p => p.PharmacyAddress)
                .Include(p => p.Prescriptions)
                .FirstOrDefaultAsync(p => p.Id == pharmacyId);

            if(pharmacy == null) { return null; }

            _dataContext.Pharmacies.Remove(pharmacy);

            await _dataContext.SaveChangesAsync();
            return await _dataContext.Pharmacies.ToListAsync();
        }

        public async Task<List<Pharmacy>> GetAllPharmacies()
        {
            return await _dataContext.Pharmacies
                .Include(p => p.PharmacyAddress)
                .Include(p => p.Prescriptions)
                .ToListAsync();
        }

        public async Task<Pharmacy>? GetPharmacyById(int pharmacyId)
        {
            var pharmacy = await _dataContext.Pharmacies
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
            var pharmacy = await _dataContext.Pharmacies.FindAsync(pharmacyId);

            if(pharmacy is null)
            {
                return null;
            }
            pharmacy.Name = request.Name;
            pharmacy.UpdatedDate = DateTime.UtcNow;

            await _dataContext.SaveChangesAsync();
            return await _dataContext.Pharmacies.Include(p => p.PharmacyAddress).Include(p => p.Prescriptions).ToListAsync();
        }
        public async Task<List<Pharmacy>?> UpdatePharmacyAddress(int pharmacyId, PharmacyDTO request)
        {
            var pharmacy = await _dataContext.Pharmacies
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
            return await _dataContext.Pharmacies.Include(p => p.PharmacyAddress).Include(p => p.Prescriptions).ToListAsync();
        }
    }
}
