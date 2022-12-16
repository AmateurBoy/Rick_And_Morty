using AutoMapper;
using Rick_And_Morty.Data.APIObject.Character;
using Rick_And_Morty.Data.APIObject.Episode;
using Rick_And_Morty.Helpers;


namespace Rick_And_Morty.Mapper
{
    public class ConfigureMapper
    {
        internal static IRickAndMortyMapper Customize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;

                cfg.CreateMap<FullCharacterLocation, CharacterLocation>()
                    .ConstructUsing(cls =>
                        new CharacterLocation(cls.Name, cls.Url.ToUri()));

                cfg.CreateMap<FullCharacterOrigin, CharacterOrigin>()
                    .ConstructUsing(cls =>
                        new CharacterOrigin(cls.Name, cls.Url.ToUri()));

                cfg.CreateMap<FullEpisode, Episode>()
                   .ConstructUsing(cls =>
                       new Episode(cls.Id, cls.Name, cls.Air_date.ToDataTime(), cls.Episode,
                           cls.Characters.Select(x => x.ToUri()).ToList(), cls.Url.ToUri(), cls.Created));
                 
                cfg.CreateMap<FullCharacter,Character>()
                    .ConstructUsing(cls =>
                    new Character(cls.Id,cls.Name,cls.Status,cls.Species,cls.Type,cls.Gender,
                    new CharacterOrigin(cls.origin.Name,cls.origin.Url.ToUri()),
                    new CharacterLocation(cls.location.Name,cls.location.Url.ToUri()),
                    cls.Image,cls.Episode,cls.Url.ToUri(),cls.Created
                    ));
            });            
            return new RickAndMortyMapper { mapper = config.CreateMapper() };
        }
    }
}
