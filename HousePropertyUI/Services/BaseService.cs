using HousePropertyUI.Model;
using HousePropertyUI.Services.IService;
using HousePropertyUtility;
using Newtonsoft.Json;
using System.Text;

namespace HousePropertyUI.Services
{
    public class BaseService : IBaseService
    {
        public APIResponse ApiResponseModel { get; set; }

        //Responsible to call API'S
        public IHttpClientFactory httpClient { get; set; }

        public BaseService(IHttpClientFactory _httpClient)
        {
            this.ApiResponseModel = new();
            this.httpClient = _httpClient;
        }

        public async Task<T> SendAsync<T>(APIRequest ApiRequest)
        {
            try
            {
                var client = httpClient.CreateClient("PropertyAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(ApiRequest.URL);
                if (ApiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(ApiRequest.Data),Encoding.UTF8,"application/json");
                }
                switch(ApiRequest.ApiType)
                {
                    case StaticDetails.APIType.GET:
                        message.Method = HttpMethod.Get;
                        break;
                    case StaticDetails.APIType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case StaticDetails.APIType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case StaticDetails.APIType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                }
                HttpResponseMessage apiResponseStream = null;

                apiResponseStream = await client.SendAsync(message);

                var apiContent = await apiResponseStream.Content.ReadAsStringAsync();

                var apiResponse = JsonConvert.DeserializeObject<T>(apiContent);

                return apiResponse;
            }
            catch (Exception ex)
            {
                var dto = new APIResponse
                {
                    ErrorMessage = new List<string> { Convert.ToString(ex.Message) },
                    IsSuccess = false,
                };
                var res = JsonConvert.SerializeObject(dto);
                var apiResponse = JsonConvert.DeserializeObject<T>(res);
                return apiResponse;
            }
        }
    }
}
