using AutoMapper;
using PeliculasCore.DTOs;
using PeliculasCore.DTOs.Movies;
using PeliculasCore.Models;
using PeliculasCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.Services
{
    public class MovieService : BaseService<Movie>
    {
        private readonly MovieRepository movieRepository;
        private readonly IMapper mapper;
        private readonly IFileStorageService fileStorageService;

        private readonly string container = "movies";

        public MovieService(MovieRepository movieRepository, IMapper mapper, IFileStorageService fileStorageService)
            : base(movieRepository, mapper)
        {
            this.movieRepository = movieRepository;
            this.mapper = mapper;
            this.fileStorageService = fileStorageService;
        }
        
        public async Task<MovieDto> AddAsync(MovieCreationDto movie)
        {
            var entity = mapper.Map<Movie>(movie);
            AssignOrder(entity);
            if (movie.Poster != null)
            {
                using var stream = new MemoryStream();
                await movie.Poster.CopyToAsync(stream);
                var content = stream.ToArray();
                var extension = Path.GetExtension(movie.Poster.FileName);
                entity.Poster = await fileStorageService.Save(content, extension, container, movie.Poster.ContentType);
            }
            movieRepository.Add(entity);
            return mapper.Map<MovieDto>(entity);
        }
        public async Task<bool> UpdateAsync(int id, MovieCreationDto movieDto)
        {
            var movieDb = movieRepository.FindOrDefault(id);
            if (movieDb == null)
            {
                return false;
            }
            movieDb = mapper.Map<Movie>(movieDto);
            
            if (movieDto.Poster != null)
            {
                using var stream = new MemoryStream();
                await movieDto.Poster.CopyToAsync(stream);
                var content = stream.ToArray();
                var extension = Path.GetExtension(movieDto.Poster.FileName);
                movieDb.Poster = await fileStorageService.Edit(content, extension, container,
                    movieDb.Poster, movieDto.Poster.ContentType);
            }
            movieRepository.Update(movieDb);
            return true;
        }

        public async Task<List<MovieDto>> ListAsync(MovieFilter filter)
        {
            var entities = await movieRepository.ListAsync(filter.Pagination, filter.GetPredicate());
            return mapper.Map<List<MovieDto>>(entities);
        }

        private void AssignOrder(Movie movie)
        {
            if (movie.MovieActorAssocs == null)
            {
                return;
            }
            movie.MovieActorAssocs
                .Select((item, index) => (item, index))
                .ToList()
                .ForEach(x => x.item.Order = x.index);
        }

   

        
    }
}
