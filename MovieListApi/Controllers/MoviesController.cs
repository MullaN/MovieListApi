using Microsoft.AspNetCore.Mvc;

namespace MovieListApi.Controllers
{
    [Route("movies")]
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
        [HttpGet()]
        public async Task<ActionResult<IList<MovieModel>>> RetrieveAll()
        {
            return Ok(await _movieService.GetAll());
        }

        /// <summary>
        /// Get a specific movie by its id (imdbId)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieModel>> Retrieve(string id)
        {
            var result = await _movieService.Get(id);

            if (result == null)
            {
                return NotFound();
            }
            
            return result;
        }

        [HttpGet("search")]
        public async Task<ActionResult<IList<MovieModel>>> Search([FromQuery] string queryString, [FromQuery] bool searchExternal = false)
        {
            return Ok(await _movieService.Search(queryString, searchExternal));
        }
    }
}