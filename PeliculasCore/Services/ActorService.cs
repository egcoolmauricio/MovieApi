using AutoMapper;
using PeliculasCore.DTOs;
using PeliculasCore.DTOs.Actor;
using PeliculasCore.Models;
using PeliculasCore.Repositories;

namespace PeliculasCore.Services
{
    public class ActorService : BaseService<Actor>
    {
        private readonly ActorRepository actorRepository;
        private readonly IMapper mapper;
        private readonly IFileStorageService fileStorageService;
        private readonly string container = "actores";

        public ActorService(ActorRepository actorRespository, IMapper mapper, IFileStorageService fileStorageService)
            : base(actorRespository, mapper)
        {
            this.actorRepository = actorRespository;
            this.mapper = mapper;
            this.fileStorageService = fileStorageService;
        }
        
        public async Task<ActorDto> AddAsync(ActorCreationDto actor)
        {
            var entity = mapper.Map<Actor>(actor);
            if(actor.Photo != null)
            {
                using var stream = new MemoryStream();
                await actor.Photo.CopyToAsync(stream);
                var content = stream.ToArray();
                var extension = Path.GetExtension(actor.Photo.FileName);
                entity.Photo = await fileStorageService.Save(content, extension, container, actor.Photo.ContentType);
            }
            actorRepository.Add(entity);
            return mapper.Map<ActorDto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, ActorCreationDto actor)
        {
            var actorDb = actorRepository.FindOrDefault(id);
            if(actorDb == null)
            {
                return false;
            }  
            var entity = mapper.Map<Actor>(actor);

            if (actor.Photo != null)
            {
                using var stream = new MemoryStream();
                await actor.Photo.CopyToAsync(stream);
                var content = stream.ToArray();
                var extension = Path.GetExtension(actor.Photo.FileName);
                entity.Photo = await fileStorageService.Edit(content, extension, container, 
                    actorDb.Photo ,actor.Photo.ContentType);
            }

            entity.Id = id;
            actorRepository.Update(entity);
            return true;
        }
       
    }
}
