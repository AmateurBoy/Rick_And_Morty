using Microsoft.VisualBasic;
using Newtonsoft.Json;
using RickAndMorty.Net.Api.Factory;
using RickAndMorty.Net.Api.Models.Domain;
using RickAndMorty.Net.Api.Service;
using Microsoft.AspNetCore.Mvc;
using Rick_And_Morty.Convertor;
using Microsoft.Extensions.Caching.Memory;
using System.Data;
using Rick_And_Morty.DTO;
using Rick_And_Morty.Services.Convertor;

namespace Rick_And_Morty.Services
{
    public class Service
    {
        readonly IRickAndMortyService EmbeddedService = RickAndMortyApiFactory.Create();
        readonly IConvertor<Character,CharacterDTO> convertor;
        private IMemoryCache memoryCache = new MemoryCache(new MemoryCacheOptions());
        public Service(IMemoryCache memoryCache, IConvertor<Character,CharacterDTO> convertor)
        {
            this.convertor = convertor;
        }
        
        public async Task<bool?> IsValidationData(string? nameCharacter, string? nameEpisode)
        {
            string key = nameCharacter + nameEpisode;
            try
            {
                Object o = memoryCache.Get(key);
                if(o != null)
                {
                    if (o.GetType().IsSubclassOf(typeof(Exception)))
                    {
                        throw (Exception)o;
                    }
                }
                
               
                //Дополнительная проверка на сооответствие имени.
                //Если имя все же не совпало значит имени не существует в базе дынных.
                #region Checking the character's name
                var CharactersTest = EmbeddedService.FilterCharacters(nameCharacter).Result;
                var ResultCharacter = CharactersTest.FirstOrDefault(x => x.Name == nameCharacter);
                if(ResultCharacter == null)
                {
                    var ex = new Exception("NameNotCorrect");
                    memoryCache.Set(key, ex, new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15)
                    }); ;
                    throw ex;
                }
                #endregion

                var Episode = EmbeddedService.FilterEpisodes(nameEpisode).Result;

                //Segments[3] => id Character
                var Segments = Episode.Select(x => x.Characters.Select(x => x.Segments[3])).ToArray();
                var idCharacter = Segments[0].ToArray();

                //Получаем всех персонажей из єпизода.
                var Characters =await EmbeddedService.GetMultipleCharacters(Array.ConvertAll(idCharacter, s => int.Parse(s)));

                //Проверка по имени.
                var result = Characters.FirstOrDefault(x => x.Name == nameCharacter);
                if (result != null)
                {
                    memoryCache.Set(key, true ,new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15)
                    });
                    return true;
                }
                memoryCache.Set(key, false, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15)
                });
                return false;
            }
            catch(Exception ex)
            {
                memoryCache.Set(key, ex, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15)
                });
                throw ex;
            }
        }        
        //public async Task<State?> GiveDTObyName(string name)
        //{
        //    State? stateDTO;
        //    try
        //    {
        //        stateDTO = _memoryCache.GetCache(name);
        //        if (stateDTO != null)
        //        {
        //            return stateDTO;
        //        }

        //        var Characters = _service.FilterCharacters(name).Result;
        //        var Character = Characters.FirstOrDefault(x => x.Name == name);
        //        if (Character != null)
        //        {
        //            var characterDTO = _convertor.Convert(Character);
        //            stateDTO = new();
        //            stateDTO.characterDTO = characterDTO;
        //            var location = await _service.GetLocation(int.Parse(Character.Origin.Url.Segments[3]));
        //            characterDTO.origin.dimension = location.Dimension;
        //            characterDTO.origin.type = location.Type;

        //            _memoryCache.SetCache(name, stateDTO);
        //            return stateDTO;
        //        }
        //        _memoryCache.SetCache(name, new State { isCacheNull = true });
        //        return null;
        //    }
        //    catch(Exception ex)
        //    {
        //        _memoryCache.SetCache(name, new State { isCacheNull = true });
        //        return null;
        //    }
        //}
    }
}
