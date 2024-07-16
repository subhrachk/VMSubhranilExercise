using VMSales.API.Domain.Dto;

namespace VMSales.API.Repositories
{
    public interface ISalesRepository
    {
        List<SalesDto> GetAllSales();
    }
}