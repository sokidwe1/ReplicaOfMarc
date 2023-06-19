using Business.Implementations.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System.Net;

namespace Training2.Middlewares
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, RequestDelegate next )
        {
            _logger = logger;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch ( Exception exception )
            {
                _logger.LogError($"An Error Occured: {exception.Message}");
                await HandleExceptionAsync(httpContext, exception);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var code = string.Empty;
            if (exception is TrainingException)
            {
                var trainingException = (TrainingException)exception;
                httpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                code = trainingException.Code;
            }
            else 
            {

                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new
                {
                    StatusCode = httpContext.Response.StatusCode,
                    Code = code,
                    Message = exception.Message
                }).ToString());

            }            
        }
    }
}
