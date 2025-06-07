using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace SaldoZen.MiddlewareExecption
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

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro inesperado.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var problemDetails = new ProblemDetails
            {
                Title = "Ocorreu um erro inesperado.",
                Status = context.Response.StatusCode,
                Detail = exception.Message,
                Instance = context.Request.Path
            };

            var result = JsonSerializer.Serialize(problemDetails);
             await context.Response.WriteAsync(result);
        }
    }
}
