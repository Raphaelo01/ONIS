using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace ONIS.Shared.ErrorHandlers;

public class CustomErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public CustomErrorHandlerMiddleware(RequestDelegate next, ILogger<CustomErrorHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {

            _ = ex.InnerException == null ? string.Empty : ex.InnerException.Message;
            // Log the error with Serilog
            _logger.LogError(ex, $"An unhandled exception has occurred OriginalMessage {ex.Message} Source {ex.Source ?? ""} InnerEx {ex.InnerException} ");

            // Return a custom error response to the client
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var errorResponse = new
            {
                StatusCode = context.Response.StatusCode,
                Message = "An error occurred while processing your request."
            };
            var json = JsonSerializer.Serialize(errorResponse);
            await context.Response.WriteAsync(json);
        }
    }
}