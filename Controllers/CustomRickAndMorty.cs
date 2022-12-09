using Microsoft.AspNetCore.Mvc;
using Rick_And_Morty.Convertor;
using Rick_And_Morty.Services;

namespace Rick_And_Morty.Controllers
{
    [ApiController]
    public class CustomRickAndMorty : Controller
    {
        readonly Service service;
        public CustomRickAndMorty(Service service)
        {
            this.service = service;
        }

        [HttpPost("/api/v1/check-person")]
        public async Task<IActionResult> CheckPerson([FromBody]ComplianceRequest complianceRequest)
        {
            try
            {
                return Json(await service.IsValidationDataAsync(complianceRequest.personName, complianceRequest.episodeName));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("/api/v1/person")]
        public async Task<IActionResult> PersonInfo(string name)
        {
            try
            {
                return Json(await service.GetCharacterbyNameAsync(name));
            }
            catch
            {
                return NotFound();
            }         
        }
        

    }
}
