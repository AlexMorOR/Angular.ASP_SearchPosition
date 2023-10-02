using Angular.ASP_SearchPosition.Helpers;
using System.Web;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace Angular.ASP_SearchPosition.Services.Scrapers
{
    public class BingScraper : BaseScraper
    {
        private const string OPEN_TAG = "<cite";
        private const string CLOSE_TAG = "</cite";

        public BingScraper(HttpClient httpClient) : base(Enums.SearchEngine.Bing, httpClient) { }

        public override async Task<int[]> FindPlacesAsync(string url, string keywords, int count = 100)
        {
            var html = HttpUtility.HtmlDecode(await _httpClient.GetStringAsync(
                $"https://www.bing.com/search?q={keywords.Replace(" ", "+")}&count={count}"
                ));

            return HtmlScraperHelper.FindUrlPositionsByTags(OPEN_TAG, CLOSE_TAG, url, html);
        }
    }
}
