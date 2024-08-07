using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.DTO;
using MovieAPI.Services;

namespace MovieAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public MovieController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost("/create")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<MovieReadOnlyDTO>> AddMovie(MovieCreateDTOcs movie)
        {
            var response = await _applicationService.MovieService.CreateMovie(movie);
            return Ok(response);
        }

        [HttpGet("/getAllMovie")]
        public async Task<ActionResult<MovieReadOnlyDTO>> GetAllMovies()
        {
            var response = await _applicationService.MovieService.GetAllMovies();
            return Ok(response);
        }

        [HttpGet("/getMovie{id}")]
        public async Task<ActionResult<MovieReadOnlyDTO>> GetMovieById(int id)
        {
            var response = await _applicationService.MovieService.GetMovieById(id);
            return Ok(response);
        }

        [HttpDelete("/deleteMovie{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var response = await _applicationService.MovieService.DeleteMovie(id);
            return Ok(response);
        }

        [HttpPut("/Update")]
        public async Task<IActionResult> DeleteMovie(MovieUpdateDTO movie)
        {
            var response = await _applicationService.MovieService.UpdateMovie(movie);
            return Ok(response);
        }
    }
}
