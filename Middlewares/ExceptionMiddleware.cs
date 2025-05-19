using System.Text.Json;
using Microsoft.AspNetCore.Http;
using OrderQueueSystem.Dtos;

namespace OrderQueueSystem.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
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
            _logger.LogError(ex, "Erro inesperado!");
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";
            var errorResponse = new ErrorResponseDto(500, ex.Message, context.Request?.Path.Value, DateTime.Now);
            await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        }
    }
}

