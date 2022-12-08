using Microsoft.AspNetCore.Mvc;
using Rick_And_Morty.Convertor;
using Rick_And_Morty.Data;
using Rick_And_Morty.Services;

namespace Rick_And_Morty.Controllers
{
    [ApiController]
    public class DataValidationController : Controller
    {
        readonly RequestHandlerAPI requestAPI;
        public DataValidationController(RequestHandlerAPI requestHandlerAPI)
        {
            requestAPI = requestHandlerAPI;
        }

        [HttpPost("/api/v1/check-person")]
        public async Task<IActionResult> CheckPerson([FromBody]ComplianceRequest complianceRequest)
        {
            StatusCode status = await requestAPI.IsСharacterInTheEpisode(complianceRequest.personName, complianceRequest.episodeName);
            switch (status)
            {
                case Services.StatusCode.OK:
                    return Json(true);                    
                case Services.StatusCode.NameNotCorrect:
                    return Json(false);                    
                case Services.StatusCode.Error:
                    return StatusCode(404);                    
                default:
                    return Json("Unhandled Exception");                    
            }
        }
        [HttpGet("/api/v1/person")]
        public async Task<IActionResult> Person(string name)
        {
            State stateCharacterDTO = await requestAPI.GiveDTObyName(name);
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
