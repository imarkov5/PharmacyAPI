using Microsoft.AspNetCore.Mvc;

namespace PharmacyAPICardinality.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private IPrescriptionService _prescriptionService;
        public PrescriptionController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }
        
        
        [HttpPost("add-prescription")]
        public async Task<ActionResult<Prescription>> AddNewPrescription(PrescriptionRequestDTO request)
        {
            var result = await _prescriptionService.AddPrescription(request);

            if(result == null)
            {
                return BadRequest("Check if Pharmacy and Pharmacist exist and if IsDispensed = 1, Pharmacist Id must be entered.");
            }
            return Ok(result);
        }

        [HttpGet("get-prescription/{id}")]
        public async Task<ActionResult<Prescription>> GetPrescriptionById(int id)
        {
            var result = await _prescriptionService.GetPrescriptionById(id);
            
            if (result == null)
            {
                return NotFound("Prescription is not found");
            }
            return Ok(result);
        }
        
        [HttpGet("get-all-prescriptions")]
        public async Task<ActionResult<List<Prescription>>> GetAllPrescriptions()
        {
            return await _prescriptionService.GetAllPrescriptions();
        }
        
        [HttpPut("update-prescription/{id}")]
        public async Task<ActionResult<Prescription>> UpdatePrescription(int id, PrescriptionRequestDTO request)
        {
            var result = await _prescriptionService.UpdatePrescription(id, request);
            
            if(result == null)
            {
                return BadRequest("If IsDispened = 1, pharmacist can't be null. If Pharamcist not null, check if exists");
            }
            return Ok(result);
        }
        /*[HttpDelete("delete-prescription/{id}")]
        public async Task<ActionResult<List<Prescription>>> DeletePrescription(int id)
        {
            var result = await _prescriptionService.DeletePrescriptionById(id);
            if(result == null)
            {
                return NotFound("Prescription is not found");
            }
            return Ok(result);
        }*/
        
    }
}
