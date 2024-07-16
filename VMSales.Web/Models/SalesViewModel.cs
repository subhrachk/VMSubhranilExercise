using Microsoft.AspNetCore.Mvc.Rendering;
using VMSales.Web.Models.Dto;
using static VMSales.Web.SD;

namespace VMSales.Web.Models
{
    public class SalesViewModel
    {
        public List<SalesDto> SalesView { get; set; }
        public List<SelectListItem> SalesColumnOrderSelectList { get; set; }
        public string SalesColumnOrder { get; set; }
        public Pagination pager { get; set; }
    }
}
