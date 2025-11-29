namespace SaldoZen.McpServer.DTOs
{
    public class ApiResult<T>
    {
        public T? Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
