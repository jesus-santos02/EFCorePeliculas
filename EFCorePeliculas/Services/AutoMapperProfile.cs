using AutoMapper;
using EFCorePeliculas.DTOs;
using EFCorePeliculas.Entities;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace EFCorePeliculas.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Actor, ActorDTO>();

            CreateMap<Cine, CineDTO>()
                .ForMember(dto => dto.Latitud, ent => ent.MapFrom(p => p.Ubicacion.Y))
                .ForMember(dto => dto.Longitud, ent => ent.MapFrom(p => p.Ubicacion.X));

            CreateMap<Genero, GeneroDTO>();

            CreateMap<Pelicula, PeliculaDTO>()
                .ForMember(dto => dto.Cines, ent => ent.MapFrom(p => p.SalasDeCines.Select(s => s.Cine)))
                .ForMember(dto => dto.Actores, ent => ent.MapFrom(p => p.PeliculasActores.Select(pa => pa.Actor)));

            //Sin ProjectTo *Ordenar Generos
            CreateMap<Pelicula, PeliculaDTO>()
                .ForMember(dto => dto.Generos, ent => ent.MapFrom(p => p.Generos.OrderByDescending(g => g.Nombre)))
                .ForMember(dto => dto.Cines, ent => ent.MapFrom(p => p.SalasDeCines.Select(s => s.Cine)))
                .ForMember(dto => dto.Actores, ent => ent.MapFrom(p => p.PeliculasActores.Select(pa => pa.Actor)));

            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            CreateMap<CineCreacionDTO, Cine>()
                .ForMember(ent => ent.Ubicacion, dto => dto.MapFrom(campo => geometryFactory.CreatePoint(new Coordinate(campo.Longitud, campo.Latitud))));

            CreateMap<CineOfertaCreacionDTO, CineOferta>();

            CreateMap<SalaDeCineCreacionDTO, SalaDeCine>();

            CreateMap<PeliculaCreacionDTO, Pelicula>()
                .ForMember(ent => ent.Generos, dto => dto.MapFrom(campo => campo.Generos.Select(id => new Genero { Identificador = id })))
                .ForMember(ent => ent.SalasDeCines, dto => dto.MapFrom(campo => campo.SalasDeCine.Select(id => new SalaDeCine { Id = id })));

            CreateMap<PeliculaActorCreacionDTO, PeliculaActor>();

            CreateMap<ActorCreacionDTO, Actor>();
        }
    }
}
