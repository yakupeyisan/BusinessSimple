using System.Net;
using Core.Aspects.Autofac.Security;
using Microsoft.Extensions.Logging;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Http;
using System;

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
        catch (AuthenticationException ex)
        {
            await HandleAuthenticationException(ex, context);
            return;
        }
        catch (AuthorizationException ex)
        {
            await HandleAuthorizationException(ex, context);
            return;
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

    private async Task HandleAuthorizationException(AuthorizationException authorizationException, HttpContext context)
    {
        context.Response.StatusCode = StatusCodes.Status403Forbidden;
        context.Response.ContentType = Text.Plain;
        await context.Response.WriteAsync(authorizationException.Message);
    }

    private async Task HandleAuthenticationException(AuthenticationException exception,HttpContext context)
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        context.Response.ContentType = Text.Plain;
        await context.Response.WriteAsync(exception.Message);
    }

    public async Task HandleValidationException(ValidationException ex, HttpContext context)
    {
        context.Response.StatusCode = ex.StatusCode;
        context.Response.ContentType = Text.Plain;
        await context.Response.WriteAsync(ex.Message);
    }
}