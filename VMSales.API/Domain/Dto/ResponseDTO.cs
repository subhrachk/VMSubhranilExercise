namespace VMSales.API.Models.Dto
{
    public class ResponseDTO
    {
        public bool IsSuccess { get; set; }
        public object Result { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}
