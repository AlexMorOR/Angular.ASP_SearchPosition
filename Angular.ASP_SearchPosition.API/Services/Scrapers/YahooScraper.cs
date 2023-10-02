using Angular.ASP_SearchPosition.Helpers;
using System.Web;

namespace Angular.ASP_SearchPosition.Services.Scrapers
{
    public class YahooScraper : BaseScraper
    {
        private const string OPEN_TAG = "fc-obsidian";
        private const string CLOSE_TAG = "</span";

        public YahooScraper(HttpClient httpClient) : base(Enums.SearchEngine.Yahoo, httpClient) { }

        public override async Task<int[]> FindPlacesAsync(string url, string keywords, int count = 100)
        {
            var html = HttpUtility.HtmlDecode(await _httpClient.GetStringAsync(
                $"https://search.yahoo.com/search?p={keywords.Replace(" ", "+")}&n={count}"
                ));

            return HtmlScraperHelper.FindUrlPositionsByTags(OPEN_TAG, CLOSE_TAG, url, html);
        }
    }
}
