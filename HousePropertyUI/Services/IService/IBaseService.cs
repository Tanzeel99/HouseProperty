using HousePropertyUI.Model;

namespace HousePropertyUI.Services.IService
{
    public interface IBaseService
    {
        public APIResponse ApiResponseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest ApiRequest);
    }
}
