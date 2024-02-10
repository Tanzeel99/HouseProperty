using HousePropertyUI.Model.DTO;

namespace HousePropertyUI.Services.IService
{
    public interface IPropertyService
    {
        Task<T> GetAsync<T>(int id);
        Task<T> GetAllAsync<T>();
        Task<T> CreateAsync<T>(PropertyDTOCreate obj);
        Task<T> UpdateAsync<T>(PropertyDTOUpdate obj);
        Task<T> DeleteAsync<T>(int id);
    }
}
