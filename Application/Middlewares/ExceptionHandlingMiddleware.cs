namespace Project_API.Application.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);  
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocurrió un error: {ex.Message}");

                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                httpContext.Response.ContentType = "application/json";
                var errorResponse = new
                {
                    Message = "Ocurrió un error inesperado en el servidor.",
                    Details = ex.Message
                };

                await httpContext.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }
}
