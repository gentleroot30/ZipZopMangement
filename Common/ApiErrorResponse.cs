namespace ZipZop.Common
{
    public class ApiErrorResponse
    {
        public bool Status { get; set; } = false;
        public ErrorDetail Error { get; set; }

        public ApiErrorResponse(string message, int code)
        {
            Error = new ErrorDetail
            {
                Message = message,
                Code = code
            };
        }

        public class ErrorDetail
        {
            public string Message { get; set; }
            public int Code { get; set; }
        }
    }
}
