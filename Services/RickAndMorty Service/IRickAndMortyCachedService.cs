using Rick_And_Morty.DTO;

namespace Rick_And_Morty.Services
{
    public interface IRickAndMortyCachedService
    {
        Task<CharacterDTO?> GetCharacterbyNameAsync(string name);
        Task<bool?> IsValidationDataAsync(string? nameCharacter, string? nameEpisode);
    }
}