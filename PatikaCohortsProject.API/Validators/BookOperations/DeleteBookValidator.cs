using FluentValidation;
using PatikaCohortsProject.API.Model;

namespace PatikaCohortsProject.API.Validators.BookOperations;

public class DeleteBookValidator: AbstractValidator<int>
{
    public DeleteBookValidator()
    {
        RuleFor(x => x)
             .NotEmpty().GreaterThan(0).WithMessage("Id must be greater than zero.");
    }
}
