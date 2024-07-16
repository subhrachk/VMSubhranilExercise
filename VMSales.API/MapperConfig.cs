using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMSales.API.Domain;
using VMSales.API.Domain.Dto;

namespace MovieManagement.Application
{
    public class MapperConfig
    {
        public static MapperConfiguration SalesConfigMap() 
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SalesDto, Sales>();
                cfg.CreateMap<Sales,SalesDto>();
            });

            return configuration;
        }
    }
}
