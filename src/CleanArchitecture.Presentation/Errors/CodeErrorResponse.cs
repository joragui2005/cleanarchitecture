namespace CleanArchitecture.Presentation.Errors
{
    public class CodeErrorResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public CodeErrorResponse(int statusCode, string? message)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageStatusCode(statusCode);
        }

        public string GetDefaultMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "The request has errors",
                401 => "You do not have authorization",
                404 => "Resource not found",
                500 => "Internal Server Error",
                _ => "Without status code"
            };
        }

    }
}
