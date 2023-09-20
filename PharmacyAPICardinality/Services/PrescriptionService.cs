
namespace PharmacyAPICardinality.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly DataContext _dataContext;
        public PrescriptionService(DataContext context)
        {
            _dataContext = context;
        }
        public async Task<List<Prescription>> AddPrescription(PrescriptionDTO request)
        {
            var newPrescription = new Prescription() 
            {
                PatientName = request.PatientName,
                DrugName = request.DrugName,
                DrugStrength = request.DrugStrength,
                Dosage = request.Dosage,
                Quantity = request.Quantity,
                IsDispensed = request.IsDispensed,
                DispensedDate = request.IsDispensed == 1 ? DateTime.UtcNow : null,
                PharmacistId = request.PharmacistId,
                PharmacyId = request.PharmacyId,
            };
            _dataContext.Prescription.Add(newPrescription);
            await _dataContext.SaveChangesAsync();
            return await _dataContext.Prescription.ToListAsync();
        }

        public async Task<List<Prescription>?> DeletePrescriptionById(int prescriptionId)
        {
            var prescription = await _dataContext.Prescription.FirstOrDefaultAsync(p => p.Id == prescriptionId);
            if (prescription == null) { return null; }

            _dataContext.Prescription.Remove(prescription);

            await _dataContext.SaveChangesAsync();
            return await _dataContext.Prescription.ToListAsync();
        }

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

        public async Task<List<Prescription>?> UpdatePrescription(int prescriptionId, PrescriptionDTO request)
        {
            var prescription = await _dataContext.Prescription.FindAsync(prescriptionId);

            if (prescription is null)
            {
                return null;
            }
            prescription.IsDispensed = request.IsDispensed;
            prescription.DispensedDate = request.IsDispensed == 1 ? DateTime.UtcNow : null;
            prescription.PharmacistId = request.PharmacistId;

            await _dataContext.SaveChangesAsync();
            return await _dataContext.Prescription.ToListAsync();

        }
    }
}
