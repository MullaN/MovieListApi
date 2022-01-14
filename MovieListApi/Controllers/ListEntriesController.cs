using ListListApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MovieListApi.Controllers
{
    [Route("listentries")]
    public class ListEntriesController : Controller
    {
        private readonly IListEntryService _listEntryService;

        public ListEntriesController(IListEntryService listEntryService)
        {
            _listEntryService = listEntryService;
        }

        /// <summary>
        /// Get all lists in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IList<ListEntryModel>>> RetrieveAll()
        {
            return Ok(await _listEntryService.GetAll());
        }

        /// <summary>
        /// Get a specific list by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ListEntryModel>> Retrieve(Guid id)
        {
            var result = await _listEntryService.Get(id);

            if (result == null)
            {
                return NotFound();
            }
            
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<ListEntryModel>> Insert([FromBody] ListEntryModel listEntry)
        {
            var result = await _listEntryService.Insert(listEntry);

            return Created(new Uri($"lists/{result.ListId}", UriKind.Relative), result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ListEntryModel>> Update(Guid id, [FromBody] ListEntryModel listEntry)
        {
            var result = await _listEntryService.Update(id, listEntry);

            if (result == null)
            {
                return BadRequest();
            }

            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            return await _listEntryService.Delete(id);
        }
    }
}