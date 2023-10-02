using Angular.ASP_SearchPosition.Data.Contexts;
using Angular.ASP_SearchPosition.Enums;
using Angular.ASP_SearchPosition.Models;
using Angular.ASP_SearchPosition.Services.Factories;
using Angular.ASP_SearchPosition.Services.Scrapers;
using Microsoft.EntityFrameworkCore;

namespace Angular.ASP_SearchPosition.Services
{
    public class SearchService : ISearchService
    {
        private readonly IScraperFactory _scraperFactory;
        private readonly SearchDbContext _searchDbContext;

        public SearchService(IScraperFactory scraperFactory, SearchDbContext searchDbContext)
        {
            _scraperFactory = scraperFactory;
            _searchDbContext = searchDbContext;
        }

        public async Task<SearchResultModel> SearchAsync(string keywords, string url, SearchEngine searchEngine)
        {
            IScraper scraper = _scraperFactory.CreateHtmlScraper(searchEngine);

            int[] positions = await scraper.FindPlacesAsync(url, keywords);

            var resultModel = new SearchResultModel()
            {
                Keywords = keywords,
                Url = url,
                Engine = SearchEngineHelper.GetEngineName(searchEngine),
                Positions = positions,
                CreatedAt = DateTime.Now,
            };

            await _searchDbContext.SearchResults.AddAsync(resultModel);
            await _searchDbContext.SaveChangesAsync();

            return resultModel;
        }

        public IEnumerable<SearchEngine> GetAllSearchEngines()
        {
            return _scraperFactory.GetAvaliableSearchEngines();
        }

        public IEnumerable<SearchResultModel> GetHistory(int count = 10)
        {
            return _searchDbContext.SearchResults
                             .OrderByDescending(x => x.CreatedAt)
                             .Take(count)
                             .ToList();
        }
    }
}
