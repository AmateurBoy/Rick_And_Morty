using Rick_And_Morty.Data.APIObject.Character;
using Rick_And_Morty.Data.APIObject.Episode;
using Rick_And_Morty.Data.APIObject.Location;

namespace Rick_And_Morty.Services.Request_Service
{
    public interface IRequestService
    {
        Task<FullCharacter> GetCharacterByIDAsync(int id);
        Task<IEnumerable<Character>> GetCharacterByNameAsync(string name);
        Task<IEnumerable<FullCharacter>> GetCharacterMultipleAsync(int[] ids);
        Task<IEnumerable<Episode>> GetEpisodeByNameAsync(string name);
        Task<FullLocation> GetLocationByIdAsync(int id);
    }
}