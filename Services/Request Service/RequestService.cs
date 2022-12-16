using Newtonsoft.Json;
using Rick_And_Morty.Data.APIObject;
using Rick_And_Morty.Data.APIObject.Character;
using Rick_And_Morty.Data.APIObject.Episode;
using Rick_And_Morty.Data.APIObject.Location;
using Rick_And_Morty.Mapper;
using System.Xml.Linq;

namespace Rick_And_Morty.Services.Request_Service
{
    public class RequestService : IRequestService
    {
        private HttpClient Client { get; }
        private IRickAndMortyMapper RickAndMortyMapper;
        public RequestService(IRickAndMortyMapper mapper,string baseAddress = @"https://rickandmortyapi.com/api/")
        {
            this.RickAndMortyMapper = mapper;
            Client = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };

        }
        public async Task<FullCharacter> GetCharacterByID(int id)
        {
            var json = (await Client.GetAsync($"character/{id}")).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<FullCharacter>(json.Result);
        }
        public async Task<IEnumerable<FullCharacter>> GetCharacterMultiple(int[] ids)
        {
            var json = (await Client.GetAsync($"character/{string.Join(",", ids)}")).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<FullCharacter>>(json.Result);
        }
        public async Task<IEnumerable<Character>> GetCharacterByName(string name)
        {
            var json = (await Client.GetAsync($"character/?name={name}")).Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<Page<FullCharacter>>(json.Result).Results;
            var result = RickAndMortyMapper.mapper.Map<IEnumerable<Character>>(list);
            return result;
        }
        public async Task<IEnumerable<Episode>> GetEpisodeByName(string name)
        {           
            var json = (await Client.GetAsync($"episode/?name={name}")).Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<Page<FullEpisode>>(json.Result).Results;
            var result = RickAndMortyMapper.mapper.Map<IEnumerable<Episode>>(list);
            return result;
        }
        public async Task<FullLocation> GetLocationById(int id)
        {
            var json = (await Client.GetAsync($"location/{id}")).Content.ReadAsStringAsync();
            var location = JsonConvert.DeserializeObject<FullLocation>(json.Result);
            return RickAndMortyMapper.mapper.Map<FullLocation>(location);
        }

    }
}
