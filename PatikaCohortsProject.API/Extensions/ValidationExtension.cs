using FluentValidation.AspNetCore;
using PatikaCohortsProject.API.Validators.BookOperations;

namespace PatikaCohortsProject.API.Extensions;

public static class ValidationExtension
{
    public static void Validator(this IServiceCollection services)
    {
        services.BookValidator();
    }
    public static void BookValidator(this IServiceCollection services)
    {
        services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateBookDtoValidator>());
    }
}
