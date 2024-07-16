using System.Collections.Specialized;

namespace VMSales.Web.Models.Dto
{
    public class SalesDto
    {
        public int SalesId { get; set; }
        //public int SegmentId { get; set; }
        public string SegmentName { get; set; }
        //public int CountryId { get; set; }
        public string CountryName { get; set; }
        //public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string DiscountBand { get; set; }
        public decimal UnitsSold { get; set; }
        public decimal ManufacturingPrice { get; set; }
        public decimal SalePrice { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
