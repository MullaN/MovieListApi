using Microsoft.AspNetCore.Mvc;

namespace MovieListApi.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        
        /// <summary>
        /// Get all movies in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet("movies")]
        public async Task<ActionResult<IList<MovieModel>>> RetrieveAll()
        {
            return Ok(await _movieService.GetAll());
        }

        /// <summary>
        /// Get a specific movie by its id (imdbId)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("movies/{id}")]
        public async Task<ActionResult<MovieModel>> Retrieve(string id)
        {
            var result = await _movieService.Get(id);

            if (result == null)
            {
                return NotFound();
            }
            
            return result;
        }
    }
}