namespace Rick_And_Morty.Data.APIObject
{
    public class Page<T>
    {
        public PageInfoDto Info { get; set; }
        public IEnumerable<T> Results { get; set; }
    }
}
