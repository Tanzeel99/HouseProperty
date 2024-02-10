using HousePropertyUI.Model.DTO;
using HousePropertyUI.Model.DTO.PropertyNumber;

namespace HousePropertyUI.Services.IService
{
    public interface IPropertyNumberService
    {
        Task<T> GetAsync<T>(int id);
        Task<T> GetAllAsync<T>();
        Task<T> CreateAsync<T>(PropertyNumberDTOCreate obj);
        Task<T> UpdateAsync<T>(PropertyNumberDTOUpdate obj);
        Task<T> DeleteAsync<T>(int id);
    }
}
