using System.Linq.Expressions;

namespace LCPFavThings.Data.SQL
{
    public interface IAllDataService
    {
        Task<List<T>> Get<T>(string apiname);
        Task<List<T>> GetById<T>(string apiname, int id);
        Task<List<T>> ReadById<T>(string apiname, Expression<Func<T, bool>> predicate);
        Task<T> Insert<T>(string apiname, T body);
        Task<List<T>> InsertAndGet<T>(string apiname, T body);
        Task<T> Update<T>(string apiname, int id, T body);
        Task<List<T>> Delete<T>(string apiname, int id);
        Task<dynamic> QueryIt<T>(string qry, string dbmt = "sqlite") where T : new();
    }
}
