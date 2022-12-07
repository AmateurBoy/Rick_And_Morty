using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Rick_And_Morty.DTO;
using RickAndMorty.Net.Api.Factory;
using RickAndMorty.Net.Api.Models.Domain;
using RickAndMorty.Net.Api.Service;

namespace Rick_And_Morty.Services
{
    //using labery Rick.Net 
    public class RequestHandlerAPI
    {
        IRickAndMortyService service = RickAndMortyApiFactory.Create();
        Convertor convertor = new();

        public StatusCode Post(string nameCharacter, string nameEpisode)
        {
            try
            {
                var per = service.FilterCharacters(nameCharacter).Result;
                var Chart = per.FirstOrDefault(x => x.Name == nameCharacter);
                if(Chart == null)
                {
                    return StatusCode.Error;
                }
                var Epis = service.FilterEpisodes(nameEpisode).Result;                
                //Segments[3] => id Character;
                var Shem = Epis.Select(x => x.Characters.Select(x => x.Segments[3])).ToArray();
                var idCharacter = Shem[0].ToArray();

                var Characters = service.GetMultipleCharacters(Array.ConvertAll(idCharacter, s => int.Parse(s))).Result;

                var result = Characters.Where(x => x.Name == nameCharacter).Count();
                if (result > 0) return StatusCode.OK;
                return StatusCode.NameNotCorrect;
            }
            catch
            {
                return StatusCode.Error;
            }

            
        }
        public CharacterDTO Get(string name)
        {
            CharacterDTO characterDTO = new();
            try
            {
                var Characters = service.FilterCharacters(name).Result;
                var Character = Characters.FirstOrDefault(x => x.Name == name);
                if(Character != null)
                {
                    characterDTO = convertor.Convert(Character);
                    var location = service.GetLocation(int.Parse(Character.Origin.Url.Segments[3])).Result;
                    characterDTO.origin.dimension = location.Dimension;
                    characterDTO.origin.type = location.Type;
                    

                    
                    return characterDTO;
                }
                return characterDTO;
            }
            catch
            {
                return characterDTO;
            }
            
            
        }
    }
}
