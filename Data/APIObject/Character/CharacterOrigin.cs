using Rick_And_Morty.Helpers;

namespace Rick_And_Morty.Data.APIObject.Character
{
    public class CharacterOrigin
    {
        public CharacterOrigin(string? name = "NotData", Uri? url=null)
        {
            Name = name;
            Url = url;
        }
        public string? Name { get; set; }
        public Uri? Url { get; set; }
    }
}
