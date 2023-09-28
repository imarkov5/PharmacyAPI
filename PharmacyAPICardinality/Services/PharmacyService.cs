using AutoMapper;

namespace PharmacyAPICardinality.Services
{
    public class PharmacyService : IPharmacyService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public PharmacyService(DataContext context, IMapper mapper)
        {
            _dataContext = context;
            _mapper = mapper;
        }
 
        public async Task<Pharmacy> AddPharmacy(PharmacyRequestDTO request)
        {
            var newPharmacy = _mapper.Map<Pharmacy>(request);

            newPharmacy.NumberOfFilledPrescriptions = 0;
            newPharmacy.CreatedDate = DateTime.Now;
            newPharmacy.UpdatedDate = DateTime.Now;
            

            _dataContext.Pharmacy.Add(newPharmacy);
            await _dataContext.SaveChangesAsync();

            return newPharmacy;
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
            var result = await _dataContext.Pharmacy
                .Include(p => p.PharmacyAddress)
                .ToListAsync();
            if(result.Count == 0)
            {
                return null;
            }
            return result;
        }

        public async Task<Pharmacy>? GetPharmacyById(int pharmacyId)
        {
            var pharmacy = await _dataContext.Pharmacy
                .Include(p => p.PharmacyAddress)
                .FirstOrDefaultAsync(p => p.Id == pharmacyId);
            if (pharmacy == null)
            {
                return null;
            }
           
            return pharmacy;
        }

        public async Task<Pharmacy>? UpdatePharmacyName(int pharmacyId, PharmacyRequestDTO request)
        {
            var pharmacy = await _dataContext.Pharmacy
                .Include(p => p.PharmacyAddress)
                .FirstOrDefaultAsync(p => p.Id == pharmacyId);

            if(pharmacy is null)
            {
                return null;
            }
            pharmacy.Name = request.Name;
            pharmacy.UpdatedDate = DateTime.Now;

            await _dataContext.SaveChangesAsync();
            return pharmacy;
        }
        public async Task<Pharmacy>? UpdatePharmacyAddress(int pharmacyId, PharmacyRequestDTO request)
        {
            var pharmacy = await _dataContext.Pharmacy
                .Include(p => p.PharmacyAddress)
                .FirstOrDefaultAsync(p => p.Id == pharmacyId);

            if (pharmacy is null)
            {
                return null;
            }
            pharmacy.UpdatedDate = DateTime.Now;
            pharmacy.PharmacyAddress.Street = request.Address.Street;
            pharmacy.PharmacyAddress.City = request.Address.City;
            pharmacy.PharmacyAddress.State = request.Address.State;
            pharmacy.PharmacyAddress.Zip = request.Address.Zip;

            await _dataContext.SaveChangesAsync();
            return pharmacy;
        }
    }
}
