using Newtonsoft.Json;
using System.Net;
using XYZPlatform.Models.DTO;

namespace XYZPlatform.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;
        private readonly APIResponseDTO _response;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
            _response = new();
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }


        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            _response.StatusCode = HttpStatusCode.InternalServerError;
            _response.IsExitoso = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(_response));
        }
    }
}
