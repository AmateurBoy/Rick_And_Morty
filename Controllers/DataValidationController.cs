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
        RequestHandlerAPI requestAPI = new RequestHandlerAPI();

        [HttpPost("/api/v1/check-person")]
        public async Task<IActionResult> checkPerson([FromBody]ComplianceRequest complianceRequest)
        {
            DTO.StatusCode status = requestAPI.Post(complianceRequest.personName, complianceRequest.episodeName);
            if (status == DTO.StatusCode.OK)
            {
                return Json(true);
            }
            else if(status == DTO.StatusCode.NameNotCorrect)
            {
                return Json(false);
            }
            else
            {
                return StatusCode(404);
            }
           
        }
        [HttpGet("/api/v1/person")]
        public async Task<IActionResult> person(string name)
        {
            CharacterDTO characterDTO = requestAPI.Get(name);
            if (characterDTO.name !=null)
            return Json(characterDTO);
            else
            {
                return StatusCode(404);
            }
        }

    }
}
