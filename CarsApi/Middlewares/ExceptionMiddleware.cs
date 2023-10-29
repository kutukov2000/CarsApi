using BusinessLogic.ApiModels;
using BusinessLogic.Exceptions;
using System.Net;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (HttpException ex)
        {
            await HandleExceptionAsync(httpContext, ex.Message, ex.StatusCode);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex.Message);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;
        await context.Response.WriteAsync(new ErrorDetails()
        {
            StatusCode = context.Response.StatusCode,
            Message = message
        }.ToString());
    }
}
