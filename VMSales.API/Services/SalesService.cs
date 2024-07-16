using VMSales.API.Domain.Dto;
using VMSales.API.Repositories;

namespace VMSales.API.Services
{
    public class SalesService : ISalesService
    {

        private readonly ISalesRepository _repository;
       

       public SalesService(ISalesRepository repository)
        {
            _repository = repository;
        }

        // Get All Movies
        public async Task<List<SalesDto>> GetAllSales()
        {
            return _repository.GetAllSales();
        }

    }
}
