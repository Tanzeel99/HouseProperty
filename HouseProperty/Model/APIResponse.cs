using System.Net;

namespace HouseProperty.Model
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<String> ErrorMessage { get; set; } = new List<String>();
        public object Result { get; set; }
    }
}
