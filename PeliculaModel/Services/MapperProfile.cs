using AutoMapper;
using PeliculaModel.Dtos;
using PeliculaModel.Entities;

namespace PeliculaModel.Services
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Genero, GeneroDto>();
            CreateMap<GeneroCreateDto, Genero>();

            //Actor
            CreateMap<Actor, ActorDto>();
            CreateMap<ActorCreateDto, Actor>();
            CreateMap<Actor, ActorByIdDto>();

            //Pelicula
            CreateMap<Pelicula, PeliculaDto>();
            CreateMap<PeliculaCreateDto, Pelicula>()
                .ForMember(ent => ent.PeliculaGeneros, dto => dto.MapFrom(prop => prop.PeliculaGeneroIds.Select(id => new PeliculaGenero() { GeneroId = id })))
                .ForMember(ent => ent.PeliculaActors, dto => dto.MapFrom(prop => prop.PeliculaActorIds.Select(propDto => new PeliculaActor() { ActorId = propDto.ActorId, Charadter = propDto.Charadter})));
            CreateMap<Pelicula, PeliculaByIdDto>()
                .ForMember(dto => dto.Generos, ent => ent.MapFrom(prop => prop.PeliculaGeneros.Select(propA => propA.Genero)))
                .ForMember(dto => dto.PeliculaActors, ent => ent.MapFrom(prop => prop.PeliculaActors.Select(propB => new PeliculaActorDto() { ActorId = propB.ActorId, Charadter = propB.Charadter})));
            CreateMap<PeliculaUpdateDto, Pelicula>();
            CreateMap<PeliculaGeneroUpdateDto, PeliculaGenero>();
            CreateMap<PeliculaActorUpdateDto, PeliculaActor>();
        }
    }
}
