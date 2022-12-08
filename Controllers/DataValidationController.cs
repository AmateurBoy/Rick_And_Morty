using Microsoft.AspNetCore.Mvc;
using Rick_And_Morty.Convertor;
using Rick_And_Morty.Data;
using Rick_And_Morty.Services;

namespace Rick_And_Morty.Controllers
{
    [ApiController]
    public class DataValidationController : Controller
    {
        readonly Service _service;
        public DataValidationController(Service service)
        {
            _service = service;
        }

        [HttpPost("/api/v1/check-person")]
        public async Task<IActionResult> CheckPerson([FromBody]ComplianceRequest complianceRequest)
        {
            return await this.IsСharacterInTheEpisodeAsync(_service, complianceRequest.personName, complianceRequest.episodeName);
        }
        [HttpGet("/api/v1/person")]
        public async Task<IActionResult> PersonInfo(string name)
        {
            State stateCharacterDTO = await _service.GiveDTObyName(name);
            if (stateCharacterDTO != null)
            {
                if(!stateCharacterDTO.isCacheNull)
                return Json(stateCharacterDTO.characterDTO);
                else
                {
                    return StatusCode(404);
                }
            }
            else
            {
                return StatusCode(404);
            }
        }
        

    }
}
