using Angular.ASP_SearchPosition.Enums;
using Angular.ASP_SearchPosition.Models;
using Angular.ASP_SearchPosition.Services;
using Microsoft.AspNetCore.Mvc;

namespace Angular.ASP_SearchPosition.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        // GET: api/search/engines
        [HttpGet("engines")]
        public ActionResult<IEnumerable<SearchEngineModel>> GetEngines()
        {
            var results =
                _searchService.GetAllSearchEngines()
                .Select(e => new SearchEngineModel()
                {
                    Name = SearchEngineHelper.GetEngineName(e),
                    SearchEngine = e
                });

            return Ok(results);
        }

        // GET: api/search/history
        [HttpGet("history")]
        public ActionResult<IEnumerable<SearchResultModel>> GetHistory()
        {
            var results = _searchService.GetHistory();
            return Ok(results);
        }

        // GET: api/search?query=something&url=someurl&engine=0
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SearchResultModel>>> Search(string query, string url, SearchEngine engine)
        {
            if(string.IsNullOrEmpty(query))
                throw new ArgumentNullException(nameof(query));

            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            var results = await _searchService.SearchAsync(query, url, engine);
            return Ok(results);
        }
    }
}
