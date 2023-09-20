using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
        public async Task<ActionResult<List<Prescription>>> AddNewPrescription(PrescriptionDTO request)
        {
            string ErrorMessage = PrescriptionDataValidation.ValidateAddPrescriptionData(
                request.PatientName,
                request.DrugName,
                request.DrugStrength,
                request.Dosage,
                request.Quantity,
                request.IsDispensed);
            if (!ErrorMessage.IsNullOrEmpty())
            {
                return BadRequest(ErrorMessage);
            }
            var result = await _prescriptionService.AddPrescription(request);
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
        public async Task<ActionResult<List<Prescription>>> UpdatePrescription(int id, PrescriptionDTO request)
        {
            string ErrorMessage = PrescriptionDataValidation.ValidateUpdatePrescriptionData(request.IsDispensed);
            if (!ErrorMessage.IsNullOrEmpty())
            {
                return BadRequest(ErrorMessage);
            }
            var result = await _prescriptionService.UpdatePrescription(id, request);
            if(result == null)
            {
                return NotFound("Prescription is not found");
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
