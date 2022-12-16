namespace Rick_And_Morty.Data.APIObject.Episode
{
    public class Episode
    {
        public Episode(int id = 0, string name = "", DateTime? airDate = null,
            string episodeCode = "", IEnumerable<Uri> characters = null,
            Uri url = null, DateTime? created = null)
        {
            Id = id;
            Name = name;
            AirDate = airDate;
            EpisodeCode = episodeCode;
            Characters = characters;
            Url = url;
            Created = created;
        }
        public int Id { get; }
        public string Name { get; }
        public DateTime? AirDate { get; }
        public string EpisodeCode { get; }
        public IEnumerable<Uri> Characters { get; }
        public Uri Url { get; }
        public DateTime? Created { get; }
    }
}
