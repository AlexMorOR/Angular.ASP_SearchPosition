using Angular.ASP_SearchPosition.Enums;

namespace Angular.ASP_SearchPosition.Services.Scrapers
{
    public interface IScraper
    {
        public SearchEngine SearchEngine { get; }

        public Task<int[]> FindPlacesAsync(string url, string keywords, int count = 100);
    }
}
