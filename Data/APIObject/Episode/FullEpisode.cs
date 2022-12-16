namespace Rick_And_Morty.Data.APIObject.Episode
{
    public class FullEpisode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Air_date { get; set; }
        public string Episode { get; set; }
        public List<string> Characters { get; set; }
        public string Url { get; set; }
        public DateTime Created { get; set; }

    }
}
