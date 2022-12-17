namespace Rick_And_Morty.DTO
{
    public class CharacterDTO
    {
        public string? Name { get; set; }
        public string? Status { get; set; }
        public string? Species { get; set; }
        public string? Type { get; set; }
        public string? Gender { get; set; }
        public Origin? Origin {get;set;}
    }
    public class Origin
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Dimension { get; set; }
    }
}
