using Microsoft.AspNetCore.Mvc;

namespace Rick_And_Morty.Services
{
    public static class ControllerExtension
    {
        public static async Task<IActionResult> IsСharacterInTheEpisodeAsync(this Controller controller,Service service, string? nameCharacter, string? nameEpisode)
        {

            StatusCode? status = await service.StatusCodeValidationData(nameCharacter, nameEpisode);
            switch (status)
            {
                case Services.StatusCode.OK:
                    return controller.Json(true);
                case Services.StatusCode.NameNotCorrect:
                    return controller.Json(false);
                case Services.StatusCode.Error:
                    return controller.StatusCode(404);
                default:
                    return controller.Json("Unhandled Exception");
            }
        }
    }
}
