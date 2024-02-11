using HouseProperty.Model;
using System.Linq.Expressions;

namespace HouseProperty.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null,string? includeProperties = null);
        Task<T> Get(Expression<Func<T, bool>>? filter = null, bool tracked = true, string? includeProperties = null);
        Task Create(T entity);
        Task Delete(T entity);
        Task Save();
    }
}
