using Rick_And_Morty.DTO;
using RickAndMorty.Net.Api.Models.Domain;

namespace Rick_And_Morty.Services.Convertor
{
    public class Convertor : IConvertor<Character, CharacterDTO>
    {
        public Character Convert(CharacterDTO dto)
        {
            throw new NotImplementedException("Нет необходимости в обратной конвертации");
        }
        public CharacterDTO Convert(Character Base)
        {
            CharacterDTO characterDTO = new()
            {
                origin = new()
            };
            characterDTO.name = Base.Name;
            characterDTO.status = Base.Status.ToString();
            characterDTO.species = Base.Species;
            characterDTO.type = Base.Type;
            characterDTO.gender = Base.Gender.ToString();
            characterDTO.origin.name = Base.Origin.Name;

            return characterDTO;
        }
    }
}
