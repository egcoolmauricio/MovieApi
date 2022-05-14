using AutoMapper;
using PeliculasCore.DTOs;
using PeliculasCore.DTOs.Genero;
using PeliculasCore.Models;
using PeliculasCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.Services
{
    public class GeneroService
    {
        private readonly GeneroRepository generoRepository;
        private readonly IMapper mapper;

        public GeneroService(GeneroRepository generoRepository, IMapper mapper)
        {
            this.generoRepository = generoRepository;
            this.mapper = mapper;
        }

        public List<GeneroDto> List()
        {
            var entities = generoRepository.List();
            return mapper.Map<List<GeneroDto>>(entities);
        }

        public async Task<List<GeneroDto>> ListAsync()
        {
            var entities = await generoRepository.ListAsync();
            return mapper.Map<List<GeneroDto>>(entities);
        }

        public async Task<GeneroDto?> FindOrDefaultAsync(int id)
        {
            var generoEntity = await generoRepository.FindOrDefaultAsync(id);
            if(generoEntity == null)
            {
                return null;
            }
            return mapper.Map<GeneroDto>(generoEntity);
        }

        public GeneroDto Add(GeneroCreationDto generoCreation)
        {
            var entity = mapper.Map<Genero>(generoCreation);
            generoRepository.Add(entity);
            return mapper.Map<GeneroDto>(entity);
        }

        public void Update(int id ,GeneroCreationDto generoCreation)
        {
            var entity = mapper.Map<Genero>(generoCreation);
            entity.Id = id;
            generoRepository.Update(entity);
        }

        public bool Remove(int id)
        {            
            if (!generoRepository.Any(x => x.Id == id))
            {
                return false;
            }
            generoRepository.Remove(new Genero { Id = id });
            return true;
        }

        public int Count() => generoRepository.Count();

        public async Task<List<GeneroDto>> ListAsync(PaginationDto pagination)
        {
            var entities = await generoRepository.ListAsync(pagination);
            return mapper.Map<List<GeneroDto>>(entities);

        }

    }
}
