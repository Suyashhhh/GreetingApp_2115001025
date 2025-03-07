namespace MiddleWare.GlobalExceptionHandling
{
    public class ExceptionHandler
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }

        public ExceptionHandler(string message, int statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }
    }
}
