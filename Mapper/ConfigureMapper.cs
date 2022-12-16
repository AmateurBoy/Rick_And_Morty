using AutoMapper;
using Rick_And_Morty.Data.APIObject.Character;
using Rick_And_Morty.Data.APIObject.Episode;
using Rick_And_Morty.Helpers;


namespace Rick_And_Morty.Mapper
{
    public class ConfigureMapper
    {
        internal static IRickAndMortyMapper CustomizeRickAndMorty()
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

                //Received an exception due to a data mismatch in the API, I had to write a converter by hand
                cfg.CreateMap<FullCharacter,Character>()
                    .ConstructUsing(cls =>
                    new Character(cls.Id,cls.Name,cls.Status,cls.Species,cls.Type,cls.Gender,
                    new CharacterOrigin(cls.Origin.Name,cls.Origin.Url.ToUri()),
                    new CharacterLocation(cls.Location.Name,cls.Location.Url.ToUri()),
                    cls.Image,cls.Episode.Select(x => x.ToUri()).ToList(), cls.Url.ToUri(), cls.Created
                    ));

                cfg.CreateMap<FullEpisode, Episode>()
                   .ConstructUsing(cls =>
                       new Episode(cls.Id, cls.Name, cls.Air_date.ToDataTime(), cls.Episode,
                           cls.Characters.Select(x => x.ToUri()).ToList(), cls.Url.ToUri(), cls.Created));
                
            });            
            return new RickAndMortyMapper { mapper = config.CreateMapper() };
        }
    }
}
