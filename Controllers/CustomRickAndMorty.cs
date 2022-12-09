using Microsoft.AspNetCore.Mvc;
using Rick_And_Morty.Convertor;
using Rick_And_Morty.Services;

namespace Rick_And_Morty.Controllers
{
    [ApiController]
    public class CustomRickAndMorty : Controller
    {
        readonly Service _service;
        public CustomRickAndMorty(Service service)
        {
            _service = service;
        }

        [HttpPost("/api/v1/check-person")]
        public async Task<IActionResult> CheckPerson([FromBody]ComplianceRequest complianceRequest)
        {
            try
            {
                return Json(await _service.IsValidationData(complianceRequest.personName, complianceRequest.episodeName));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("/api/v1/person")]
        public async Task<IActionResult> PersonInfo(string name)
        {
            return Ok();            
        }
        

    }
}
