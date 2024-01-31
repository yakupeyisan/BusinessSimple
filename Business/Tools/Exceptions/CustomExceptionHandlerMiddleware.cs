using Microsoft.Extensions.Logging;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Http;

namespace Business.Tools.Exceptions;

public class CustomExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private ILogger<CustomExceptionHandlerMiddleware> _logger;

    public CustomExceptionHandlerMiddleware(RequestDelegate next, ILogger<CustomExceptionHandlerMiddleware> logger)
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
            var valex = ex.InnerException as ValidationException;
            if (valex != null)
            {
                await HandleValidationException(valex, context);
                return;
            }
            _logger.LogError("İç hata oluştu:" + ex.Message);
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = Text.Plain;
            await context.Response.WriteAsync("Internal server error");
        }
    }
    public async Task HandleValidationException(ValidationException ex, HttpContext context)
    {
        context.Response.StatusCode = ex.StatusCode;
        context.Response.ContentType = Text.Plain;
        await context.Response.WriteAsync(ex.Message);
    }
}