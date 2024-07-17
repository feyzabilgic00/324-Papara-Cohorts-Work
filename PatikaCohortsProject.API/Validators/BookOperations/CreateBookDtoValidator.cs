using FluentValidation;
using PatikaCohortsProject.API.DTOs.Book;

namespace PatikaCohortsProject.API.Validators.BookOperations;

public class CreateBookDtoValidator: AbstractValidator<CreateBookDto>
{
    public CreateBookDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(x => x.Author).NotEmpty().WithMessage("Author is required.");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than zero.");
        RuleFor(x => x.PageCount).NotEmpty().GreaterThan(0).WithMessage("Page count must be greater than zero.");
    }
}
