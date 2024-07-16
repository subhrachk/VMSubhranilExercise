using VMSales.Web.Models;
using VMSales.Web.Services.IServices;
using Newtonsoft.Json;
using VMSales.Web.Models.Dto;
using System.Text;
using System.Net.Http.Headers;
using VMSales.Web.Models.Dto;
using VMSales.Web;

namespace VMSales.Web.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDTO response { get; set; }
        private IHttpClientFactory _httpclient;

        public BaseService(IHttpClientFactory httpclient)
        {
            _httpclient = httpclient;
            response = new ResponseDTO();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

        public async Task<T> SendAsync<T>(APIRequest apiRequest)
        {
            try
            {
                HttpRequestMessage req = new HttpRequestMessage();
                var client = _httpclient.CreateClient("SalesAPI");
                client.DefaultRequestHeaders.Clear();
                req.Headers.Add("Accept", "application/json");
                req.RequestUri = new Uri(apiRequest.Url);
                if (apiRequest.Data != null)
                {
                    req.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8, "application/json");
                };
                switch(apiRequest.apiType) {
                    case SD.APIType.POST:
                        req.Method = HttpMethod.Post;
                        break;
                    case SD.APIType.PUT:
                        req.Method = HttpMethod.Put;
                        break;
                    case SD.APIType.DELETE:
                        req.Method = HttpMethod.Delete;
                        break;
                    default:
                        req.Method = HttpMethod.Get;
                        break;
                };
                HttpResponseMessage res = await client.SendAsync(req);
                var apiResponse = await res.Content.ReadAsStringAsync();
                var _res = JsonConvert.DeserializeObject<T>(apiResponse);
                return _res;
            }
            catch(Exception ex)
            {
                ResponseDTO res = new ResponseDTO()
                {
                    IsSuccess = false,
                    Result = null,
                    Message = null,
                    Errors = new List<string>() { ex.Message.ToString() }
                };
                var apiResponse = JsonConvert.SerializeObject(res);
                var _res = JsonConvert.DeserializeObject<T>(apiResponse);
                return _res;

            }
        }
    }
}
