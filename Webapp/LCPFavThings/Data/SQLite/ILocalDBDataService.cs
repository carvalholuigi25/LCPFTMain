using System.Linq.Expressions;

namespace LCPFavThings.Data.SQLite
{
    public interface ILocalDBDataService
    {
        Task<int> Create<T>(T item);
        Task<List<T>> CreateAndGet<T>(T item) where T : new();
        Task<List<T>> Read<T>() where T : new();
        Task<List<T>> ReadById<T>(Expression<Func<T, bool>> predicate) where T : new();
        Task<int> Update<T>(T item);
        Task<int> Delete<T>(T item);
        Task<List<T>> QueryIt<T>(string qry) where T : new();
    }
}
