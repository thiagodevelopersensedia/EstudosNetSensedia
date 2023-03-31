namespace Sensedia.API.Error
{
    public class ApiResponse
    {
        public int StatusCode { get; }
        public string Message { get; }
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made.",
                401 => "Authorized, you are not.",
                404 => "Resource found, it was not.",
                500 => "Error server exception.",
                _ => null
            };
        }
    }
}
