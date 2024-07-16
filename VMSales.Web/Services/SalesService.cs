using VMSales.Web.Models;
using VMSales.Web.Services.IServices;
using VMSales.Web.Models.Dto;

namespace VMSales.Web.Services
{
    public class SalesService : BaseService , ISalesService
    {
        private IHttpClientFactory httpclient;
        public SalesService(IHttpClientFactory httpclient) : base(httpclient)
        {
            this.httpclient = httpclient;
        }

        public async Task<T> GetSalesAsync<T>()
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                apiType = SD.APIType.GET,
                Data = null,
                Url = SD.SalesAPIBase + "api/sales"
            });
        }
        public async Task<T> CreateSalesAsync<T>(SalesDto salesDto)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                apiType = SD.APIType.POST,
                Data = salesDto,
                Url = SD.SalesAPIBase + "api/sales" 
            });
        }

      


        public async Task<T> GetSalesByIdAsync<T>(int salesId)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                apiType = SD.APIType.GET,
                Data = null,
                Url = SD.SalesAPIBase + "api/sales/" + salesId
            });
        }

        public async Task<T> UpdateeSalesAsync<T>(SalesDto salesDto)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                apiType = SD.APIType.PUT,
                Data = salesDto,
                Url = SD.SalesAPIBase + "api/sales"
            });
        }

        public async Task<T> DeleteSalesAsync<T>(int salesId)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                apiType = SD.APIType.DELETE,
                Data = null,
                Url = SD.SalesAPIBase + "api/sales/" + salesId
            });
        }

    }
}
