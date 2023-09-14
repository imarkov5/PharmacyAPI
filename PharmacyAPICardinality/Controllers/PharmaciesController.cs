using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace PharmacyAPICardinality.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmaciesController : ControllerBase
    {
        private IPharmacyService _pharmacyService;

        public PharmaciesController(IPharmacyService pharmacyService)
        {
            _pharmacyService = pharmacyService;
        }
        [HttpPost("add-pharmacy")]
        public async Task<ActionResult<List<Pharmacy>>> AddNewPharmacy(PharmacyDTO request)
        {
            var result = await _pharmacyService.AddPharmacy(request);
            return Ok(result);
            
        }

        [HttpGet("get-pharmacy/{id}")]
        public async Task<ActionResult<Pharmacy>> GetPharmacy(int id)
        {
            var result = await _pharmacyService.GetPharmacyById(id);
            if(result == null) 
            { 
            return NotFound("Pharmacy is not found");
            }
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<List<Pharmacy>>> GetAllPharmacies()
        {
            return await _pharmacyService.GetAllPharmacies();
        }
        [HttpPut("update-pharmacy/{id}")]
        public async Task<ActionResult<List<Pharmacy>>> UpdatePharmacy(int id, PharmacyDTO request)
        {
            var result = await _pharmacyService.UpdatePharmacy(id, request);
            if(result == null)
            {
                return NotFound("Pharmacy is not found");
            }
            return Ok(result);
        }
        [HttpPut("update-pharmacy-address/{id}")]
        public async Task<ActionResult<List<Pharmacy>>> UpdatePharmacyAddress(int id, PharmacyDTO request)
        {
            var result = await _pharmacyService.UpdatePharmacyAddress(id, request);
            if (result == null)
            {
                return NotFound("Pharmacy is not found");
            }
            return Ok(result);
        }
        [HttpDelete("delete-pharmacy/{id}")]
        public async Task<ActionResult<List<Pharmacy>>> DeletePharmacy(int id)
        {
            var result = await _pharmacyService.DeletePharmacyById(id);
            if(result == null)
            {
                return NotFound("Pharmacy is not found");
            }
            return Ok(result);
        }

    }

   
}
