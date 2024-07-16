using static VMSales.Web.SD;

namespace VMSales.Web.Models
{
    public class APIRequest
    {
        public APIType apiType { get; set; }

        public string Url { get; set; }

        public object Data { get; set; }


    }
}
