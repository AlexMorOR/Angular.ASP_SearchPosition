using Angular.ASP_SearchPosition.Data.Entities;

namespace Angular.ASP_SearchPosition.Services
{
    public interface IDbLoggerService
    {
        public void LogCurrentRequest(long execTime, Exception? exception);

        public Task<IEnumerable<RequestModel>> GetLogAsync(int count = 10);
    }
}
