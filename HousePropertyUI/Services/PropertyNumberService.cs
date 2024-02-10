using HousePropertyUI.Model;
using HousePropertyUI.Model.DTO;
using HousePropertyUI.Model.DTO.PropertyNumber;
using HousePropertyUI.Services.IService;
using HousePropertyUtility;

namespace HousePropertyUI.Services
{
    public class PropertyNumberService : BaseService, IPropertyNumberService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private string propertyURL;

        public PropertyNumberService(IHttpClientFactory _httpClientFactory,IConfiguration configuration) : base(_httpClientFactory)
        {
            httpClientFactory = _httpClientFactory;
            this.propertyURL = configuration.GetValue<string>("ServiceUrl:PropertyAPIBaseURL");
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.APIType.DELETE,
                URL = this.propertyURL + "/api/PropertyNumber/"+id
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.APIType.GET,
                URL = this.propertyURL + "/api/PropertyNumber"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.APIType.GET,
                URL = this.propertyURL + "/api/PropertyNumber/" + id
            }) ;
        }

        Task<T> IPropertyNumberService.CreateAsync<T>(PropertyNumberDTOCreate obj)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.APIType.POST,
                Data = obj,
                URL = this.propertyURL + "/api/PropertyNumber"
            });
        }

        Task<T> IPropertyNumberService.UpdateAsync<T>(PropertyNumberDTOUpdate obj)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.APIType.PUT,
                Data = obj,
                URL = this.propertyURL + "/api/PropertyNumber/" + obj.PropertyNo
            });
        }
    }
}
