using Angular.ASP_SearchPosition.Enums;
using Angular.ASP_SearchPosition.Services.Scrapers;
using System.Net.Http;

namespace Angular.ASP_SearchPosition.Services.Factories
{
    public class ScraperFactory : IScraperFactory
    {
        private IScraper[] _availableScrapers;

        public ScraperFactory(IHttpClientFactory httpClientFactory)
        {
            var httpClient = httpClientFactory.CreateClient("universal");

            _availableScrapers = new IScraper[]{
                new GoogleScraper(httpClient),
                new YahooScraper(httpClient),
                new YahooUKScraper(httpClient),
                new BingScraper(httpClient),
            };
        }

        public IScraper CreateHtmlScraper(SearchEngine searchEngine)
        {
            var scraper = _availableScrapers.FirstOrDefault(sc => sc.SearchEngine == searchEngine);

            if (scraper == null)
            {
                throw new NotImplementedException($"Scraper for {searchEngine} not implemented.");
            }

            return scraper;
        }

        public SearchEngine[] GetAvaliableSearchEngines()
        {
            return _availableScrapers.Select(sc => sc.SearchEngine).ToArray();
        }
    }
}
