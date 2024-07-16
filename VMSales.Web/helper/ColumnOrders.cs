using Newtonsoft.Json.Linq;
using System.Xml.Linq;
using VMSales.Web.Models;

namespace VMSales.Web.helper
{
    public static class ColumnOrders
    {
        public static List<ColumnOrder> GetAll()
        {
            return new List<ColumnOrder>()
            {

                new ColumnOrder() { Id = "", Name = "Select a Column" },
                new ColumnOrder() { Id = "SegmentName", Name = "Segment Name" },
                new ColumnOrder() { Id = "CountryName", Name = "Country Name" },
                new ColumnOrder() { Id = "ProductName", Name = "Product Name" },
                new ColumnOrder() { Id = "DiscountBand", Name = "Discount Band" },
                new ColumnOrder() { Id = "UnitsSold", Name = "Units Sold" },
                new ColumnOrder() { Id = "ManufacturingPrice", Name = "Manufacturing Price" },
                new ColumnOrder() { Id = "SalePrice", Name = "Sale Price" },
                new ColumnOrder() { Id = "SaleDate", Name = "Sale Date" }
            };
        }
    }
}
