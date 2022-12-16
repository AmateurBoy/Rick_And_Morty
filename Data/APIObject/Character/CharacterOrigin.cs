using Rick_And_Morty.Helpers;

namespace Rick_And_Morty.Data.APIObject.Character
{
    public class CharacterOrigin
    {
        public CharacterOrigin(string name , Uri url)
        {
            Name = name;
            Url = url;
        }
        public string? Name { get; set; }
        public Uri? Url { get; set; }
    }
}
