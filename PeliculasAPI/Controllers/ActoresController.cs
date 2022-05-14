using Microsoft.AspNetCore.Mvc;
using PeliculasCore.DTOs;
using PeliculasCore.DTOs.Actor;
using PeliculasCore.Services;
using PeliculasAPI.Helpers;

namespace PeliculasAPI.Controllers
{
    [ApiController]
    [Route("api/actores")]
    public class ActoresController : ControllerBase
    {
        private readonly ActorService actorService;

        public ActoresController(ActorService actorService)
        {
            this.actorService = actorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActorDto>>> Get([FromQuery] PaginationDto paginationDto)
        {
            var totalItems = actorService.Count();
            HttpContext.InsertPaginationParams(totalItems, paginationDto.RowsPerPage);
            return await actorService.ListAsync<ActorDto>(paginationDto);
        }

        [HttpGet("{id:int}", Name = "getActor")]
        public async Task<ActionResult<ActorDto>> Get(int id)
        {
            var actorDto = await actorService.FindOrDefaultAsync<ActorDto>(id);
            if (actorDto == null)
            {
                return NotFound();
            }
            return actorDto;
        }

        [HttpPost()]
        public async Task<ActionResult> Post([FromForm] ActorCreationDto actor)
        {
            var actorDto = await actorService.AddAsync(actor);
            return new CreatedAtRouteResult("getActor", new { id = actorDto.Id }, actorDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromForm] ActorCreationDto actor)
        {
            var entityUpdated = await actorService.UpdateAsync(id, actor);
            return entityUpdated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return await actorService.RemoveAsync(id) ? NoContent() : NotFound();
        }
    }
}

