using Microsoft.AspNetCore.Mvc;
using Rick_And_Morty.DTO;
using Rick_And_Morty.Services;
using System.Collections;
using System.Net;

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
            DTO.StatusCode status = await requestAPI.IsСharacterInTheEpisode(complianceRequest.personName, complianceRequest.episodeName);
            switch (status)
            {
                case DTO.StatusCode.OK:
                    return Json(true);                    
                case DTO.StatusCode.NameNotCorrect:
                    return Json(false);                    
                case DTO.StatusCode.Error:
                    return StatusCode(404);                    
                default:
                    return Json("Unhandled Exception");                    
            }
        }
        [HttpGet("/api/v1/person")]
        public async Task<IActionResult> Person(string name)
        {
            CharacterDTO characterDTO = await requestAPI.GiveDTObyName(name);
            if (characterDTO!=null) return Json(characterDTO);
            else
            {
                return StatusCode(404);
            }
        }

    }
}
