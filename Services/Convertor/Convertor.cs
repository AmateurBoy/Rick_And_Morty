using Rick_And_Morty.Data.APIObject.Character;
using Rick_And_Morty.DTO;

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
                Origin = new()
            };
            characterDTO.Name = Base.Name;
            characterDTO.Status = Base.Status.ToString();
            characterDTO.Species = Base.Species;
            characterDTO.Type = Base.Type;
            characterDTO.Gender = Base.Gender.ToString();
            characterDTO.Origin.Name = Base.Origin.Name;

            return characterDTO;
        }
    }
}
