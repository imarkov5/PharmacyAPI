using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace PharmacyAPICardinality.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private IPharmacyService _pharmacyService;
        private readonly IMapper _mapper;

        public PharmacyController(IPharmacyService pharmacyService, IMapper mapper)
        {
            _pharmacyService = pharmacyService;
            _mapper = mapper;
        }
        

        [HttpPost("add-pharmacy")]
        public async Task<ActionResult<Pharmacy>> AddNewPharmacy(PharmacyRequestDTO request)
        {
            var result = await _pharmacyService.AddPharmacy(request);
            return Ok(_mapper.Map<PharmacyResponseDTO>(result));
        }

        [HttpGet("get-pharmacy/{id}")]
        public async Task<ActionResult<Pharmacy>> GetPharmacy(int id)
        {
            var result = await _pharmacyService.GetPharmacyById(id);
            if(result == null) 
            { 
            return NotFound("Pharmacy is not found");
            }
            return Ok(_mapper.Map<PharmacyResponseDTO>(result));
        }
        
        [HttpGet("get-all-pharmacies")]
        public async Task<ActionResult<List<Pharmacy>>> GetAllPharmacies()
        {
            var result = await _pharmacyService.GetAllPharmacies();
            if(result == null)
            {
                NotFound("No pharmacies in the list");
            }
            return Ok(result.Select(p => _mapper.Map<PharmacyResponseDTO>(p)));
                
        }
        
        [HttpPut("update-pharmacy-name/{id}")]
        public async Task<ActionResult<Pharmacy>> UpdatePharmacyName(int id, PharmacyRequestDTO request)
        {
            var result = await _pharmacyService.UpdatePharmacyName(id, request);
            if(result == null)
            {
                return NotFound("Pharmacy is not found");
            }

            return Ok(_mapper.Map<PharmacyResponseDTO>(result));
        }

        [HttpPut("update-pharmacy-address/{id}")]
        public async Task<ActionResult<Pharmacy>> UpdatePharmacyAddress(int id, PharmacyRequestDTO request)
        {

            var result = await _pharmacyService.UpdatePharmacyAddress(id, request);
            if (result == null)
            {
                return NotFound("Pharmacy is not found");
            }
            return Ok(_mapper.Map<PharmacyResponseDTO>(result));
        }

        [HttpDelete("delete-pharmacy/{id}")]
        public async Task<ActionResult<List<Pharmacy>>> DeletePharmacy(int id)
        {
            var result = await _pharmacyService.DeletePharmacyById(id);
            if(result == null)
            {
                return NotFound("Pharmacy is not found");
            }
            return Ok(result.Select(p => _mapper.Map<PharmacyResponseDTO>(p)));
        }

    }

   
}
