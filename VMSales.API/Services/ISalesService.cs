using VMSales.API.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMSales.API.Domain;

namespace VMSales.API.Services
{
    public interface ISalesService
    {
        Task<List<SalesDto>> GetAllSales();
    }
}
