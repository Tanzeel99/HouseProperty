using HousePropertyUI.Model;
using HousePropertyUI.Model.DTO;
using HousePropertyUI.Services.IService;
using HousePropertyUtility;

namespace HousePropertyUI.Services
{
    public class PropertyService : BaseService, IPropertyService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private string propertyURL;

        public PropertyService(IHttpClientFactory _httpClientFactory,IConfiguration configuration) : base(_httpClientFactory)
        {
            httpClientFactory = _httpClientFactory;
            this.propertyURL = configuration.GetValue<string>("ServiceUrl:PropertyAPIBaseURL");
        }

        public Task<T> CreateAsync<T>(PropertyDTOCreate obj)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.APIType.POST,
                Data = obj,
                URL = this.propertyURL + "/api/Property"
            }) ;
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.APIType.DELETE,
                URL = this.propertyURL + "/api/Property/"+id
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.APIType.GET,
                URL = this.propertyURL + "/api/Property"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.APIType.GET,
                URL = this.propertyURL + "/api/Property/" + id
            }) ;
        }

        public Task<T> UpdateAsync<T>(PropertyDTOUpdate obj)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.APIType.PUT,
                Data = obj,
                URL = this.propertyURL + "/api/Property/"+obj.Id
            });
        }
    }
}
