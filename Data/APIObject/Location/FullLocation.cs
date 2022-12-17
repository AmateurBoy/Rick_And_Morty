namespace Rick_And_Morty.Data.APIObject.Location
{
    public class FullLocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Dimension { get; set; }
        public List<string> Residents { get; set; }
        public string Url { get; set; }
        public DateTime Created { get; set; }
    }
}
