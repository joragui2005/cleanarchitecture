using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Presentation.Errors;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace CleanArchitecture.Presentation.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _environment;


        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                context.Response.ContentType = "application/json";
                var statusCode = StatusCodes.Status500InternalServerError;
                var result = string.Empty;

                switch (e)
                {
                    case NotFoundException notFoundException:
                        statusCode = StatusCodes.Status404NotFound;
                        var notFoundJson = JsonConvert.SerializeObject(notFoundException);
                        result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, e.Message, notFoundJson));
                        break;
                    case ValidationException validationException:
                        statusCode = StatusCodes.Status400BadRequest;
                        var validationJson = JsonConvert.SerializeObject(validationException.Errors);
                        result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, e.Message, validationJson));
                        break;
                    case BadRequestException badRequestException:
                        statusCode = StatusCodes.Status400BadRequest;
                        var badRequestJson = JsonConvert.SerializeObject(badRequestException);
                        result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, e.Message, badRequestJson));
                        break;
                    default:
                        break;
                }

                if (string.IsNullOrEmpty(result))
                    result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, e.Message, e.InnerException.Message ?? e.Message));

                context.Response.StatusCode = statusCode;

                await context.Response.WriteAsync(result);
            }
        }
    }
}
