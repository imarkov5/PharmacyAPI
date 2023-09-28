﻿
namespace PharmacyAPICardinality.Services
{
    public class PharmacistService : IPharmacistService
    {
        private readonly DataContext _dataContext;

        public PharmacistService(DataContext context)
        {
            _dataContext = context;
        }
        public async Task<Pharmacist> AddPharmacist(Pharmacist request)
        {

            var newPharmacist = new Pharmacist
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
            };
            _dataContext.Pharmacist.Add(newPharmacist);
            await _dataContext.SaveChangesAsync();
            return newPharmacist;
        }

        public async Task<List<Pharmacist>> GetAllPharmacists()
        {
            return await _dataContext.Pharmacist.ToListAsync();
        }

        public async Task<Pharmacist>? GetPharmacistById(int PharmacistId)
        {
            var pharmacist = await _dataContext.Pharmacist.FindAsync(PharmacistId);
            if(pharmacist == null)
            {
                return null;
            }
            return pharmacist;
        }

        public async Task<Pharmacist>? UpdatePharmacist(int PharmacistId, Pharmacist request)
        {
            var pharmacist = await _dataContext.Pharmacist.FindAsync(PharmacistId);
            if(pharmacist == null)
            {
                return null;
            }
            pharmacist.FirstName = request.FirstName;
            pharmacist.LastName = request.LastName;
            await _dataContext.SaveChangesAsync();
            return pharmacist;
        }
    }
}
