using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Rick_And_Morty.DTO;
using RickAndMorty.Net.Api.Factory;
using RickAndMorty.Net.Api.Models.Domain;
using RickAndMorty.Net.Api.Service;

namespace Rick_And_Morty.Services
{
    
    public class RequestHandlerAPI
    {
        IRickAndMortyService service = RickAndMortyApiFactory.Create();
        Convertor convertor = new();
        public async Task<StatusCode> IsСharacterInTheEpisode(string nameCharacter, string nameEpisode)
        {
            try
            {
                //Дополнительная проверка на сооответствие имени.
                //Если имя все же не совпало значит имени не существует в базе дынных
                #region Checking the character's name
                var CharactersTest =await service.FilterCharacters(nameCharacter);
                var ResultCharacter = CharactersTest.FirstOrDefault(x => x.Name == nameCharacter);
                if(ResultCharacter == null)
                {
                    return StatusCode.Error;
                }
                #endregion

                var Episode =await service.FilterEpisodes(nameEpisode);                
                //Segments[3] => id Character
                var Segments = Episode.Select(x => x.Characters.Select(x => x.Segments[3])).ToArray();
                var idCharacter = Segments[0].ToArray();
                //Получаем всех персонажей из єпизода.
                var Characters =await service.GetMultipleCharacters(Array.ConvertAll(idCharacter, s => int.Parse(s)));
                //Проверка по имени.
                var result = Characters.FirstOrDefault(x => x.Name == nameCharacter);
                if (result != null) return StatusCode.OK;
                return StatusCode.NameNotCorrect;
            }
            catch(Exception ex)
            {
                return StatusCode.Error;
            }
        }        
        public async Task<CharacterDTO?> GiveDTObyName(string name)
        {
            CharacterDTO? characterDTO = new();
            try
            {
                var Characters = await service.FilterCharacters(name);
                var Character = Characters.FirstOrDefault(x => x.Name == name);
                if (Character != null)
                {
                    characterDTO = convertor.Convert(Character);
                    var location = await service.GetLocation(int.Parse(Character.Origin.Url.Segments[3]));
                    characterDTO.origin.dimension = location.Dimension;
                    characterDTO.origin.type = location.Type;
                    return characterDTO;
                }
                return null;
            }
            catch(Exception ex)
            {
                return null;
            }
            
            
        }
                
    }
}
