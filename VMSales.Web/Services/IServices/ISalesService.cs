using VMSales.Web.Models.Dto;

namespace VMSales.Web.Services.IServices
{
    public interface ISalesService : IBaseService
    {
        Task<T> GetSalesAsync<T>();
        Task<T> GetSalesByIdAsync<T>(int salesId);
        Task<T> CreateSalesAsync<T>(SalesDto salesDto);
        Task<T> UpdateeSalesAsync<T>(SalesDto salesDto);
        Task<T> DeleteSalesAsync<T>(int salesId);
    }
}
