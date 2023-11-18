using HouseProperty.Model;
using System.Linq.Expressions;

namespace HouseProperty.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllProperty(Expression<Func<T, bool>>? filter = null);
        Task<T> GetProperty(Expression<Func<T, bool>>? filter = null, bool tracked = true);
        Task Create(T entity);
        Task Delete(T entity);
        Task Save();
    }
}
