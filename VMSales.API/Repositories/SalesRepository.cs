using AutoMapper;
using Microsoft.AspNetCore.Components.Web;
using VMSales.API.Domain.Dto;
using System.IO;
using System.Text;
using VMSales.API.Repositories;
using VMSales.API.Domain;
using VMSales.API.helper;
using System.Globalization;
using Microsoft.AspNetCore.Http;


namespace VMSales.API.Repositories
{
    public class SalesRepository : ISalesRepository
    {

        private readonly IMapper _mapper;
        static readonly string textFile = Directory.GetCurrentDirectory() + @"\Data\Data.csv";
        CultureInfo provider = CultureInfo.InvariantCulture;

        public SalesRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<SalesDto> GetAllSales()
        {
            var allsales = new List<Sales>();
            string s = String.Empty;
            int SalesId = 1;

            using (StreamReader sr = new StreamReader(textFile, Encoding.UTF8))
            {
                do
                {
                   
                    s = sr.ReadLine(); 
                    if ((s != null))
                    {
                        string[] str = s.Split(",").ToArray();

                        if (str[0].ToUpper() != "SEGMENT" && str.Length > 0)
                        {
                            Double teststr = String.IsNullOrEmpty(str[5]) ? 0 : Convert.ToDouble(RemoveSpace.RemoveFirstCharIfNotNumber(RemoveSpace.TrimSpaceInside(str[5])));

                            allsales.Add(new Sales() { 
                                SalesId = SalesId, 
                                SegmentName = str[0].Trim(),
                                CountryName = str[1].Trim(),
                                ProductName = str[2].Trim(),
                                DiscountBand = str[3].Trim(),
                                UnitsSold = Convert.ToDecimal(RemoveSpace.TrimSpaceInside(str[4])),
                                ManufacturingPrice = ChnagestruingtoDecimal(str[5]),
                                SalePrice = ChnagestruingtoDecimal(str[6]),
                                SaleDate = DateTime.ParseExact(str[7], "d", provider)
                            });
                            SalesId++;
                        }
                    }
                }
                while (s != null);
                
                
            }

            return _mapper.Map<List<SalesDto>>(allsales);
        }

        private static decimal ChnagestruingtoDecimal(string str)
        {
            return String.IsNullOrEmpty(str) ? 0 : Convert.ToDecimal(RemoveSpace.RemoveFirstCharIfNotNumber(RemoveSpace.TrimSpaceInside(str)));
        }
    }
}
