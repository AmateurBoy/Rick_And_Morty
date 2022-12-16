using Rick_And_Morty.Data.APIObject.Character;
using Rick_And_Morty.Helpers;

namespace Rick_And_Morty.Services.Convertor
{   
    public class ConvertorCharacterCollection : IConvertor<IEnumerable<FullCharacter>, IEnumerable<Character>>
    {
        public IEnumerable<FullCharacter> Convert(IEnumerable<Character> dto)
        {
            throw new NotImplementedException();
        }
        //Replacing the mapper method.
        public IEnumerable<Character> Convert(IEnumerable<FullCharacter> Base)
        {
            var list = new List<Character>();
            foreach (var fullCharacter in Base)
            { 
                var Character = new Character(
                    id:fullCharacter.Id,name:fullCharacter.Name,
                    status:fullCharacter.Status,species:fullCharacter.Species,type:fullCharacter.Type,
                    gender:fullCharacter.Gender,new CharacterOrigin(name:fullCharacter.Origin.Name,
                    url:fullCharacter.Origin.Url.ToUri()),
                    new CharacterLocation(name:fullCharacter.Location.Name,url:fullCharacter.Location.Url.ToUri()),
                    image:fullCharacter.Image,episode:fullCharacter.Episode.Select(x=>x.ToUri()).ToArray(),
                    url:fullCharacter.Url.ToUri(),created:fullCharacter.Created
                    );
                list.Add(Character);
            }
            return list;
        }
    }
}
