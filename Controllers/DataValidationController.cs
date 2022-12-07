using Microsoft.AspNetCore.Mvc;

namespace Rick_And_Morty.Controllers
{
    [ApiController]
    public class DataValidationController : Controller
    {

        [HttpPost("/api/v1/check-person")]
        public async Task<IActionResult> checkPerson()
        {
            return Ok();
        }
        [HttpGet("/api/v1/person")]
        public async Task<IActionResult> checkPerson(string name)
        {
            return Ok();
        }

    }
}
