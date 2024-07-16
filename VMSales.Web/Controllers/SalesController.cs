using VMSales.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VMSales.Web.Models.Dto;
using VMSales.Web.Models;
using static VMSales.Web.SD;
using VMSales.Web.helper;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VMSales.Web.Controllers
{
    public class SalesController : Controller
    {
        private ISalesService _salesServ;
        private ResponseDTO _response;

        public SalesController(ISalesService salesServ)
        {
            _salesServ = salesServ;
            _response = new ResponseDTO();   
        }

        public async Task<IActionResult> Index(int page=1, string columnOrder = "")
        {
            SalesViewModel salesViewModel = new SalesViewModel();
            const int pageSize = 10;
            page = page < 1 ? 1 : page;
            var ColumnOrderdata = ColumnOrders.GetAll();

            List<SalesDto> sales = new List<SalesDto>();
            _response = await _salesServ.GetSalesAsync<ResponseDTO>();
            


            if (_response != null && _response.IsSuccess == true)
            {
                var ordersales = JsonConvert.DeserializeObject<List<SalesDto>>(Convert.ToString(_response.Result));
                switch(columnOrder)
                {
                    case "SegmentName":
                        sales = ordersales.OrderBy(x => x.SegmentName).ToList();
                        break;
                    case "CountryName":
                        sales = ordersales.OrderBy(x => x.CountryName).ToList();
                        break;
                    case "ProductName":
                        sales = ordersales.OrderBy(x => x.ProductName).ToList();
                        break;
                    case "DiscountBand":
                        sales = ordersales.OrderBy(x => x.DiscountBand).ToList();
                        break;
                    case "UnitsSold":
                        sales = ordersales.OrderBy(x => x.UnitsSold).ToList();
                        break;
                    case "ManufacturingPrice":
                        sales = ordersales.OrderBy(x => x.ManufacturingPrice).ToList();
                        break;
                    case "SalePrice":
                        sales = ordersales.OrderBy(x => x.SalePrice).ToList();
                        break;
                    case "SaleDate":
                        sales = ordersales.OrderBy(x => x.SaleDate).ToList();
                        break;
                    case "":
                        sales = ordersales;
                        break;

                }


                int resCount = sales.Count();
                var pager = new Pagination(resCount,page,pageSize);

                int recordSkip = (page -1) * pageSize;

                var data = sales.Skip(recordSkip).Take(pager.PageSize).ToList();

                salesViewModel.SalesView = data;
                salesViewModel.pager = pager;
                salesViewModel.SalesColumnOrderSelectList = new List<SelectListItem>();
                salesViewModel.SalesColumnOrder = columnOrder;

                foreach (var columnOrderdata in ColumnOrderdata) 
                {
                    salesViewModel.SalesColumnOrderSelectList.Add(new SelectListItem { Text = columnOrderdata.Name, Value = columnOrderdata.Id });
                }

                return View(salesViewModel);
                //return View(sales);
            }
            else
            {
                return View(sales);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(SalesViewModel salesViewModel) 
        {
            var selectorderColumn = salesViewModel.SalesColumnOrder;
            return RedirectToAction("Index", new { page= 1, columnOrder = selectorderColumn });
        }

        

    }
}
