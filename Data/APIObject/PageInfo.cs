namespace Rick_And_Morty.Data.APIObject
{
    public class PageInfoDto
    {
        public int Count { get; set; }
        public int Pages { get; set; }
        public string Next { get; set; }
        public string Prev { get; set; }
    }

}
