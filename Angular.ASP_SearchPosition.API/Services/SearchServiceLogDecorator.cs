using Angular.ASP_SearchPosition.Data.Contexts;
using Angular.ASP_SearchPosition.Data.Entities;
using Angular.ASP_SearchPosition.Enums;
using Angular.ASP_SearchPosition.Models;
using System.Diagnostics;

namespace Angular.ASP_SearchPosition.Services
{
    public class SearchServiceLogDecorator : ISearchService
    {
        private readonly ISearchService _inner;
        private readonly IDbLoggerService _logger;

        public SearchServiceLogDecorator(ISearchService inner, IDbLoggerService logger) 
        {
            _inner = inner;
            _logger = logger;
        }

        public IEnumerable<SearchEngine> GetAllSearchEngines()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Exception? exception = null;
            try
            {
                var result = _inner.GetAllSearchEngines();
                return result;
            }
            catch (Exception e)
            {
                exception = e;
                throw;
            }
            finally
            {
                stopwatch.Stop();

                _logger.LogCurrentRequest(stopwatch.ElapsedMilliseconds, exception);
            }
        }

        public IEnumerable<SearchResultModel> GetHistory(int count = 10)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Exception? exception = null;
            try
            {
                var result = _inner.GetHistory(count);
                return result;
            }
            catch (Exception e)
            {
                exception = e;
                throw;
            }
            finally
            {
                stopwatch.Stop();

                _logger.LogCurrentRequest(stopwatch.ElapsedMilliseconds, exception);
            }
        }

        public async Task<SearchResultModel> SearchAsync(string keywords, string url, SearchEngine searchEngine)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Exception? exception = null;
            try
            {
                var result = await _inner.SearchAsync(keywords, url, searchEngine);
                return result;
            }
            catch (Exception e)
            {
                exception = e;
                throw;
            }
            finally
            {
                stopwatch.Stop();

                _logger.LogCurrentRequest(stopwatch.ElapsedMilliseconds, exception);
            }
        }
    }
}
