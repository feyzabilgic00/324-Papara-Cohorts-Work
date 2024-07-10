using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using PatikaCohortsProject.API.Services;

namespace PatikaCohortsProject.API.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class CustomAuthorizeAttribute: Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var userService = context.HttpContext.RequestServices.GetService<IUserService>();

        if (!context.ActionArguments.TryGetValue("email", out var emailObj) ||
            !context.ActionArguments.TryGetValue("password", out var passwordObj))
        {
            context.Result = new BadRequestObjectResult("Email and password are required.");
            return;
        }

        var email = emailObj as string;
        var password = passwordObj as string;

        if (!await userService.Login(email, password))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        await next();
    }
}
