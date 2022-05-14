using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PeliculasAPI.Helpers;
using PeliculasCore.DTOs;
using PeliculasCore.DTOs.Movie;
using PeliculasCore.Services;


namespace PeliculasAPI.Controllers
{

    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly MovieService movieService;

        public MoviesController(MovieService movieService)
        {
            this.movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MovieDto>>> Get([FromQuery] PaginationDto paginationDto)
        {
            var totalItems = movieService.Count();
            HttpContext.InsertPaginationParams(totalItems, paginationDto.RowsPerPage);
            return await movieService.ListAsync<MovieDto>(paginationDto);
        }

        [HttpGet("{id:int}", Name = "getMovie")]
        public async Task<ActionResult<MovieDto>> Get(int id)
        {
            var movieDto = await movieService.FindOrDefaultAsync<MovieDto>(id);
            if (movieDto == null)
            {
                return NotFound();
            }
            return movieDto;
        }

        [HttpPost()]
        public async Task<ActionResult> Post([FromForm] MovieCreationDto movie)
        {
            var movieDto = await movieService.AddAsync(movie);
            return new CreatedAtRouteResult("getMovie", new { id = movieDto.Id }, movieDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromForm] MovieCreationDto movie)
        {
            var entityUpdated = await movieService.UpdateAsync(id, movie);
            return entityUpdated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return await movieService.RemoveAsync(id) ? NoContent() : NotFound();
        }
        

        [HttpPatch("{id]")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<MoviePatchDto> patchDocument)
        {
            if(patchDocument == null)
            {
                return BadRequest();
            }
            var moviePatchDto = await movieService.FindOrDefaultAsync<MoviePatchDto>(id);
            if(moviePatchDto == null)
            {
                return NotFound();
            }
            patchDocument.ApplyTo(moviePatchDto, ModelState);

            var isValid = TryValidateModel(moviePatchDto);

            if (!isValid)
            {
                return BadRequest();
            }

            return Ok();
        }

    }
}
