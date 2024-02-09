using System.Net;
using static HousePropertyUtility.StaticDetails;

namespace HousePropertyUI.Model
{
    public class APIRequest
    {
        public APIType ApiType { get; set; } = APIType.GET;
        public string URL { get; set; }
        public Object Data { get; set; }
    }
}
