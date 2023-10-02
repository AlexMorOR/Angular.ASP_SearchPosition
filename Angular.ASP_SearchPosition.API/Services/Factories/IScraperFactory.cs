using Angular.ASP_SearchPosition.Enums;
using Angular.ASP_SearchPosition.Services.Scrapers;

namespace Angular.ASP_SearchPosition.Services.Factories
{
    public interface IScraperFactory
    {
        public IScraper CreateHtmlScraper(SearchEngine searchEngine);

        public SearchEngine[] GetAvaliableSearchEngines();
    }
}
