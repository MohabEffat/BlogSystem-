using BlogSystem.Infrastructure.HandleResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace BlogSystem.Infrastructure.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _environment;
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, IHostEnvironment environment, RequestDelegate next)
        {
            _logger = logger;
            _environment = environment;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var code = (int)HttpStatusCode.InternalServerError;

                _logger.LogError(ex, ex.Message);

                context.Response.StatusCode = code;
                context.Response.ContentType = "application/json";

                var response = _environment.IsDevelopment()
                    ? new CustomException(code, ex.Message, ex.StackTrace)
                    : new CustomException(code, ex.Message);

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                var jsonResponse = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(jsonResponse);
            }
        }
    }
}
