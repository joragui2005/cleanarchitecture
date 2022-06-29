namespace CleanArchitecture.Presentation.Errors
{
    public class CodeErrorException : CodeErrorResponse
    {
        public string? Details { get; set; }
        public CodeErrorException(int statusCode, string? message, string? details) : base(statusCode, message)
        {
            Details = details;
        }
    }
}
