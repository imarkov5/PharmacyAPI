

namespace PharmacyAPICardinality.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly DataContext _dataContext;
        public PrescriptionService(DataContext context)
        {
            _dataContext = context;
        }
        public async Task<Prescription> AddPrescription(PrescriptionRequestDTO request)
        {
            var pharmacy = await _dataContext.Pharmacy.FindAsync(request.PharmacyId);
            
            if (pharmacy == null)
            {
                return null;
            }
            
            if (request.IsDispensed == 1 && request.PharmacistId == null)
            {
                return null;
            }
            
            if (request.PharmacistId != null)
            {
                var pharmacist = await _dataContext.Pharmacist.FindAsync(request.PharmacistId);
                if (pharmacist == null)
                {
                    return null;
                }
            }

            var newPrescription = new Prescription() 
            {
                PatientFirstName = request.PatientFirstName,
                PatientLastName = request.PatientLastName,
                DrugName = request.DrugName,
                DrugStrength = request.DrugStrength,
                Dosage = request.Dosage,
                Quantity = request.Quantity,
                IsDispensed = request.IsDispensed,
                DispensedDate = request.IsDispensed == 1 ? DateTime.Now : null,
                PharmacistId = request.PharmacistId,
                PharmacyId = request.PharmacyId,
            };
            
            if (newPrescription.IsDispensed == 1 ) 
            {
                pharmacy.NumberOfFilledPrescriptions += 1; ;
            }

            _dataContext.Prescription.Add(newPrescription);
            await _dataContext.SaveChangesAsync();

            return newPrescription;
        }

        /*public async Task<List<Prescription>?> DeletePrescriptionById(int prescriptionId)
        {
            var prescription = await _dataContext.Prescription.FirstOrDefaultAsync(p => p.Id == prescriptionId);
            if (prescription == null) { return null; }

            _dataContext.Prescription.Remove(prescription);

            await _dataContext.SaveChangesAsync();
            return await _dataContext.Prescription.ToListAsync();
        }*/

        public async Task<List<Prescription>> GetAllPrescriptions()
        {
            return await _dataContext.Prescription.ToListAsync() ?? new List<Prescription>();
        }

        public async Task<Prescription>? GetPrescriptionById(int prescriptionId)
        {
            var prescription = await _dataContext.Prescription.FindAsync(prescriptionId);
            if (prescription == null)
            {
                return null;
            }
            return prescription;
        }

        public async Task<Prescription>? UpdatePrescription(int prescriptionId, PrescriptionRequestDTO request)
        {
            var prescription = await _dataContext.Prescription.FindAsync(prescriptionId);

            if (prescription is null)
            {
                return null;
            }

            if (request.IsDispensed == 1 && request.PharmacistId == null)
            {
                return null;
            }

            if (request.PharmacistId != null)
            {
                var pharmacist = await _dataContext.Pharmacist.FindAsync(request.PharmacistId);
                if (pharmacist == null)
                {
                    return null;
                }
            }
            
            var pharmacy = await _dataContext.Pharmacy.FindAsync(prescription.PharmacyId);
            
            if(prescription.IsDispensed == 0 && request.IsDispensed == 1)
            {
                pharmacy.NumberOfFilledPrescriptions += 1;
                prescription.DispensedDate = DateTime.Now;
            }
            if (prescription.IsDispensed == 1 && request.IsDispensed == 0)
            {
                pharmacy.NumberOfFilledPrescriptions -= 1;
                prescription.DispensedDate = null;
            }

            prescription.IsDispensed = request.IsDispensed;
            prescription.PharmacistId = request.PharmacistId;
            
            await _dataContext.SaveChangesAsync();
            return prescription;

        }

    }
}
