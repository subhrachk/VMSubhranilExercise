using VMSales.Web.Models;
using VMSales.Web.Models.Dto;

namespace VMSales.Web.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        public ResponseDTO response { get; set; }
        Task<T> SendAsync<T>(APIRequest apiRequest);
    }
}
