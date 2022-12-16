﻿using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Rick_And_Morty.Convertor;
using Microsoft.Extensions.Caching.Memory;
using System.Data;
using Rick_And_Morty.DTO;
using Rick_And_Morty.Services.Convertor;
using Rick_And_Morty.Services.Request_Service;
using Rick_And_Morty.Mapper;
using Rick_And_Morty.Data.APIObject.Character;

namespace Rick_And_Morty.Services
{
    public class RickAndMortyCachedService : IRickAndMortyCachedService
    {
        readonly IRequestService requestService = new RequestService(ConfigureMapper.Customize());
        readonly IConvertor<Character, CharacterDTO> convertor;
        readonly IMemoryCache memoryCache;
        public RickAndMortyCachedService(IMemoryCache memoryCache, IConvertor<Character,CharacterDTO> convertor)
        {
            this.memoryCache = memoryCache;
            this.convertor = convertor;
        }
        public async Task<bool?> IsValidationDataAsync(string? nameCharacter, string? nameEpisode)
        {
            string key = nameCharacter + nameEpisode;
            try
            {
                Object obj = memoryCache.Get(key);
                if (obj != null)
                {
                    if (obj.GetType().IsSubclassOf(typeof(Exception)))
                    {
                        throw (Exception)obj;
                    }
                    else
                    {
                        return Convert.ToBoolean(obj);
                    }
                }
                try
                {
                    //Дополнительная проверка на сооответствие имени.
                    //Если имя все же не совпало значит имени не существует в базе дынных.
                    #region Checking the character's name                  
                   
                    var CharactersTest = requestService.GetCharacterByName(nameCharacter).Result;
                    var ResultCharacter = CharactersTest.FirstOrDefault(x => x.Name == nameCharacter);
                    if (ResultCharacter == null)
                    {
                        var ex = new Exception("NameNotCorrect");
                        CustomCacheSet(key, ex);
                        throw ex;
                    }
                    #endregion
                    #region Checking the episode
                    var Episodes = requestService.GetEpisodeByName(nameEpisode).Result;

                    //Segments[3] => id Character
                    var Segments = Episodes.Select(x => x.Characters.Select(x => x.Segments[3])).ToArray();
                    var idCharacter = Array.ConvertAll(Segments[0].ToArray(), element => int.Parse(element));

                    //Получаем всех персонажей из єпизода.
                    var Characters = await requestService.GetCharacterMultiple(idCharacter);
                    //Проверка по имени.
                    var result = Characters.FirstOrDefault(x => x.Name == nameCharacter);
                    if (result != null)
                    {
                        CustomCacheSet(key, true);
                        return true;
                    }
                    CustomCacheSet(key, false);
                    return false;
                    #endregion
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    CustomCacheSet(key, ex);
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<CharacterDTO?> GetCharacterbyNameAsync(string name)
        {
            try
            {
                Object obj = memoryCache.Get(name);
                if (obj != null)
                {
                    if (obj.GetType().IsSubclassOf(typeof(Exception)))
                    {
                        throw (Exception)obj;
                    }
                    else
                    {
                        return (CharacterDTO?)obj;
                    }
                }

                try
                {
                    var Characters = requestService.GetCharacterByName(name).Result;
                    var Character = Characters.FirstOrDefault(x => x.Name == name);
                    if (Character != null)
                    {
                        CharacterDTO characterDTO = new();
                        characterDTO = convertor.Convert(Character);
                        if (Character.origin.Url != null)
                        {
                            var location = await requestService.GetLocationById(int.Parse(Character.origin.Url.Segments[3]));
                            characterDTO.Origin.Dimension = location.Dimension;
                            characterDTO.Origin.Type = location.Type;
                        }
                        else
                        {
                            characterDTO.Origin.Dimension = "unknown";
                            characterDTO.Origin.Type = "null";
                        }
                        CustomCacheSet(name, characterDTO);
                        return characterDTO;
                    }
                    var ex = new Exception("objNull");
                    throw ex;
                }
                catch (Exception ex)
                {
                    CustomCacheSet(name, ex);
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CustomCacheSet(string key, object value, double saveMinute)
        {
            memoryCache.Set(key, value, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(saveMinute)
            });
        }
        private void CustomCacheSet(string key, object value)
        {
            memoryCache.Set(key, value, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15)
            });
        }
    }
}