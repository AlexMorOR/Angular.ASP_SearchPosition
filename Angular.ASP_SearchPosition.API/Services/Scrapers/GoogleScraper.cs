using Angular.ASP_SearchPosition.Helpers;
using System.Text;
using System.Web;

namespace Angular.ASP_SearchPosition.Services.Scrapers
{
    public class GoogleScraper : BaseScraper
    {
        private const string OPEN_TAG = "<cite";
        private const string CLOSE_TAG = "</cite";

        public GoogleScraper(HttpClient httpClient) : base(Enums.SearchEngine.Google, httpClient) { }

        public override async Task<int[]> FindPlacesAsync(string url, string keywords, int count = 100)
        {
            // Best way: Use HtmlAgility
            // Because it's easier to maintain and read
            /*
            var web = new HtmlWeb();
            var doc = await web.LoadFromWebAsync(
                $"https://www.google.com/search?q={keywords.Replace(" ", "+")}&num={count}"
            );

            var citeTags = doc.DocumentNode.SelectNodes("//cite");
            if (citeTags == null) return Array.Empty<int>(); // No results found

            List<int> positions = new List<int>();
            int currPos = 0;

            foreach (var citeTag in citeTags)
            {
                if (citeTag.InnerHtml.Contains(url))
                {
                    positions.Add(currPos);
                }
                currPos++;
            }

            return positions.ToArray();
             */


            var html = HttpUtility.HtmlDecode(await _httpClient.GetStringAsync(
                $"https://www.google.com/search?q={keywords.Replace(" ", "+")}&num={count}"
                ));

            return HtmlScraperHelper.FindUrlPositionsByTags(OPEN_TAG, CLOSE_TAG, url, html);
        }
    }
}
