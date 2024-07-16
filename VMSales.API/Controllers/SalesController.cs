using Microsoft.AspNetCore.Mvc;
using VMSales.API.Domain.Dto;
using VMSales.API.Models.Dto;
using VMSales.API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VMSales.API.Controllers
{
    [Route("api/sales")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _service;
                private ResponseDTO _response;

        public SalesController(ISalesService service)
        {
            _service = service;
            _response = new ResponseDTO();
        }

        // GET: api/<MoviessController>
        [HttpGet]
        public async Task<object> Get()
        {
            //var salesFromRepo = _service.GetAllSales();
            //return Ok(salesFromRepo);

            try
            {
                _response.IsSuccess = true;
                _response.Result = await _service.GetAllSales();
                _response.Message = "All Sales Selected";
                _response.Errors = null;
                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Result = null;
                _response.Message = null;
                _response.Errors = new List<string>() { ex.Message.ToString() };
                return _response;
            }
        }

    }
}
