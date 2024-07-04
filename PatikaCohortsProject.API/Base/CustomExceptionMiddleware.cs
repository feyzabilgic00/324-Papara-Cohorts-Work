namespace PatikaCohortsProject.API.Base;

using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class CustomExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public CustomExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
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

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var response = new ErrorResponse
        {
            StatusCode = context.Response.StatusCode,
            Message = "Internal Server Error. An unexpected error occurred.",
            Detailed = exception.Message 
        };

        return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
    }
}

public class ErrorResponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public string Detailed { get; set; }
}
