namespace VMSales.Web
{
        public class SD
        {
            public enum APIType { GET, POST, PUT, DELETE };
            public static string SalesAPIBase { get; set; }
            public enum ColumnOrder {
            SegmentName,
            CountryName,
            ProductName,
            DiscountBand,
            UnitsSold,
            ManufacturingPrice,
            SalePrice,
            SalesDate
        };
    }
}
