using Microsoft.AspNetCore.Mvc;
using PeliculasAPI.Helpers;
using PeliculasCore.DTOs;
using PeliculasCore.DTOs.Genero;
using PeliculasCore.Services;

namespace PeliculasAPI.Controllers
{
    [ApiController]
    [Route("api/generos")]
    public class GenerosController : ControllerBase
    {
        private readonly GeneroService generoService;        
        public GenerosController(GeneroService generoService)
        {
            this.generoService = generoService;            
        }

        [HttpGet]
        public async Task<ActionResult<List<GeneroDto>>> Get([FromQuery] PaginationDto paginationDto)
        {
            var totalItems = generoService.Count();
            HttpContext.InsertPaginationParams(totalItems, paginationDto.RowsPerPage);
            return await generoService.ListAsync(paginationDto);             
        }

        [HttpGet("{id:int}", Name = "get")]
        public async Task<ActionResult<GeneroDto>> Get(int id)
        {
            var generoDto = await generoService.FindOrDefaultAsync(id);
            if(generoDto == null)
            {
                return NotFound();
            }
            return generoDto;
        }

        [HttpPost()]
        public async Task<ActionResult> Post([FromBody] GeneroCreationDto generoCreation)
        {           
            var generoDto = generoService.Add(generoCreation);
            return new CreatedAtRouteResult("get", new { id = generoDto.Id }, generoDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] GeneroCreationDto generoCreation)
        {
            generoService.Update(id, generoCreation);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {            
            return generoService.Remove(id) ? NoContent() : NotFound();
        }
    }
}
