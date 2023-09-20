global using PharmacyAPICardinality.DataValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace PharmacyAPICardinality.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacistController : ControllerBase
    {
        private IPharmacistService _pharmacistService;
        //private PharmacistDataValidation pharmacistDataValidation; 
        public PharmacistController(IPharmacistService pharmacistService)
        {
            _pharmacistService = pharmacistService;
        }
        [HttpPost("add-pharmacist")]
        public async Task<ActionResult<List<Pharmacist>>> AddPharmacist(PharmacistDTO request)
        {
            string ErrorMessage = PharmacistDataValidation.ValidatePharmacistData(request.FirstName, request.LastName);
            if (!ErrorMessage.IsNullOrEmpty())
            {
                return BadRequest(ErrorMessage);
            }
            var result = await _pharmacistService.AddPharmacist(request);
            return Ok(result);
        }
        [HttpGet("get-pharmacist/{id}")]
        public async Task<ActionResult<Pharmacist>> GetPharmacist(int id)
        {
            var result = await _pharmacistService.GetPharmacistById(id);
            if (result == null)
            {
                return NotFound("Pharmacist is not found");
            }
            return Ok(result);
        }
        [HttpGet("get-all-pharmacists")]
        public async Task<ActionResult<List<Pharmacist>>> GetAllPharmacists()
        {
            return await _pharmacistService.GetAllPharmacists();
        }
        [HttpPut("update-pharmacist/{id}")]
        public async Task<ActionResult<List<Pharmacist>>> UpdatePharmacist(int id, PharmacistDTO request)
        {
            string ErrorMessage = PharmacistDataValidation.ValidatePharmacistData(request.FirstName, request.LastName);
            if (!ErrorMessage.IsNullOrEmpty())
            {
                return BadRequest(ErrorMessage);
            }
            var result = await _pharmacistService.UpdatePharmacist(id, request);
            if (result == null)
            {
                return NotFound("Pharmacist is not found");
            }
            return Ok(result);
        }
        
    }
}
