using AutoMapper;
using PeliculasCore.DTOs;
using PeliculasCore.DTOs.Actor;
using PeliculasCore.DTOs.Genero;
using PeliculasCore.DTOs.Movie;
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
                .ForMember(x => x.Poster, options => options.Ignore());
        }
    }
}
