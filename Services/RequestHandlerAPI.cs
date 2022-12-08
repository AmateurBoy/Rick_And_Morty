using Microsoft.VisualBasic;
using Newtonsoft.Json;
using RickAndMorty.Net.Api.Factory;
using RickAndMorty.Net.Api.Models.Domain;
using RickAndMorty.Net.Api.Service;
using Rick_And_Morty.Data;

namespace Rick_And_Morty.Services
{
    public class RequestHandlerAPI
    {
        readonly IRickAndMortyService _service = RickAndMortyApiFactory.Create();
        readonly Services.Convertor.Convertor _convertor = new();
        readonly MemoryCache _memoryCache;
        public RequestHandlerAPI(MemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public async Task<StatusCode> IsСharacterInTheEpisode(string? nameCharacter, string? nameEpisode)
        {
            string key = nameCharacter + nameEpisode;
            try
            {
                
                StatusCode statusCode = _memoryCache.GetCacheStatusCode(key);
                if(statusCode!=null)
                {
                    return statusCode;
                }
                //Дополнительная проверка на сооответствие имени.
                //Если имя все же не совпало значит имени не существует в базе дынных.
                #region Checking the character's name
                var CharactersTest = _service.FilterCharacters(nameCharacter).Result;
                var ResultCharacter = CharactersTest.FirstOrDefault(x => x.Name == nameCharacter);
                if(ResultCharacter == null)
                {
                    _memoryCache.SetCache(key, StatusCode.Error);
                    return StatusCode.Error;
                }
                #endregion

                var Episode = _service.FilterEpisodes(nameEpisode).Result;
                //Segments[3] => id Character
                var Segments = Episode.Select(x => x.Characters.Select(x => x.Segments[3])).ToArray();
                var idCharacter = Segments[0].ToArray();
                //Получаем всех персонажей из єпизода.
                var Characters =await _service.GetMultipleCharacters(Array.ConvertAll(idCharacter, s => int.Parse(s)));
                //Проверка по имени.
                var result = Characters.FirstOrDefault(x => x.Name == nameCharacter);
                if (result != null)
                {
                    _memoryCache.SetCache(key, StatusCode.OK);
                    return StatusCode.OK;
                }
                _memoryCache.SetCache(key, StatusCode.NameNotCorrect);
                return StatusCode.NameNotCorrect;
            }
            catch
            {
                _memoryCache.SetCache(key, StatusCode.Error);
                return StatusCode.Error;
            }
        }        
        public async Task<State?> GiveDTObyName(string name)
        {
            State? stateDTO;
            try
            {
                stateDTO = _memoryCache.GetCache(name);
                if (stateDTO != null)
                {
                    return stateDTO;
                }

                var Characters = _service.FilterCharacters(name).Result;
                var Character = Characters.FirstOrDefault(x => x.Name == name);
                if (Character != null)
                {
                    var characterDTO = _convertor.Convert(Character);
                    stateDTO = new();
                    stateDTO.characterDTO = characterDTO;
                    var location = await _service.GetLocation(int.Parse(Character.Origin.Url.Segments[3]));
                    characterDTO.origin.dimension = location.Dimension;
                    characterDTO.origin.type = location.Type;

                    _memoryCache.SetCache(name, stateDTO);
                    return stateDTO;
                }
                _memoryCache.SetCache(name, new State { isCacheNull = true });
                return null;
            }
            catch(Exception ex)
            {
                _memoryCache.SetCache(name, new State { isCacheNull = true });
                return null;
            }
        }

       
    }
}
