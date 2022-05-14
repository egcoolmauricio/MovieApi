using AutoMapper;
using PeliculasCore.DTOs;
using PeliculasCore.Models;
using PeliculasCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.Services
{
    public class BaseService<T> where T : class, IEntityId, new() 
    {
        private readonly IBaseRepository<T> repository;
        private readonly IMapper mapper;

        public BaseService(IBaseRepository<T> repository, IMapper mapper) 
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public List<TDto> List<TDto>()
        {
            var entities = repository.List();
            return mapper.Map<List<TDto>>(entities);
        }

        public async Task<List<TDto>> ListAsync<TDto>()
        {
            var entities = await repository.ListAsync();
            return mapper.Map<List<TDto>>(entities);
        }
        public async Task<List<TDto>> ListAsync<TDto>(PaginationDto pagination)
        {
            var entities = await repository.ListAsync(pagination);
            return mapper.Map<List<TDto>>(entities);

        }

        public async Task<TDto?> FindOrDefaultAsync<TDto>(int id)
        {
            var movieEntity = await repository.FindOrDefaultAsync(id);
            if (movieEntity == null)
            {
                return default;
            }
            return mapper.Map<TDto>(movieEntity);
        }

        public TDto Add<TDto, TCreation>(TCreation creationDto)
        {
            var entity = mapper.Map<T>(creationDto);
            repository.Add(entity);
            return mapper.Map<TDto>(entity);
        }

        public void Update<TCreation>(int id, TCreation creationDto)
        {
            var entity = mapper.Map<T>(creationDto);
            entity.Id = id;
            repository.Update(entity);
        }

        public bool Remove(int id)
        {
            if (!repository.Any(x => x.Id == id))
            {
                return false;
            }
            repository.Remove(new T { Id = id });
            return true;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var actor = await repository.FindOrDefaultAsync(id);
            if (actor == null)
            {
                return false;
            }
            repository.Remove(actor);
            return true;
        }

        public int Count() => repository.Count();

        
    }
}
