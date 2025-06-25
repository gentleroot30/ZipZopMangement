namespace ZipZop.Common
{
    public class ApiResponse<T>
    {
        public bool Status { get; set; } = true;
        public T Data { get; set; }
        public string? Message { get; set; }

        public ApiResponse(T data, string? message = null)
        {
            Data = data;
            Message = message;
        }
    }
}
