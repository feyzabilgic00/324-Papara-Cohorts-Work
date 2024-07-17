using FluentValidation;

namespace PatikaCohortsProject.API.Validators.BookOperations;

public class GetByIdBookValidator: AbstractValidator<int>
{
    public GetByIdBookValidator()
    {
        RuleFor(x => x)
             .NotEmpty().GreaterThan(0).WithMessage("Id must be greater than zero.");
    }
}
