using AutoMapper;
using PeliculasCore.DTOs;
using PeliculasCore.DTOs.Actor;
using PeliculasCore.DTOs.Genero;
using PeliculasCore.DTOs.Movies;
using PeliculasCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Genero, GeneroDto>().ReverseMap();
            CreateMap<GeneroCreationDto, Genero>();

            CreateMap<Actor, ActorDto>().ReverseMap();
            CreateMap<ActorCreationDto, Actor>()
                .ForMember(x => x.Photo, options => options.Ignore());

            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<MovieCreationDto, Movie>()
                .ForMember(x => x.Poster, options => options.Ignore())
                .ForMember(x => x.MovieGeneroAssocs , options => options.MapFrom(MapMovieGeneroAssoc))
                .ForMember(x => x.MovieActorAssocs, options => options.MapFrom(MapMovieActorAssoc));


            CreateMap<MoviePatchDto, Movie>().ReverseMap();
        }

        private List<MovieGeneroAssoc> MapMovieGeneroAssoc(MovieCreationDto movieCreation, Movie movie)
        {
            if(movieCreation.GeneroIds == null)
            {
                return new List<MovieGeneroAssoc>();
            }
            return movieCreation.GeneroIds
                .Select(id => new MovieGeneroAssoc { GeneroId = id })
                .ToList();
        }

        private List<MovieActorAssoc> MapMovieActorAssoc(MovieCreationDto movieCreation, Movie movie)
        {
            if (movieCreation.Actors == null)
            {
                return new List<MovieActorAssoc>();
            }
            return movieCreation.Actors
                .Select(actor => new MovieActorAssoc { ActorId = actor.ActorId, Character = actor.CharacterName })
                .ToList();
        }
    }
}
