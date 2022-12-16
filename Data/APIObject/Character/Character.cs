using static Rick_And_Morty.Data.APIObject.Character.FullCharacter;

namespace Rick_And_Morty.Data.APIObject.Character
{
    public class Character
    {
        public Character(int id = 0, string name = null, string status = null, 
            string species = null, string type = null, 
            string gender = null, 
            CharacterOrigin origin = null,
            CharacterLocation location = null,
            string image = null,
            List<string> episode = null, Uri url = null, DateTime? created = null)
        {
            Id = id;
            Name = name;
            Status = status;
            Species = species;
            Type = type;
            Gender = gender;
            this.origin = origin;
            this.location = location;
            Image = image;
            Episode = episode;
            Url = url;
            Created = created;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Species { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public CharacterOrigin origin { get; set; }
        public CharacterLocation location { get; set; }
        public string Image { get; set; }
        public List<string> Episode { get; set; }
        public Uri Url { get; set; }
        public DateTime? Created { get; set; }

    }
}
