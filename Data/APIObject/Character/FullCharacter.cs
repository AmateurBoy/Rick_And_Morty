namespace Rick_And_Morty.Data.APIObject.Character
{
    public class FullCharacter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Species { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public FullCharacterOrigin? Origin { get; set; }
        public FullCharacterLocation? Location { get; set; }
        public string Image { get; set; }
        public string[] Episode { get; set; }
        public string Url { get; set; }
        public DateTime? Created { get; set; }
       
    }
}
