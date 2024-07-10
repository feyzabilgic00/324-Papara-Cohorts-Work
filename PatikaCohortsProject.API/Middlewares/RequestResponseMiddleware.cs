namespace PatikaCohortsProject.API.Middlewares;

//Global loglama yapan bir middleware
public class RequestResponseMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestResponseMiddleware> _logger;
    public RequestResponseMiddleware(RequestDelegate next, ILogger<RequestResponseMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation($"Query Keys: {(context.Request.QueryString)}");
        _logger.LogInformation($"Action 'a girildi {context.Request.Path} at {DateTime.UtcNow}");

        await _next.Invoke(context);
    }
}
