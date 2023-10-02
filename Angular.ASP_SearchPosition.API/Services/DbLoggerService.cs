using Angular.ASP_SearchPosition.Data.Contexts;
using Angular.ASP_SearchPosition.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Angular.ASP_SearchPosition.Services
{
    public class DbLoggerService : IDbLoggerService
    {
        private readonly SearchDbContext _searchDbContext;
        private readonly IHttpContextAccessor _httpContext;

        public DbLoggerService(SearchDbContext searchDbContext, IHttpContextAccessor httpContext)
        {
            _searchDbContext = searchDbContext;
            _httpContext = httpContext;
        }

        public async Task<IEnumerable<RequestModel>> GetLogAsync(int count = 10)
        {
            return await _searchDbContext.Requests
                             .OrderByDescending(x => x.CreatedAt)
                             .Take(count)
                             .ToListAsync();
        }

        public void LogCurrentRequest(long execTime, Exception? exception)
        {
            var request = _httpContext?.HttpContext?.Request;
            var route = request?.Path.Value + request?.QueryString.Value;

            _searchDbContext.Requests.Add(new RequestModel()
            {
                Exception = exception == null ? null : exception.ToString(),
                ExecTime = execTime,
                Route = route,
                CreatedAt = DateTime.Now,
            });
            _searchDbContext.SaveChanges();
        }
    }
}
