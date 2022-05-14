using PeliculasCore.DTOs;
using System.Linq.Expressions;

namespace PeliculasCore.Repositories
{
    public interface IBaseRepository<T>
    {
        T Add(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
        bool Any(Expression<Func<T, bool>> predicate);
        int Count();
        T? FindOrDefault(int id);
        Task<T?> FindOrDefaultAsync(int id);
        List<T> List();
        List<T> List(PaginationDto pagination);
        Task<List<T>> ListAsync();
        Task<List<T>> ListAsync(PaginationDto pagination);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
    }
}