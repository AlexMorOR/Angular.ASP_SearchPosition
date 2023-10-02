using Angular.ASP_SearchPosition.Enums;

namespace Angular.ASP_SearchPosition.Services.Scrapers
{
    public abstract class BaseScraper : IScraper
    {
        protected readonly HttpClient _httpClient;

        public BaseScraper(SearchEngine searchEngine, HttpClient httpClient)
        {
            SearchEngine = searchEngine;

            _httpClient = httpClient;
        }

        public SearchEngine SearchEngine { get; }

        public abstract Task<int[]> FindPlacesAsync(string url, string keywords, int count = 100);
    }
}
