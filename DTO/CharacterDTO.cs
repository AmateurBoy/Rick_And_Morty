namespace Rick_And_Morty.DTO
{
    public class CharacterDTO
    {
        public string? name { get; set; }
        public string? status { get; set; }
        public string? species { get; set; }
        public string? type { get; set; }
        public string? gender { get; set; }
        public Origin? origin { get; set; }
    }
    public class Origin
    {
        public string? name { get; set; }
        public string? type { get; set; }
        public string? dimension { get; set; }
    }
}
