using ListListApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MovieListApi.Controllers
{
    [Route("lists")]
    public class ListsController : Controller
    {
        private readonly IListService _listService;

        public ListsController(IListService listService)
        {
            _listService = listService;
        }

        /// <summary>
        /// Get all lists in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IList<ListModel>>> RetrieveAll()
        {
            return Ok(await _listService.GetAll());
        }

        /// <summary>
        /// Get a specific list by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ListModel>> Retrieve(Guid id)
        {
            var result = await _listService.Get(id);

            if (result == null)
            {
                return NotFound();
            }
            
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<ListModel>> Insert([FromBody] ListModel list)
        {
            var result = await _listService.Insert(list);

            return Created(new Uri($"lists/{result.ListId}", UriKind.Relative), result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ListModel>> Update(Guid id, [FromBody] ListModel list)
        {
            var result = await _listService.Update(id, list);

            if (result == null)
            {
                return BadRequest();
            }

            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            return await _listService.Delete(id);
        }
    }
}