using Rick_And_Morty.Data.APIObject.Character;
using Rick_And_Morty.Data.APIObject.Episode;
using Rick_And_Morty.Data.APIObject.Location;

namespace Rick_And_Morty.Services.Request_Service
{
    public interface IRequestService
    {
        Task<FullCharacter> GetCharacterByID(int id);
        Task<IEnumerable<Character>> GetCharacterByName(string name);
        Task<IEnumerable<FullCharacter>> GetCharacterMultiple(int[] ids);
        Task<IEnumerable<Episode>> GetEpisodeByName(string name);
        Task<FullLocation> GetLocationById(int id);
    }
}