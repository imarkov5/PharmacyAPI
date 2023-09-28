using Microsoft.AspNetCore.Mvc;

namespace PharmacyAPICardinality.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacistController : ControllerBase
    {
        private IPharmacistService _pharmacistService;
        public PharmacistController(IPharmacistService pharmacistService)
        {
            _pharmacistService = pharmacistService;
        }
        [HttpPost("add-pharmacist")]
        public async Task<ActionResult<Pharmacist>> AddPharmacist(Pharmacist request)
        {
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
        public async Task<ActionResult<Pharmacist>> UpdatePharmacist(int id, Pharmacist request)
        {
            var result = await _pharmacistService.UpdatePharmacist(id, request);
            if (result == null)
            {
                return NotFound("Pharmacist is not found");
            }
            return Ok(result);
        }
        
    }
}
