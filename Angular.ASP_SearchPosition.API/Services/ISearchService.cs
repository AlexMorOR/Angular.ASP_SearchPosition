using Angular.ASP_SearchPosition.Enums;
using Angular.ASP_SearchPosition.Models;

namespace Angular.ASP_SearchPosition.Services
{
    public interface ISearchService
    {
        public Task<SearchResultModel> SearchAsync(string keywords, string url, SearchEngine searchEngine);

        public IEnumerable<SearchEngine> GetAllSearchEngines();

        public IEnumerable<SearchResultModel> GetHistory(int count = 10);
    }
}
