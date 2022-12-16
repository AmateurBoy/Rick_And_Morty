using static Rick_And_Morty.Data.APIObject.Character.FullCharacter;

namespace Rick_And_Morty.Data.APIObject.Character
{
    public class Character
    {
        public Character(int id = 0, string? name = "", string? status = "", 
            string? species = "", string? type = "", 
            string? gender = "", 
            CharacterOrigin? origin = null,
            CharacterLocation? location = null,
            string? image = "",
            IEnumerable<Uri>? episode = null, Uri? url = null, DateTime? created = null)
        {
            Id = id;
            Name = name;
            Status = status;
            Species = species;
            Type = type;
            Gender = gender;
            this.Origin = origin;
            this.Location = location;
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
        public CharacterOrigin? Origin { get; set; }
        public CharacterLocation? Location { get; set; }
        public string Image { get; set; }
        public IEnumerable<Uri>? Episode { get; set; }
        public Uri? Url { get; set; }
        public DateTime? Created { get; set; }

    }
}
