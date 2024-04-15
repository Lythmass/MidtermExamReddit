using System.Net;

namespace Reddit.Middlewares
{
    public class GlobalExceptionHandling
    {
        private readonly RequestDelegate _nextDelegate;
        private readonly ILogger<GlobalExceptionHandling> _logger;

        public GlobalExceptionHandling(RequestDelegate nextDelegate, ILogger<GlobalExceptionHandling> logger)
        {
            _nextDelegate = nextDelegate;
            _logger = logger;
        }

        public async Task AsyncInvoke(HttpContext context)
        {
            try
            {
                await _nextDelegate(context);
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync("Unexpected error occured on the server");
            }
        }
    }
}
