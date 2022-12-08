namespace Rick_And_Morty.Services
{
    public interface IConvertor<Base,DTO>
    {
        public Base Convert(DTO dto);
        public DTO Convert(Base Base);       
    }
}
